using Microsoft.EntityFrameworkCore;

namespace Route.GYM.DAL.Models.Address
{
    [Owned]
    public class Address
    {
        public int BuidingNumber { get; set; }
        public string Street { get; set; } = null!;
        public string City { get; set; } = null!;
    }
}
