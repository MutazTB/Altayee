using Domain;
using Domain.Base_Interfaces;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ContactUsSvc : IBaseSvc<ContactUs>
    {
        private readonly IContactUsRepo<ContactUs> _contactUs;
        public ContactUsSvc(IContactUsRepo<ContactUs> ContactUs)
        {
            _contactUs = ContactUs;
        }

        public async Task<ReturnResponse> Add(ContactUs REQ)
        {
            ReturnResponse response = new ReturnResponse();
            if (await _contactUs.Add(REQ) > 0)
            {
                response.IsSuccess = true;
                response.Code = "200";
                response.Status = Status.Success;
            }
            else
            {
                response.IsSuccess = false;
                response.Code = "400";
                response.Status = Status.Error;
            }
            return response;            
        }

        public async Task<ReturnResponse> Delete(Guid REQ)
        {
            ReturnResponse response = new ReturnResponse();
            if (await _contactUs.Delete(REQ) > 0)
            {
                response.IsSuccess = true;
                response.Code = "200";
                response.Status = Status.Success;
            }
            else
            {
                response.IsSuccess = false;
                response.Code = "400";
                response.Status = Status.Error;
            }
            return response;
            
        }

        public async Task<IList<ContactUs>> GetDataList()
        {
            return await _contactUs.GetDataList();
        }

        public async Task<ContactUs> GetDataRecord(Guid REQ)
        {
            return await _contactUs.GetDataRecord(REQ);
        }

        public async Task<ContactUs> Update(Guid Id, ContactUs REQ)
        {
            return await _contactUs.Update(Id, REQ);
        }
    }
}
