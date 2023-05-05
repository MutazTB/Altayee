using Domain;
using Domain.Data;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ContactUsRepo : IContactUsRepo<ContactUs>
    {
        private readonly AltayeeDBContext _context;
        public ContactUsRepo(AltayeeDBContext context)
        {
            _context = context;
        }

        public async Task<int> Add(ContactUs REQ)
        {
            _context.Entry(REQ).State = EntityState.Added;
            
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(Guid REQ)
        {
            ContactUs contactUs = await GetDataRecord(REQ);
            _context.Entry(contactUs).State = EntityState.Deleted;
            return await _context.SaveChangesAsync();
        }

        public async Task<IList<ContactUs>> GetDataList()
        {
            return await _context.ContactUs.ToListAsync();
        }

        public async Task<ContactUs> GetDataRecord(Guid REQ)
        {
            return await _context.ContactUs.FindAsync(REQ);
        }

        public async Task<ContactUs> Update(Guid Id, ContactUs REQ)
        {
            throw new NotImplementedException();
        }
    }
}
