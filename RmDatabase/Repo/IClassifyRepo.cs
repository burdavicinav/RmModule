using RmDatabase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RmDatabase.Repo
{
    public interface IClassifyRepo
    {
        IList<Classify> GetByTypes(int[] types);

        Classify GetByCode(int code);
    }
}
