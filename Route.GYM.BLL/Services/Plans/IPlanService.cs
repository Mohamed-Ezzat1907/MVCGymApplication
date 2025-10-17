using Route.GYM.BLL.DTOs.PlanDTO;

namespace Route.GYM.BLL.Services.Plans
{
    public interface IPlanService
    {
        // Get all plans
        IEnumerable<PlanDTO> GetAllPlans();

        // Get plan by id
        PlanDTO? GetPlanById(int id);

        // Update a plan
        UpdatePlanDTO? GetPlanForUpdate(int id);
        bool UpdatePlan(int id, UpdatePlanDTO updatePlanDTO);

        // Activate a plan
        bool ActivatePlan(int id);
    }
}
