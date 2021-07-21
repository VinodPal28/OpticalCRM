using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpticalCRM.EntityFramework.Entity
{
    public class userAuthentication
    {
        public string customerId { get; set; }
        [Key]
        public string username { get; set; }
        public string password { get; set; }
        public int status { get; set; }
        public int createdBy { get; set; }
        public DateTime createDate { get; set; }
        public int updatedBy { get; set; }
        public DateTime updatedDate { get; set; }
    }
}
