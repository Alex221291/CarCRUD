using CarCRUD.Data;
using CarCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace CarCRUD.Service
{
    public interface ICarService
    {
        Task<IEnumerable<Cars?>> GetCars();
        Task<Cars?> GetById(int carId);
        Task Create(Cars car);
        Task Edit(Cars car);
        Task Remove(int carId);
    }
    public class UserService : ICarService
    {
        private readonly AppDbContext _db;
        public UserService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Cars?>> GetCars()
        {
            return await _db.Cars.ToListAsync();
        }

        public async Task<Cars?> GetById(int carId)
        {
            return await _db.Cars.FirstOrDefaultAsync(u => u.Id == carId);
        }

        public async Task Create(Cars car)
        {
            await _db.Cars.AddAsync(car);
            await _db.SaveChangesAsync();
        }

        public async Task Edit(Cars car)
        {
            _db.Cars.Update(car);
            await _db.SaveChangesAsync();
        }

        public async Task Remove(int carId)
        {
            _db.Cars.Remove(new Cars { Id = carId });
            await _db.SaveChangesAsync();
        }
    }
}
