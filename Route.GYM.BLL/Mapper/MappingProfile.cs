using AutoMapper;
using Route.GYM.BLL.DTOs.SessionDTO;
using Route.GYM.DAL.Models.Session;

namespace Route.GYM.BLL.Mapper
{
    public class MappingProfile : Profile
    {
        #region Constructor

        public MappingProfile()
        {
            MapSession();
        }

        #endregion

        #region Methods

        private void MapSession() 
        {
            CreateMap<Session, SessionDTO>()
                .ForMember(dest => dest.CategoryName , opt => opt.MapFrom(src => src.Category.CategoryName))
                .ForMember(dest => dest.TrainerName, opt => opt.MapFrom(src => src.Trainer.Name))
                .ForMember(dest => dest.AvailableSlots, opt => opt.Ignore());

            CreateMap<CreateSessionDTO, Session>();

            CreateMap<UpdateSessionDTO, Session>().ReverseMap();
        }

        #endregion
    }
}
