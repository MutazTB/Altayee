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
    public class RelatedsRepo : IRelatedToRepo<Relateds>
    {
        private readonly AltayeeDBContext _context;
        public RelatedsRepo(AltayeeDBContext context)
        {
            _context = context;
        }

        public async Task<int> Add(Relateds REQ)
        {
            _context.Entry(REQ).State = EntityState.Added;
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(Guid REQ)
        {
            Relateds relateds = await GetDataRecord(REQ);
            _context.Entry(relateds).State = EntityState.Deleted;
            return await _context.SaveChangesAsync();
        }

        public async Task<IList<Relateds>> GetDataList()
        {
            return await _context.Relateds.ToListAsync();
        }

        public async Task<Relateds> GetDataRecord(Guid REQ)
        {
            return await _context.Relateds.FindAsync(REQ);
        }

        public async Task<Relateds> Update(Guid Id, Relateds REQ)
        {
            var updateRelateds = new Relateds
            {
                Id = Id,
                ProductId= REQ.ProductId,
                RelatedToProductId = REQ.RelatedToProductId,
            };
            _context.Entry(REQ).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return updateRelateds;
        }
    }
}
