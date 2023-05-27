using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.Interfaces
{
    public interface IApplicationGoalHandler
    {
        public void OnCreateGoal(decimal finalvalue, string name, int userId);

        public void OnUpdateGoal(int goalId, string name, decimal finalValue, decimal currentValue);

        public void OnAddMoneyToGoal(int goalId, decimal money);

        public List<Goal> GetUserGoals(int UserId);

        void OnDeleteGoal(int goalId);
    }
}
