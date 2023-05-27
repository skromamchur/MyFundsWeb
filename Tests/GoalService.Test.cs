using Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class GoalServiceTest
    {
        private Mock<IGoalRepository> _goalRepositoryMock;
        private IGoalService _goalService;

        [SetUp]
        public void Setup()
        {
            _goalRepositoryMock = new Mock<IGoalRepository>();
            _goalService = new GoalService(_goalRepositoryMock.Object);
        }

        [Test]
        public void AddGoal()
        {
            var goal = new Goal { Id = 1, Name = "Test Goal", FinalValue = 1000, CurrentValue = 0 };

            _goalService.AddGoal(goal);

            _goalRepositoryMock.Verify(repo => repo.AddGoal(goal), Times.Once);
        }

        [Test]
        public void UpdateGoal()
        {
            int goalId = 1;
            string name = "Updated Goal";
            decimal finalValue = 2000;
            decimal currentValue = 500;

            var existingGoal = new Goal { Id = goalId, Name = "Original Goal", FinalValue = 1000, CurrentValue = 200 };

            _goalRepositoryMock.Setup(repo => repo.GetGoalById(goalId)).Returns(existingGoal);

            _goalService.UpdateGoal(goalId, name, finalValue, currentValue);

            _goalRepositoryMock.Verify(repo => repo.UpdateGoal(It.Is<Goal>(g =>
                g.Id == goalId &&
                g.Name == name &&
                g.FinalValue == finalValue &&
                g.CurrentValue == currentValue)), Times.Once);
        }

        [Test]
        public void DeleteGoal()
        {
            int goalId = 1;

            _goalService.DeleteGoal(goalId);

            _goalRepositoryMock.Verify(repo => repo.DeleteGoal(goalId), Times.Once);
        }

        [Test]
        public void AddsMoneyToGoal()
        {
            int goalId = 1;
            decimal money = 100;

            var existingGoal = new Goal { Id = goalId, Name = "Test Goal", FinalValue = 1000, CurrentValue = 500 };

            _goalRepositoryMock.Setup(repo => repo.GetGoalById(goalId)).Returns(existingGoal);

            _goalService.AddMoneyToGoal(goalId, money);

            decimal expectedMoney = 600;

            Assert.That(expectedMoney, Is.EqualTo(existingGoal.CurrentValue));

            _goalRepositoryMock.Verify(repo => repo.UpdateGoal(existingGoal), Times.Once);
        }
    }
}
