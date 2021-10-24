using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMAPILibrary
{
    public class CurrentModel
    {
        public ConditionModel Condition { get; set; }
        public float temp_f { get; set; }
        public float wind_mph { get; set; }
        public string feelslike_f { get; set; }
        public string humidity { get; set; }
    }
}
