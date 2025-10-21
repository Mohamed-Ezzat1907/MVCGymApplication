using Microsoft.AspNetCore.Mvc;
using Route.GYM.BLL.DTOs.MemberDTO;
using Route.GYM.BLL.Services.Members;

namespace Route.MVCGYM.PL.Controllers
{
    public class MemberController : Controller
    {
        #region Field

        private readonly IMemberService _memberService;
        private readonly ILogger<MemberController> _logger;
        private readonly IWebHostEnvironment _environment;

        #endregion

        #region Constructor

        public MemberController(IMemberService memberService, 
            IWebHostEnvironment environment , 
            ILogger<MemberController> logger)
        {
            _memberService = memberService;
            _logger = logger;
            _environment = environment;
        }

        #endregion

        #region Actions

        // Get all members action 
        [HttpGet]
        public IActionResult Index()
        {
            var members = _memberService.GetAllMembers();

            //TempData.Keep("ErrorMessage");

            return View(members);
        }

        // Get member details by id action
        [HttpGet]
        public IActionResult MemberDetails(int id) 
        {
            var member = _memberService.GetMemberById(id);
            if (member == null)
            {
                TempData["ErrorMessage"] = "Member not found!";
                return NotFound();
            }
            
            return View(member);
        }

        // Get Health Record by member id action
        [HttpGet]
        public IActionResult HealthRecordDetails(int id)
        {
            var member = _memberService.GetHealthRecordByMemberId(id);
            if (member == null)
            {
                TempData["ErrorMessage"] = "Health Record not found!";
                return NotFound();
            }

            return View(member);
        }

        // Create Member action
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateMember(CeateMemberDTO input)
        {
            if (!ModelState.IsValid)
            {
               ModelState.AddModelError("DataMissed", "Invalid data. Please correct the errors and try again.");
                return View(nameof(Create), input);
            }

            bool result = _memberService.AddMember(input);
            if (!result)
            {
                TempData["SuccessMessage"] = "Member created successfully!";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to create member. Please try again.";
                return View(nameof(Create), input);
            }
        }

        // Edit Member action
        [HttpGet]
        public IActionResult MemberEdit(int id)
        {
            var member = _memberService.GetMemberToUpdate(id);

            if (member is null)
            {
                TempData["ErrorMessage"] = "Member not found!";
                return NotFound();
            }

            return View(member);
        }

        [HttpPost]
        public IActionResult MemberEdit([FromRoute] int id ,UpdateMemberDTO input)
        {
            if(!ModelState.IsValid)
            {
                ModelState.AddModelError("DataMissed", "Invalid data. Please correct the errors and try again.");
                return View(input);
            }
            bool result = _memberService.UpdateMember(id , input);

            if (result)
            {
                TempData["SuccessMessage"] = "Member updated successfully!";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to update member. Please try again.";
                return View(input);
            }
        }

        // Delete Member action
        [HttpPost]
        public IActionResult Delete([FromRoute]int id)
        {
            if (id <= 0)
            {

                TempData["ErrorMessage"] = "Invalid member ID.";
                return BadRequest();
            }
            try
            {
                bool isDelted = _memberService.DeleteMember(id);
                if (isDelted)
                {
                    TempData["SuccessMessage"] = "Member deleted successfully!";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["ErrorMessage"] = "Failed to delete member. Please try again.";
                    return RedirectToAction(nameof(Index));
                }
            }
            catch(Exception ex)
            {
                if (_environment.IsDevelopment())
                {
                    _logger.LogError($"Department Can Not Be Deleted : {ex.Message}");
                    ModelState.AddModelError(String.Empty, ex.Message);
                }
                else
                {
                    _logger.LogError($"Department Can Not Be Deleted {ex}");
                }
            }
            return RedirectToAction(nameof(Delete), new { id });
        }


        #endregion


    }
}
