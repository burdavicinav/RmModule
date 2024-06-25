using RmDatabase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RmDatabase.Repo
{
    public interface IPAgreeRepo
    {
        IList<PAgree> GetList(
            string agreeNum,
            DateTime? agreeDate,
            List<Enterprise> enterprises,
            DateTime? orderBeginDate,
            DateTime? orderEndDate
            );
    }
}
