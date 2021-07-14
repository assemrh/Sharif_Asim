using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sharif_Asim.Models
{
    public class User: IdentityUser
    {
        public Guid AddressID { get; set; }
    }
}
