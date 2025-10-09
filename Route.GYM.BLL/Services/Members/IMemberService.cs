using Route.GYM.BLL.DTOs.MemberDTO;

namespace Route.GYM.BLL.Services.Members
{
    public interface IMemberService
    {
        // Get All Members
        IEnumerable<MembersDTO> GetAllMembers();

        // Get Member By Id
        MemberDetailsDTO? GetMemberById(int id);

        //Add Member
        bool AddMember(CeateMemberDTO ceateMemberDTO);

        // Get Member To Update
        UpdateMemberDTO? GetMemberToUpdate(int memberId);

        // Update Member
        bool UpdateMember(int id, UpdateMemberDTO memberCreateDTO);

        // Delete Member
        bool DeleteMember(int memberId);

        // Get Health Record By Member Id
        HealthRecordDTO? GetHealthRecordByMemberId(int memberId);

    }
}
