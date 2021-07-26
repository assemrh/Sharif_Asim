﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sharif_Asim.Models
{
    public class Dto
    {
        public class UserDto
        {
            [Required]
            public string UserName { get; set; }
            [Required]
            public string Password { get; set; }
            public string Email { get; set; }
        }

    }
}
