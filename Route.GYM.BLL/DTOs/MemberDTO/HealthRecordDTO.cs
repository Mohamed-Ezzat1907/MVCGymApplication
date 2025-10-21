using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Route.GYM.BLL.DTOs.MemberDTO
{
    public class HealthRecordDTO
    {
        [Range(0.1, 300, ErrorMessage ="Height Must Be Greater Than 0.")]
        public decimal Height { get; set; }

        [Range(0.1, 500, ErrorMessage = "Weight Must Be Greater Than 0.")]
        public decimal Weight { get; set; }

        [Required(ErrorMessage = "Blood Type Is Required.")]
        [StringLength(3, MinimumLength = 1, ErrorMessage = "Blood Type Must Be Between 1 And 3 Charcters.")]
        public string BloodType { get; set; } = null!;
        public string? Note { get; set; }
    }
}
