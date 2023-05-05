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
    public class TypesRepo : ITypesRepo<Types>
    {
        private readonly AltayeeDBContext _context;
        public TypesRepo(AltayeeDBContext context)
        {
            _context = context;
        }

        public async Task<int> Add(Types REQ)
        {
            _context.Entry(REQ).State = EntityState.Added;
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(Guid REQ)
        {
            Types types = await GetDataRecord(REQ);
            _context.Entry(types).State = EntityState.Deleted;
            return await _context.SaveChangesAsync();
        }

        public async Task<IList<Types>> GetDataList()
        {
            return await _context.Types.ToListAsync();
        }

        public async Task<Types> GetDataRecord(Guid REQ)
        {
            return await _context.Types.FindAsync(REQ);
        }

        public async Task<Types> Update(Guid Id, Types REQ)
        {
            var updateTypes = new Types
            {
                Id = Id,
                ProductId = REQ.ProductId,
                Value= REQ.Value,
            };
            _context.Entry(REQ).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return updateTypes;
        }
    }
}
