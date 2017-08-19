using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Model
{
    class UIModel
    {
    }

    public class ControlDiemension
    {
        [Key]
        public int ControlDiemensionID { get; set; }
        [StringLength(20)]
        public String ControlName { get; set; }
        public string ControlDescription { get; set; }
        public int? ControlWidth { get; set; }
        public int? ControlHeight { get; set; }
        public int StoreID { get; set; }
        public virtual Store Store { get; set; }
    }
}
