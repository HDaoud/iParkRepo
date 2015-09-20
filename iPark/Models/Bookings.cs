using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iPark.Models
{
    public class Bookings
    {
        public int BookingID { get; set; }
        public int UserID { get; set; }
        public int LotID { get; set; }
        public DateTime BookingTime { get; set; }
        public DateTime CheckInTime { get; set; }
        
        //The expected check out time
        public DateTime ReleaseTime { get; set; }
        public DateTime CheckOutTime { get; set; }
    }
}