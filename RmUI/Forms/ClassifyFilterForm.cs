using RmDatabase.DTO;
using RmDatabase.Entities;
using RmLogger;
using RmUI.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace RmUI.Forms
{
    public partial class ClassifyFilterForm : Form
    {
        public List<ClassifyNode> GroupList { get; private set; }

        public int User { get; private set; }

        public ClassifyFilterForm()
        {
            InitializeComponent();
        }

        public ClassifyFilterForm(int user)
            : this()
        {
            User = user;

            groupScene.CheckBoxes = true;
            GroupList = new List<ClassifyNode>();
        }

        private void OnFilterButtonClick(object sender, EventArgs e)
        {
            groupScene.Nodes.Clear();

            GroupList = new List<ClassifyNode>();

            if (groupBox.Text == string.Empty)
            {
                AutoFilter();
            }
            else
            {
                ManualFilter();
            }
        }

        private void AutoFilter()
        {
            try
            {
                using (var context = new UnitOfWork())
                {
                    var classifyList = context.ClassifyRepo.GetByTypes(new[] { 1, 12 } );

                    foreach (var node in classifyList.Select(
                        x => new ClassifyNode()
                        {
                            Code = x.Code,
                            ClCode = x.Code,
                            Type = ClassifyNodeType.Classify,
                            Name = x.ClName
                        }))
                    {
                        var classifyNode = AddNode(node, null);
                    }
                }
            }
            catch (Exception exc)
            {
                log.Error(exc.Message, User);
            }
        }

        private void ManualFilter()
        {
            try
            {
                using (var context = new UnitOfWork())
                {
                    groupList = context.GroupsInClassifyRepo
                                    .GetList(new[] { 1, 12 }, groupBox.Text)
                                    .ToList();

                    foreach (var classifyCode in groupList
                                                .Select(x => x.ClCode)
                                                .Distinct())
                    {
                        var classify = context.ClassifyRepo.GetByCode(classifyCode);

                        var classifyNode = new ClassifyNode()
                        {
                            Code = classify.Code,
                            ClCode = classify.Code,
                            Type = ClassifyNodeType.Classify,
                            Name = classify.ClName
                        };

                        var root = AddNode(
                            node: classifyNode,
                            parent: null,
                            isDynamic: false);

                        foreach (var group in groupList
                                                .Where(x => x.ClCode == classifyCode
                                                        && x.UpperGroup == null))
                        {
                            AddGroupNode(classifyCode, group, root);
                        }

                        root.Expand();
                    }
                }
            }
            catch (Exception exc)
            {
                log.Error(exc.Message, User);
            }
        }

        private void OnBeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            int isDynamic = e.Node.Nodes
                .OfType<TreeNode>()
                .Count(x => x.Text == "<dynamic>");

            if (isDynamic > 0)
            {
                e.Node.Nodes.Clear();

                var classifyNode = e.Node.Tag as ClassifyNode;

                int? parent = null;

                if (classifyNode.Type == ClassifyNodeType.Group)
                {
                    parent = classifyNode.Code;
                }

                try
                {
                    using (var context = new UnitOfWork())
                    {
                        var groupList = context.GroupsInClassifyRepo.GetList(
                            classifyNode.ClCode,
                            parent
                            );

                        foreach (var node in groupList.Select(
                            x => new ClassifyNode()
                            {
                                Code = x.Code,
                                ClCode = x.ClCode,
                                Type = ClassifyNodeType.Group,
                                Prefix = x.GrCode,
                                Name = x.GrName
                            }))
                        {
                            var groupNode = AddNode(node, e.Node);
                        }
                    }
                }
                catch (Exception exc)
                {
                    log.Error(exc.Message, User);
                }
            }
        }

        private void OnAfterCheckNode(object sender, TreeViewEventArgs e)
        {
            var classifyNode = e.Node.Tag as ClassifyNode;

            if (classifyNode.Type == ClassifyNodeType.Group)
            {
                if (e.Node.Checked)
                {
                    GroupList.Add(classifyNode);
                }
                else
                {
                    GroupList.Remove(classifyNode);
                }
            }
        }

        private TreeNode AddNode(ClassifyNode node, TreeNode parent, bool isDynamic = true)
        {
            TreeNode treeNode = new TreeNode()
            {
                Tag = node,
                Text = node.Description,
            };

            if (isDynamic) treeNode.Nodes.Add(new TreeNode("<dynamic>"));

            if (parent == null)
            {
                groupScene.Nodes.Add(treeNode);
            }
            else
            {
                parent.Nodes.Add(treeNode);
            }

            return treeNode;
        }

        private void AddGroupNode(int classifyCode, GroupsInClassify group, TreeNode parent)
        {
            var node = new ClassifyNode()
            {
                Code = group.Code,
                ClCode = classifyCode,
                Type = ClassifyNodeType.Group,
                Prefix = group.GrCode,
                Name = group.GrName
            };

            var treeNode = new TreeNode()
            {
                Tag = node,
                Text = node.Description,
            };

            parent.Nodes.Add(treeNode);

            foreach (var childGroup in groupList
                                        .Where(x => x.ClCode == classifyCode
                                                    && x.UpperGroup == group.Code))
            {
                AddGroupNode(classifyCode, childGroup, treeNode);
            }

            treeNode.Expand();
        }

        private void OnAccept(object sender, EventArgs e)
        {
            if (GroupList.Count == 0)
            {
                UserMessage.RequireRowWarning();

                return;
            }

            DialogResult = DialogResult.OK;
        }

        private List<GroupsInClassify> groupList;

        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    }
}
