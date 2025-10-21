using Route.GYM.BLL.DTOs.PlanDTO;
using Route.GYM.DAL.Persistence.UnitOfWork;

namespace Route.GYM.BLL.Services.Plans
{
    public class PlanService : IPlanService
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork; 

        #endregion

        #region Constructor

        public PlanService(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Methods

        //  Get all plans
        public IEnumerable<PlanDTO> GetAllPlans()
        {
            var plans = _unitOfWork.PlanRepository.GetAll();

            if (plans is null || !plans.Any())
                return [];

            return plans.Select(p => new PlanDTO
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                DurationDays = p.DurationDays,
                Price = p.Price,
                IsActive = p.IsActive,
            }).ToList();
        }

        // Get plan by id
        public PlanDTO? GetPlanById(int id)
        {
            var plan = _unitOfWork.PlanRepository.Get(id);
            if (plan is null) return null;

            return new PlanDTO
            {
                Id = plan.Id,
                Name = plan.Name,
                Description = plan.Description,
                DurationDays = plan.DurationDays,
                Price = plan.Price,
                IsActive = plan.IsActive,
            };
        }

        //  Update a plan
        public UpdatePlanDTO? GetPlanForUpdate(int id)
        {
            var plan = _unitOfWork.PlanRepository.Get(id);
            if (plan is null || plan.IsActive == false) return null;

            return new UpdatePlanDTO
            {
                PlanName = plan.Name,
                Description = plan.Description,
                DurationDays = plan.DurationDays,
                Price = plan.Price,
            };
        }
        public bool UpdatePlan(int id, UpdatePlanDTO updatePlanDTO)
        {
            try
            {
                var plan = _unitOfWork.PlanRepository.Get(id);
                if (plan is null || HasActiveMemberShip(id))
                    return false;

                plan.Description = updatePlanDTO.Description;
                plan.Price = updatePlanDTO.Price;
                plan.DurationDays = updatePlanDTO.DurationDays;
                plan.Name = updatePlanDTO.PlanName;

                _unitOfWork.PlanRepository.Update(plan);

                return  _unitOfWork.SaveChanges() > 0;
               
            }
            catch (Exception ex) 
            {
                ex.ToString();

                return false;
            }
        }

        public bool ActivatePlan(int id)
        {
            var plan = _unitOfWork.PlanRepository.Get(id);
            if (plan is null || HasActiveMemberShip(id))
                return false;

            plan.IsActive = !plan.IsActive;
            plan.UpdatedAt = DateTime.UtcNow;

            _unitOfWork.PlanRepository.Update(plan);

            return _unitOfWork.SaveChanges() > 0;

        }

        #endregion

        #region Helper Methods

        private bool HasActiveMemberShip(int planId) 
        {
            return _unitOfWork.MemberShipRepository.GetAll(m => m.PlanId == planId && m.Status == "Active").Any();
        }

        #endregion
    }
}
