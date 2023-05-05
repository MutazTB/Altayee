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
    public class ProductsRepo : IProductsRepo<Products>
    {
        private readonly AltayeeDBContext _context;
        public ProductsRepo(AltayeeDBContext context)
        {
            _context = context;
        }

        public async Task<int> Add(Products REQ)
        {
            _context.Entry(REQ).State = EntityState.Added;
            
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(Guid REQ)
        {
            Products products = await GetDataRecord(REQ);
            _context.Entry(products).State = EntityState.Deleted;
            return await _context.SaveChangesAsync();
        }

        public async Task<IList<Products>> GetDataList()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Products> GetDataRecord(Guid REQ)
        {
            return await _context.Products.FindAsync(REQ);
        }

        public async Task<Products> Update(Guid Id, Products REQ)
        {
            var updateProducts = new Products
            {
                Id = Id,                
                NameEn = REQ.NameEn,
                NameAr = REQ.NameAr,
                IsFeatured= REQ.IsFeatured,
                DescriptionEn = REQ.DescriptionEn,
                DescriptionAr = REQ.DescriptionAr,
                Size = REQ.Size,
                Price = REQ.Price,
                BrandId= REQ.BrandId,
                AltImage = REQ.AltImage,
                BaseImage= REQ.BaseImage,
            };
            _context.Entry(REQ).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return updateProducts;
        }
    }
}
