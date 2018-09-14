using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tiniottest.core.Model
{
    public class EventContainer
    {
        public EType eventType
        {
            get;
            set;
        }

        public Object eventData
        {
            get;
            set;
        }
    }
}
