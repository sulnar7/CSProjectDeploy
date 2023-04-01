﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClarieTheme.ViewModels.Account
{
    public class RegisterVM
    {
        //[Required, StringLength(200)]
        //public string Name { get; set; }
        //[Required, StringLength(200)]
        //public string Lastname { get; set; }
        //[Required, StringLength(200)]
        //public string UserName { get; set; }
        //[Required, DataType(DataType.EmailAddress)]
        //public string Email { get; set; }
        //[DataType(DataType.Password)]
        //public string Password { get; set; }

        [Required, StringLength(200)]
        public string Name { get; set; }
        [Required, StringLength(200)]
        public string UserName { get; set; }
        
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        //[Required, DataType(DataType.Password), Compare(nameof(Password))]
        //public string CheckPassword { get; set; }
    }
}
