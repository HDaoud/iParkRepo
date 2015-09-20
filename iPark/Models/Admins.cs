using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iPark.Models
{
    public class Admins : UserGroup
    {
        int GroupID = 0;
        string GroupName = "Admins";
        string Privileges = "Full";
    }
}