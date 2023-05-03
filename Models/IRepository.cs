namespace APIII.Models
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();
        // Customer
        Task<Customer[]> GetAllCustomersAsync();
        Task<Customer> GetCustomerAsync(int custId);

        // Trip
        Task<Trip> GetTripAsync(int tripId);

        // Guide
        Task<Guide> GetGuideAsync(string guideNum);

    }
}
