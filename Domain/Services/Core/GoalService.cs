using Domain.Models;
using Domain.Repositories;
using Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain.Services.Core
{
    public class GoalService : IGoalService
    {
        private readonly IGoalRepository _goalRepository;

        public GoalService(IGoalRepository goalRepository)
        {
            _goalRepository = goalRepository;
        }

        public void AddGoal(Goal goal) {
            _goalRepository.AddGoal(goal);
        }

        public void UpdateGoal(int goalId, string name, decimal finalValue, decimal currentValue)
        {
            var existingGoal = _goalRepository.GetGoalById(goalId);

            if (existingGoal != null)
            {
                existingGoal.Name = name;
                existingGoal.FinalValue = finalValue;
                existingGoal.CurrentValue = currentValue;

                _goalRepository.UpdateGoal(existingGoal);
            }
        }

        public void AddMoneyToGoal(int goalId, decimal money)
        {
            Goal goal = _goalRepository.GetGoalById(goalId);

            if (goal != null)
            {
                goal.CurrentValue += money;
                _goalRepository.UpdateGoal(goal);
            }
            else
            {
                throw new ArgumentException($"Goal with ID {goalId} not found.");
            }
        }

        public List<Goal> GetUserGoals(int UserId)
        {
           return _goalRepository.GetUserGoals(UserId);
        }

        public void DeleteGoal(int goalId)
        {
            _goalRepository.DeleteGoal(goalId);
        }
    }
}
