using Domain;
using Domain.Data;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ImagesRepo : IImagesRepo<Images>
    {
        private readonly AltayeeDBContext _context;
        public ImagesRepo(AltayeeDBContext context)
        {
            _context = context;
        }

        public async Task<int> Add(Images REQ)
        {
            _context.Entry(REQ).State = EntityState.Added;
            
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(Guid REQ)
        {
            Images images = await GetDataRecord(REQ);
            _context.Entry(images).State = EntityState.Deleted;
            return await _context.SaveChangesAsync();
        }

        public async Task<IList<Images>> GetDataList()
        {
            return await _context.Images.ToListAsync();
        }

        public async Task<Images> GetDataRecord(Guid REQ)
        {
            return await _context.Images.FindAsync(REQ);
        }

        public async Task<Images> Update(Guid Id, Images REQ)
        {
            var updateImages = new Images
            {
                Id = Id,
                ImageName = REQ.ImageName,
                ProductId = REQ.ProductId,                
            };
            _context.Entry(REQ).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return updateImages;
        }
    }
}
