using Route.GYM.BLL.DTOs.MemberDTO;
using Route.GYM.DAL.Models.Address;
using Route.GYM.DAL.Models.HealthRecord;
using Route.GYM.DAL.Models.Member;
using Route.GYM.DAL.Persistence.UnitOfWork;

namespace Route.GYM.BLL.Services.Members
{
    public class MemberService : IMemberService
    {
        #region Field

        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Constructor

        public MemberService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Methods

        // Get All Members
        public IEnumerable<MembersDTO> GetAllMembers()
        {
            var members = _unitOfWork.MemberRepository.GetAll() ?? [];
            if (members is null || !members.Any())
                return [];

            return members.Select(m => new MembersDTO
            {
                Id = m.Id,
                Photo = m.Photo,
                Name = m.Name,
                Email = m.Email,
                Gender = m.Gender.ToString(),
                Phone = m.Phone,
            });
        }

        // Get Member By Id
        public MemberDetailsDTO? GetMemberById(int id)
        {
            var member = _unitOfWork.MemberRepository.Get(id);

            if (member is null)
                return null;

            var MemberViewModel =  new MemberDetailsDTO
            {
                Id = member.Id,
                Photo = member.Photo,
                Name = member.Name,
                Email = member.Email,
                Gender = member.Gender.ToString(),
                Phone = member.Phone,
                DateOfBirth = member.DateOfBirth.ToShortDateString(),
                Address = FormatAddress(member.Address),
            };

            var activeMemberShip = _unitOfWork.MemberShipRepository
                                   .GetAll(ms => ms.MemberId == id && ms.Status == "Active")
                                   .FirstOrDefault();

            if (activeMemberShip is not null)
            { 
                var plan = _unitOfWork.PlanRepository.Get(activeMemberShip.PlanId);
                MemberViewModel.PlanName = plan?.Name;
                MemberViewModel.MemberShipStartDate = activeMemberShip.CreatedAt.ToShortDateString();
                MemberViewModel.MemberShipEndDate = activeMemberShip.EndDate.ToShortDateString();
            }

            return MemberViewModel;
        }

        // Add Member
        public bool AddMember(CeateMemberDTO ceateMemberDTO)
        {
            try 
            {
                if (IsEmailExist(ceateMemberDTO.Email) || IsPhoneExist(ceateMemberDTO.Phone))
                    return false;
                var member = new Member
                {
                    Name = ceateMemberDTO.Name,
                    Email = ceateMemberDTO.Email,
                    Phone = ceateMemberDTO.Phone,
                    Gender = ceateMemberDTO.Gender,
                    DateOfBirth = ceateMemberDTO.DateOfBirth,
                    Address = new Address
                    {
                        BuidingNumber = ceateMemberDTO.BuidingNumber,
                        Street = ceateMemberDTO.Street,
                        City = ceateMemberDTO.City,
                    },
                    HealthRecord = new HealthRecord
                    {
                        Height = ceateMemberDTO.HealthRecord.Height,
                        Weight = ceateMemberDTO.HealthRecord.Weight,
                        BloodType = ceateMemberDTO.HealthRecord.BloodType,
                        Note = ceateMemberDTO.HealthRecord.Note,
                    },
                };
                _unitOfWork.MemberRepository.Add(member);
                _unitOfWork.SaveChanges();

                return true;
            }
            catch 
            {
                return false;
            }
        }

        // Get Member To Update
        public UpdateMemberDTO? GetMemberToUpdate(int memberId)
        {
            var member = _unitOfWork.MemberRepository.Get(memberId);

            if (member is null)
                return null;

            var updateMemberDTO = new UpdateMemberDTO
            {
                Photo = member.Photo,
                Name = member.Name,
                Email = member.Email,
                BuidingNumber = member.Address.BuidingNumber,
                Street = member.Address.Street,
                City = member.Address.City,
            };

            return updateMemberDTO;
        }

        // Update Member
        public bool UpdateMember(int id, UpdateMemberDTO memberCreateDTO) 
        {
            var member = _unitOfWork.MemberRepository.Get(id);

            if (member is null)
                return false;

            if (IsEmailExist(memberCreateDTO.Email) || IsPhoneExist(memberCreateDTO.Phone))
                return false;

            member.Email = memberCreateDTO.Email;
            member.Phone = memberCreateDTO.Phone;
            member.Address.BuidingNumber = memberCreateDTO.BuidingNumber;
            member.Address.Street = memberCreateDTO.Street;
            member.Address.City = memberCreateDTO.City;
            member.UpdatedAt = DateTime.Now;

            _unitOfWork.MemberRepository.Update(member);
            _unitOfWork.SaveChanges();

            return true;
        }

        // Delete Member
        public bool DeleteMember(int memberId)
        {
            var member = _unitOfWork.MemberRepository.Get(memberId);

            if (member is null)
                return false;

            var ActiveBookings = _unitOfWork.BookingRepository
                                .GetAll(B => B.MemberId == memberId && B.Session.StartDate > DateTime.UtcNow);

            if (ActiveBookings.Any())
                return false;

            var memberShips = _unitOfWork.MemberShipRepository
                              .GetAll(ms => ms.MemberId == memberId).ToList();

            try 
            { 
                if (memberShips.Any())
                    memberShips.ForEach(ms => _unitOfWork.MemberShipRepository.Delete(ms));

                _unitOfWork.MemberRepository.Delete(member);
                _unitOfWork.SaveChanges();

                return true;
            } 
            catch 
            {
                return false;
            }
        }

        // Get Health Record By Member Id
        public HealthRecordDTO? GetHealthRecordByMemberId(int memberId) 
        {
            var memberHealthRecord = _unitOfWork.HealthRecordRebository.Get(memberId);

            if (memberHealthRecord is null)
                return null;

           return new HealthRecordDTO
            {
                Height = memberHealthRecord?.Height ?? 0,
                Weight = memberHealthRecord?.Weight ?? 0,
                BloodType = memberHealthRecord.BloodType,
                Note = memberHealthRecord.Note,
            };
        }


        #endregion

        #region Helper Methods

        private string FormatAddress(Address address)
        {
           if (address is null)
                return string.Empty;

           return $"{address.BuidingNumber} , {address.Street} , {address.City}";
        }

        private bool IsEmailExist(string email)
        {
            var exitingMember = _unitOfWork.MemberRepository
                         .GetAll(m => m.Email.ToLower() == email.ToLower());
                         
            return exitingMember is not null && exitingMember.Any();
        }

        private bool IsPhoneExist(string phone)
        {
            var exitingMember = _unitOfWork.MemberRepository
                         .GetAll(m => m.Phone.ToLower() == phone.ToLower());
            return exitingMember is not null && exitingMember.Any();
        }

        #endregion
    }
}
