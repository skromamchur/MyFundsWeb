using Application.Handlers.Interfaces;
using Domain.Models;
using Domain.Services.Core;
using Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.Core
{
    public class ApplicationGoalHandler : IApplicationGoalHandler
    {
        private readonly IGoalService _goalService;
        public ApplicationGoalHandler(IGoalService goalService)
        {
            _goalService = goalService;
        }

        public void OnCreateGoal(decimal finalvalue, string name, int userId)
        {
            _goalService.AddGoal(new Domain.Models.Goal()
            {
                FinalValue = finalvalue,
                CurrentValue = 0,
                Name = name,
                Currency = "usd",
                UserId = userId
            });
        }

        public List<Goal> GetUserGoals(int UserId) {
            return _goalService.GetUserGoals(UserId);
        }

        public void OnAddMoneyToGoal(int goalId, decimal money)
        {
            _goalService.AddMoneyToGoal(goalId, money);
        }

        public void OnUpdateGoal(int goalId, string name, decimal finalValue, decimal currentValue)
        {
            _goalService.UpdateGoal(goalId, name, finalValue, currentValue);
        }

        public void OnDeleteGoal(int goalId)
        {
            _goalService.DeleteGoal(goalId);
        }
    }
}
