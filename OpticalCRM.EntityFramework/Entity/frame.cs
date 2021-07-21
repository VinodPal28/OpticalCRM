using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpticalCRM.EntityFramework.Entity
{
    public class frame
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Key]
        public string productCode { get; set; }
        public string name { get; set; }
        public string color { get; set; }
        public string size { get; set; }
        public string type { get; set; }
        public string shape { get; set; }
        public string material { get; set; }
        public string company { get; set; }
        public string gender { get; set; }
        public string trackInventory { get; set; }
        public string allowNegativeInventory { get; set; }
        public decimal purchaseBasePrice { get; set; }
        public decimal purchasePrice { get; set; }
        public decimal retailPrice { get; set; }
        public int flag { get; set; }
        public int createdby { get; set; }
        public DateTime? createdDate { get; set; }
        public int updatedby { get; set; }
        public DateTime? updatedDate { get; set; }
    }
}
