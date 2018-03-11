using System;

using PersonalBudget.Models.Interfaces;

namespace PersonalBudget.Tests.Helpers
{
    public sealed class MockEntity : IEntity
    {
        public MockEntity(Guid id)
        {
            this.Id = id;
        }

        public Guid Id { get; }
    }
}
