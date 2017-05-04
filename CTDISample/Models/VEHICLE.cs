using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CTDISample.Models
{
    public class VEHICLE
    {
        [Key]
        //[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int VEHICLE_ID { get; set; }
        [StringLength(100)]
        public string VEHICLE_NUMBER { get; set; }
        [StringLength(100)]
        public string VEHICLE_OWNER { get; set; }
        [StringLength(100)]
        public string VEHICLE_MODEL { get; set; }
    }
}