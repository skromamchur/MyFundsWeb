using Domain.Models;
using System.Collections.Generic;

namespace Domain.Repositories
{
    public interface IGoalRepository
    {
        void AddGoal(Goal goal);
        List<Goal> GetUserGoals(int userId);
        Goal GetGoalById(int goalId);
        void UpdateGoal(Goal goal);
        void DeleteGoal(int goalId);
    }
}
