//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace iPark.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ParkingLot
    {
        public ParkingLot()
        {
            this.Bookings = new HashSet<Booking>();
        }
    
        public string lot_id { get; set; }
        public string status { get; set; }
        public string location { get; set; }
    
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
