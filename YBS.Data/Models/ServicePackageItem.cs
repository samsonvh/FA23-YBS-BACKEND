using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace YBS.Data.Models
{
    public class ServicePackageItem
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        [ForeignKey("ServiceId")]
        public Service Service { get; set; }
        public int ServicePackageId { get; set; }
        [ForeignKey("ServicePackageId")]
        public ServicePackage ServicePackage { get; set; }
    }
}