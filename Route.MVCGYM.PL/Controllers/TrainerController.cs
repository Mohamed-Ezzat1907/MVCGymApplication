using Microsoft.AspNetCore.Mvc;
using Route.GYM.BLL.DTOs.TrainerDTO;
using Route.GYM.BLL.Services.Trainers;
using System;

namespace Route.MVCGYM.PL.Controllers
{
    public class TrainerController : Controller
    {
        #region Fields

        private readonly ITrainerService _trainerService;
        private readonly ILogger<TrainerController> _logger;
        private readonly IWebHostEnvironment _environment;

        #endregion

        #region Constructor

        public TrainerController(ITrainerService trainerService,
                                IWebHostEnvironment environment,
                                ILogger<TrainerController> logger)
        {
            _trainerService = trainerService;
            _logger = logger;
            _environment = environment;
        }

        #endregion

        #region Actions

        // INDEX
        [HttpGet]
        public IActionResult Index()
        {
            var trainers = _trainerService.GetAllTrainers();
            return View(trainers);
        }

        //  DETAILS
        [HttpGet]
        public IActionResult TrainerDetails(int id)
        {
            var trainer = _trainerService.GetTrainerById(id);
            if (trainer == null)
            {
                TempData["ErrorMessage"] = "Trainer not found!";
                return RedirectToAction(nameof(Index));
            }

            return View(trainer);
        }

        // CREATE (GET)
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // CREATE (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateTrainerDTO input)
        {
            if (!ModelState.IsValid)
            {
                return View(input);
            }

            bool result = _trainerService.AddTrainer(input);
            if (result)
            {
                TempData["SuccessMessage"] = "Trainer created successfully!";
                return RedirectToAction(nameof(Index));
            }

            TempData["ErrorMessage"] = "Failed to create trainer.";
            return View(input);
        }

        //  EDIT (GET)
        [HttpGet]
        public IActionResult TrainerEdit(int id)
        {
            var trainer = _trainerService.GetTrainerToUpdate(id);
            if (trainer == null)
            {
                TempData["ErrorMessage"] = "Trainer not found!";
                return RedirectToAction(nameof(Index));
            }

            return View(trainer);
        }

        //  EDIT (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult TrainerEdit(int id, UpdateTrainerDTO input)
        {
            if (!ModelState.IsValid)
                return View(input);

            bool result = _trainerService.UpdateTrainer(id, input);

            if (result)
            {
                TempData["SuccessMessage"] = "Trainer updated successfully!";
                return RedirectToAction(nameof(Index));
            }

            TempData["ErrorMessage"] = "Failed to update trainer.";
            return View(input);
        }

        // DELETE
        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
            {
                TempData["ErrorMessage"] = "Invalid trainer ID.";
                return RedirectToAction(nameof(Index));
            }

            try
            {
                bool deleted = _trainerService.DeleteTrainer(id);
                if (deleted)
                {
                    TempData["SuccessMessage"] = "Trainer deleted successfully!";
                }
                else
                {
                    TempData["ErrorMessage"] = "Failed to delete trainer.";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error deleting trainer: {ex.Message}");
                TempData["ErrorMessage"] = "Error occurred while deleting trainer.";
            }

            return RedirectToAction(nameof(Index));
        } 

        #endregion
    }
}