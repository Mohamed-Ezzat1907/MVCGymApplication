namespace Route.GYM.DAL.Models.Category
{
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; } = null!;
        public ICollection<Session.Session> Sessions { get; set; } = null!;
    }
}
