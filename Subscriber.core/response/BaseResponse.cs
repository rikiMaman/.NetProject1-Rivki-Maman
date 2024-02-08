using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscriber.core.response
{
    public class BaseResponse
    {
        public bool Succeed { get; set; }

        public string message { get; set; }
        public BaseResponse()
        {
            Succeed = false;
           
        }
    }
}

