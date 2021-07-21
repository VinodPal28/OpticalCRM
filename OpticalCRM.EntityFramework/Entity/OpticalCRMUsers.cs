using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpticalCRM.EntityFramework.Entity
{
    public class OpticalCRMUsers
    {       
        public int Id { get; set; }

        public int UserId { get; set; }

        public int status { get; set; }

        public int createdBy { get; set; }

        public DateTime createdDate { get; set; }
    }
}
