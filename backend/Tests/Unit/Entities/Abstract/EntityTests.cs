using Domain.Entities.Abstract;

namespace Tests.Unit.Entities.Abstract
{
    public class EntityTests
    {
        [Fact]
        public void Created_ShouldHaveGeneratedId()
        {
            var entity = new DummyEntity();

            Assert.NotEqual(Guid.Empty, entity.Id);
        }

        private class DummyEntity : Entity { }
    }
}
