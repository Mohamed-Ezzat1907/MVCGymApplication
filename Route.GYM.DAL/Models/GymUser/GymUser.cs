﻿using Route.GYM.DAL.Models.Enum;

namespace Route.GYM.DAL.Models.GymUser
{
    public abstract class GymUser : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public DateOnly DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public Address.Address Address { get; set; } = null!;
    }
}
