using CarCRUD.Data;
using CarCRUD.Models;
using CarCRUD.ModelView;
using Microsoft.EntityFrameworkCore;

namespace CarCRUD.Service
{
    public interface IMotoService
    {
        Task<IEnumerable<MotoViewModel?>> GetMotos();
        Task<Motos?> GetById(int motoId);
        Task Create(Motos motos);
        Task Edit(Motos motos);
        Task Remove(int motoId);
    }

    public class MotoService : IMotoService
    {
        private readonly AppDbContext _db;
        public MotoService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<MotoViewModel?>> GetMotos()
        {
            return await _db.Motos.Select(u => new MotoViewModel
            {
                Name = u.Name,
                DataBuild = u.DataBuild,
                Id = u.Id
            }).Where(m=>m.Id % 2 == 0 ).ToListAsync();
        }

        public async Task<Motos?> GetById(int motoId)
        {
            return await _db.Motos.FirstOrDefaultAsync(u => u.Id == motoId);
        }

        public async Task Create(Motos moto)
        {
            await _db.Motos.AddAsync(moto);
            await _db.SaveChangesAsync();
        }

        public async Task Edit(Motos moto)
        {
            _db.Motos.Update(moto);
            await _db.SaveChangesAsync();
        }

        public async Task Remove(int motoId)
        {
            _db.Motos.Remove(new Motos { Id = motoId });
            await _db.SaveChangesAsync();
        }
    }

}
