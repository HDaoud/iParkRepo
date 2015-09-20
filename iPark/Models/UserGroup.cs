using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPark.Models
{
    public class UserGroup
    {
        public int GroupID { get; set; }
        public string GroupName { get; set; }
        public string Privileges { get; set; }
    }
}
