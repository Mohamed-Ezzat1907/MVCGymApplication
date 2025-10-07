using Route.GYM.DAL.Models.Member;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Route.GYM.DAL.Persistence.Repositories.Members
{
    public interface IMemberRepository
    {
        // Get all members
        IEnumerable<Member> GetAll(bool WithNoTracking = true);

        // Get member by id
        Member? Get(int id);

        // Add member
        int Add(Member member);

        // Update member
        int Update(Member member);

        // Delete member
        int Delete(Member member);
    }
}
