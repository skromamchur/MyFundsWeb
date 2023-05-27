using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Interfaces
{
    public interface IGoalService
    {
        public void AddGoal(Goal goal);

        public void UpdateGoal(int goalId, string name, decimal finalValue, decimal currentValue);

        public void AddMoneyToGoal(int goalId, decimal money);

        public List<Goal> GetUserGoals(int UserId);

        void DeleteGoal(int goalId);
    }
}
