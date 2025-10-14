using Microsoft.EntityFrameworkCore;
using RecyclingManagementAPI.Data;
using RecyclingManagementAPI.Data.Entities;
using RecyclingManagementAPI.Models;

namespace RecyclingManagementAPI.Services
{
    public class CollectionPointService
    {
        private readonly AppDbContext _context;

        public CollectionPointService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<CollectionPointViewModel>> GetAllAsync(int page, int pageSize)
        {
            var query = _context.CollectionPoints
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(cp => new CollectionPointViewModel
                {
                    Id = cp.Id,
                    Location = cp.Location,
                    Description = cp.Description,
                    Capacity = cp.Capacity,
                    CurrentWasteAmount = cp.CurrentWasteAmount
                });

            return await query.ToListAsync();
        }

        public async Task<CollectionPointViewModel> CreateAsync(CreateCollectionPointViewModel model)
        {
            var entity = new CollectionPoint
            {
                Location = model.Location,
                Description = model.Description,
                Capacity = model.Capacity,
                CurrentWasteAmount = 0
            };

            _context.CollectionPoints.Add(entity);
            await _context.SaveChangesAsync();

            return new CollectionPointViewModel
            {
                Id = entity.Id,
                Location = entity.Location,
                Description = entity.Description,
                Capacity = entity.Capacity,
                CurrentWasteAmount = entity.CurrentWasteAmount
            };
        }

        public async Task<bool> UpdateWasteAmountAsync(int id, int newAmount)
        {
            var point = await _context.CollectionPoints.FindAsync(id);
            if (point == null)
                return false;

            point.CurrentWasteAmount = newAmount;
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<CollectionPointViewModel>> GetFullCapacityPointsAsync()
        {
            return await _context.CollectionPoints
                .Where(cp => cp.CurrentWasteAmount >= cp.Capacity)
                .Select(cp => new CollectionPointViewModel
                {
                    Id = cp.Id,
                    Location = cp.Location,
                    Description = cp.Description,
                    Capacity = cp.Capacity,
                    CurrentWasteAmount = cp.CurrentWasteAmount
                })
                .ToListAsync();
        }
    }
}