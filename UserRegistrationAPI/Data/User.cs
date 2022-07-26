﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserRegistrationAPI.Models
{
    public class User : IdentityUser
    {

        [ForeignKey(nameof(DataSheet))]
        public string DataSheetId { get; set; }
        public DataSheet DataSheet { get; set; }

    }
}
