namespace HyrLya.Domain.Entities.Abstract
{
    public abstract class Entity
    {
        public Guid Id { get; private set; } = Guid.NewGuid();

        protected Entity() { }
    }
}
