﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpticalCRM.EntityFramework.Entity
{
    public class userMaster
    {
        [Key]
        public string CustomerId { get; set; }
        public string password { get; set; }
        public string GSTNumber { get; set; }
        public string ShopName { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string MobNumber { get; set; }
        public int State { get; set; }
        public int City { get; set; }
        public string Pincode { get; set; }
        public string Address { get; set; }
        public string LogoName { get; set; }
        public string LogoPath { get; set; }
        public int status { get; set; }
        public int roleType { get; set; }
        public int createdBy { get; set; }
        public DateTime createdDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime updatedDate { get; set; }
    }
}