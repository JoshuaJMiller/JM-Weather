using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMAPILibrary
{
    public class DayModel
    {
        public double maxtemp_f { get; set; }
        public double mintemp_f { get; set; }
        public ConditionModel Condition { get; set; }

    }
}
