using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RmDatabase.DTO;
using RmDatabase.Entities;
using RmReports;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RmUI.Reports
{
    public static class ApplicationOnResourceMapCR
    {
        public static string GetCrystalReport()
        {
            string json = File.ReadAllText("appsettings.json");

            string reports = JObject.Parse(json)
                .SelectToken("Reports")
            .ToString();

            var reportName = JsonConvert.DeserializeObject<Classes.Reports>(reports);

            return reportName.ApplicationOnResource;
        }

        public static CRParam[] GetCrystalReportParams(
            DateTime? beginPeriod,
            DateTime? endPeriod,
            List<Enterprise> enterprises,
            List<PAgree> agreeList,
            List<LabouringList> responsibleList,
            List<ClassifyNode> groupList,
            List<StockObj> stockObjList,
            List<ClaimsForMats> claimsForMatsList,
            bool isShowStandard)
        {
            // значения по умолчанию для списков
            // если пользователь не выбрал значения
            if (enterprises.Count == 0)
            {
                enterprises.Add(new Enterprise()
                {
                    EntCode = -1
                });
            }

            if (agreeList.Count == 0)
            {
                agreeList.Add(new PAgree()
                {
                    Code = -1
                });
            }

            if (responsibleList.Count == 0)
            {
                responsibleList.Add(new LabouringList()
                {
                    Code = -1
                });
            }

            if (groupList.Count == 0)
            {
                groupList.Add(new ClassifyNode()
                {
                    Code = -1,
                    Name = "Не задан"
                });
            }

            if (stockObjList.Count == 0)
            {
                stockObjList.Add(new StockObj()
                {
                    Code = -1
                });
            }

            if (claimsForMatsList.Count == 0)
            {
                claimsForMatsList.Add(new ClaimsForMats()
                {
                    Code = -1
                });
            }

            // параметры в Crystal Reports
            var crParams = new List<CRParam>
            {
                new CRParam()
                {
                    Name = "Дата начала периода",
                    Values = new object[] { beginPeriod ?? DateTime.MinValue }
                },
                new CRParam()
                {
                    Name = "Дата окончания периода",
                    Values = new object[] { endPeriod ?? DateTime.MaxValue }
                },
                new CRParam()
                {
                    Name = "Поставщик",
                    Values = enterprises.Select(x => (object)x.EntCode).ToArray()
                },
                new CRParam()
                {
                    Name = "Договор",
                    Values = agreeList.Select(x => (object)x.Code).ToArray()
                },
                new CRParam()
                {
                    Name = "Ответственный",
                    Values = responsibleList.Select(x => (object)x.Code).ToArray()
                },
                new CRParam()
                {
                    Name = "Группа ТМЦ",
                    Values = groupList.Select(x => (object)x.Name).ToArray()
                },
                new CRParam()
                {
                    Name = "Номенклатура",
                    Values = stockObjList.Select(x => (object)x.Code).ToArray()
                },
                new CRParam()
                {
                    Name = "Заявка",
                    Values = claimsForMatsList.Select(x => (object)x.Code).ToArray()
                },
                new CRParam()
                {
                    Name = "Эталон",
                    Values = new object[] { isShowStandard }
                }
            };

            return crParams.ToArray();
        }
    }
}
