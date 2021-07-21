using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpticalCRM.EntityFramework.Entity
{
    public class log
    {        
        [MaxLength]
        public string Message { get; set; }
        public string RequestMethod { get; set; }
        public string RequestUri { get; set; }
        [Key]
        public DateTime CreatedDate { get; set; }
    }
}
