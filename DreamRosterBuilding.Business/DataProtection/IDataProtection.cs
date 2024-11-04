using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamRosterBuilding.Business.DataProtection
{
    public interface IDataProtection // -> I will manage password crypt security processes here
    {
        string Crypt(string key);
        string Encrypt(string key);
    }
}

