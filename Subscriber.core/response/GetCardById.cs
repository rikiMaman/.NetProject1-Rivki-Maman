using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscriber.core.response
{
    public class GetCardById
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public float Height { get; set; }

        public float Weight {get; set;}

        public float BMI { get; set;}
       
    }
}
