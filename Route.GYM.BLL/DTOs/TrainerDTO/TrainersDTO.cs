using Route.GYM.DAL.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Route.GYM.BLL.DTOs.TrainerDTO
{
    public class TrainersDTO
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Specialities { get; set; } = null!;
    }
}
