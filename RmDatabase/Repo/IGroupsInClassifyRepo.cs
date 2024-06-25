using RmDatabase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RmDatabase.Repo
{
    public interface IGroupsInClassifyRepo
    {
        IList<GroupsInClassify> GetList(int clCode, int? parent);

        IList<GroupsInClassify> GetList(int[] types, string name);
    }
}
