using Microsoft.EntityFrameworkCore;

namespace APIII.Models
{
    public class Repository : IRepository
    {
        private readonly AppDbContext _appDbContext;

        public Repository(AppDbContext appDbContext)
        {
                _appDbContext = appDbContext;
        }

        public void Add<T>(T entity) where T : class
        {
            _appDbContext.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _appDbContext.Remove(entity);
        }
        public async Task<Customer[]> GetAllCustomersAsync()
        {
            IQueryable<Customer> query = _appDbContext.Customers;
            return await query.ToArrayAsync();
        }
        public async Task<Customer> GetCustomerAsync(int custId)
        {
            IQueryable<Customer> query = _appDbContext.Customers.Where(c => c.CustId == custId);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Guide> GetGuideAsync(string guideNum)
        {
            IQueryable<Guide> query = _appDbContext.Guides.Where(c => c.GuideNum == guideNum);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Trip> GetTripAsync(int tripId)
        {
            IQueryable<Trip> query = _appDbContext.Trips.Include(g => g.Guides).Where(c => c.TripId == tripId);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _appDbContext.SaveChangesAsync() > 0;
        }
    }
}
