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
    public class BrandsRepo : IBrandsRepo<Brands>
    {
        private readonly AltayeeDBContext _context;
        public BrandsRepo(AltayeeDBContext context)
        {
            _context = context;
        }
        public async Task<int> Add(Brands REQ)
        {
            _context.Entry(REQ).State = EntityState.Added;
            
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(Guid REQ)
        {
            Brands brands = await GetDataRecord(REQ);
            _context.Entry(brands).State = EntityState.Deleted;
            return await _context.SaveChangesAsync();
        }

        public async Task<IList<Brands>> GetDataList()
        {
            return await _context.Brands.ToListAsync();
        }

        public async Task<Brands> GetDataRecord(Guid REQ)
        {
            return await _context.Brands.FindAsync(REQ);
        }

        public async Task<Brands> Update(Guid Id, Brands REQ)
        {
            var updateBrands = new Brands
            {
                Id = Id,
                Image = REQ.Image,
                NameEn = REQ.NameEn,
                NameAr = REQ.NameAr,                
            };
            _context.Entry(REQ).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return updateBrands;
        }
    }
}
