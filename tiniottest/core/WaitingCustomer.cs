using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core
{
    class WaitingCustomer
    {
        public int Id { get; set; }
        public String SignInTime { get; set; }
        public String IsAppointment { get; set; }
        public String Status { get; set; }
        public String Phone { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Request { get; set; }
        public String DisplayName { get {
                return "#" + Id + " " + FirstName + " " + LastName + ": request " + Request;
            } }

        public String TimeWaited { get {
                var currentDate = DateTime.Now;
                var signInDate = DateTime.Parse(SignInTime);
                var timeSpan = currentDate.Subtract(signInDate);
                var waitDuration = String.Format("{0} h {1} m", timeSpan.Hours, timeSpan.Minutes);
                return "Waited " + waitDuration;
                //return "Sign In time: " + SignInTime.Substring(SignInTime.IndexOf("T") + 1) + " Waited: " + waitDuration ;
            } }
    }
}
