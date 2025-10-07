using System.ComponentModel.DataAnnotations.Schema;

namespace Route.GYM.DAL.Models.HealthRecord
{
    [Table("Members")]
    public class HealthRecord : BaseEntity
    {
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
        public string BloodType { get; set; } = null!;
        public string? Note { get; set; }
    }
}
