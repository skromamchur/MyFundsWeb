using Domain.Models;
using Domain.Repositories;
using Infrastructure.Enteties;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class GoalRepository : IGoalRepository
    {
        readonly private Context _context;

        public GoalRepository(string connectionString)
        {
            if (connectionString == null)
            {
                throw new ArgumentNullException(nameof(connectionString));
            }

            _context = new Context(connectionString);
        }

        public void AddGoal(Domain.Models.Goal goal)
        {
            _context.Goals.Add(new GoalDB()
            {
                FinalValue = goal.FinalValue,
                CurrentValue = 0,
                Name = goal.Name,
                Date = DateTime.UtcNow,
                Currency = goal.Currency,
                User = _context.Users.Find(goal.UserId)!
            });
            _context.SaveChanges();
        }


        public Goal GetGoalById(int goalId)
        {
            var goalDb = _context.Goals.FirstOrDefault(g => g.Id == goalId);

            if (goalDb == null)
            {
                return null;
            }

            var goal = new Goal
            {
                Id = goalDb.Id,
                FinalValue = goalDb.FinalValue,
                CurrentValue = goalDb.CurrentValue,
                Name = goalDb.Name,
                Date = goalDb.Date,
                Currency = goalDb.Currency,
                UserId = goalDb.User.Id
            };

            return goal;
        }

        public List<Goal> GetUserGoals(int UserId)
        {
            var user = _context.Users
                       .Include(u => u.Goals)
                       .FirstOrDefault(u => u.Id == UserId);

            List<GoalDB> goalsDb = user.Goals.ToList();

            var goals = new List<Goal>();

            foreach (var goalDb in goalsDb)
            {
                var goal = new Goal()
                {
                    FinalValue = goalDb.FinalValue,
                    CurrentValue = goalDb.CurrentValue,
                    Name = goalDb.Name,
                    Date = goalDb.Date,
                    Currency = goalDb.Currency,
                    Id = goalDb.Id
                };
                goals.Add(goal);
            }

            return goals;
        }

        public void UpdateGoal(Goal goal)
        {
            var goalDb = _context.Goals.FirstOrDefault(g => g.Id == goal.Id);

            if (goalDb != null)
            {
                goalDb.Name = goal.Name;
                goalDb.FinalValue = goal.FinalValue;
                goalDb.CurrentValue = goal.CurrentValue;
                _context.SaveChanges();
            }
        }

        public void DeleteGoal(int goalId)
        {
            var goal = _context.Goals.FirstOrDefault(g => g.Id == goalId);
            if (goal != null)
            {
                _context.Goals.Remove(goal);
                _context.SaveChanges();
            }
        }
    }
}
