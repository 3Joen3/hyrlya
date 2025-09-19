using Domain.Interfaces;

namespace Infrastructure.Persistence.Repositories
{
    public class UnitOfWork(AppDbContext context) : IUnitOfWork
    {
        private readonly AppDbContext _context = context;

        public async Task WriteChangesAsync()
            => await _context.SaveChangesAsync();
    }
}
