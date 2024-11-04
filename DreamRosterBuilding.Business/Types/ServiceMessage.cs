using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamRosterBuilding.Business.Types
{
    public class ServiceMessage // -> This type for returning message and success status from service to out layer/api. I will control this communication with this type.
    {
        public bool IsSucceed { get; set; }
        public string Message { get; set; }
    }
    public class ServiceMessage<T>
    {
        public bool IsSucceed { get; set; }
        public string Message { get; set; }
        public T? Data { get; set; } // -> Sometimes I will need data for return so I defined generic version as well
    }
}
