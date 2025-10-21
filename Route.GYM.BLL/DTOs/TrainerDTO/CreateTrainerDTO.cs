using Route.GYM.DAL.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Route.GYM.BLL.DTOs.TrainerDTO
{
    public class CreateTrainerDTO
    {
        [Required(ErrorMessage = "Name IS Required.")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Name Must contain only letters and Single spaces Between Words.")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Email Is Required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Phone Is Required.")]
        [Phone(ErrorMessage = "Invalid Phone Number.")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^(011|011|012|015)\d{8}", ErrorMessage = "Phone Number Must Be a Valid Egyption Number.")]
        public string Phone { get; set; } = null!;

        [Required(ErrorMessage = "Date Of Birth Is Required")]
        [DataType(DataType.Date)]
        public DateOnly DateOfBirth { get; set; } 

        [Required(ErrorMessage = "Gender Is Required.")]
        public Gender Gender { get; set; }
        [Required(ErrorMessage = "Buiding Number Is Required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Buiding Number Must Be a Positive Number.")]
        public int BuidingNumber { get; set; }

        [Required(ErrorMessage = "Street Is Required.")]
        [StringLength(150, MinimumLength = 2, ErrorMessage = "Street Must Be Between 2 And 150 Charcters.")]
        [RegularExpression(@"^[a-zA-Z0-9\s]+$", ErrorMessage = "Street Must contain only letters and Numbers Between Words.")]
        public string Street { get; set; } = null!;

        [Required(ErrorMessage = "City Is Required.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "City Must Be Between 2 And 100 Charcters.")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "City Must contain only letters and Single spaces Between Words.")]
        public string City { get; set; } = null!;

        [Required(ErrorMessage = "Specialities Is Required.")]
        [EnumDataType(typeof(Specialities))]
        public Specialities Specialities { get; set; } 
    }
}
