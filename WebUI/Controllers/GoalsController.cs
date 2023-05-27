using Application.Handlers.Core;
using Application.Handlers.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class GoalsController : Controller
    {
        private readonly IApplicationGoalHandler _goalHandler;

        public GoalsController(IApplicationGoalHandler goalHandler)
        {
            _goalHandler = goalHandler;
        }

        public IActionResult Index()
        {
            var userId = Convert.ToInt32(User.FindFirstValue("Id"));
            var userGoals = _goalHandler.GetUserGoals(userId);
            var viewModel = new GoalViewModel
            {
                Goals = userGoals
            };
            return View(viewModel);
        }

        public ActionResult CreateGoal(GoalViewModel model)
        {
            _goalHandler.OnCreateGoal(model.FinalValue, model.Name, Convert.ToInt32(User.FindFirstValue("Id")));
            return RedirectToAction("Index");
        }

        public ActionResult AddMoneyToGoal(GoalViewModel model)
        {
            _goalHandler.OnAddMoneyToGoal(model.GoalId, model.AddMoney);
            return RedirectToAction("Index");
        }

        public ActionResult UpdateGoal(GoalViewModel model)
        {
            _goalHandler.OnUpdateGoal(model.GoalId, model.updateGoalForm.Name, model.updateGoalForm.FinalValue, model.updateGoalForm.CurrentValue);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteGoal(int goalId)
        {
            _goalHandler.OnDeleteGoal(goalId);
            return RedirectToAction("Index");
        }
    }
}
