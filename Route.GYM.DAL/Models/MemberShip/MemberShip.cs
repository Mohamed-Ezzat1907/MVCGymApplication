using Route.GYM.DAL.Models.Member;
using Route.GYM.DAL.Models.Plan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Route.GYM.DAL.Models.MemberShip
{
    public class MemberShip : BaseEntity
    {
        public DateTime EndDate { get; set; }
        public string Status {
            get
            {
                if (EndDate >= DateTime.Now)
                    return "Active";
                else
                    return "Expired";
            } 
        }
        public int PlanId { get; set; }
        public plan Plan { get; set; }

        public int MemberId { get; set; }
        public Member.Member Member { get; set; }


    }
}
