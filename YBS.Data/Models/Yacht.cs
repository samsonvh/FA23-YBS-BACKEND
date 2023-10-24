using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using YBS.Data.Enums;

namespace YBS.Data.Models
{
    public class Yacht
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public int YachtTypeId { get; set; }
        [ForeignKey("YachtTypeId")]
        public virtual YachtType YachtType { get; set; }
        public string Name { get; set; }
        public string ImageURL { get; set; }
        public string Description { get; set; }
        public string Manufacturer { get; set; }
        public int GrossTonnage { get; set; }
        public string GrossTonnageUnit { get; set; }
        public int Range { get; set; }
        public string RangeUnit { get; set; }
        public int TotalCrew { get; set; }
        public int CrusingSpeed { get; set; }
        public int MaxSpeed { get; set; }
        public string SpeedUnit { get; set; }
        public int Year { get; set; }
        public string LOA { get; set; }
        public string BEAM { get; set; }
        public string DRAFT { get; set; }
        public int FuelCapacity { get; set; }
        public string FuelCapacityUnit { get; set; }
        public int MaximumGuestLimit { get; set; }
        public int Cabin { get; set; }
        public DateTime CreationDate { get; set; }
        public EnumYachtStatus Status { get; set; }
    }
}