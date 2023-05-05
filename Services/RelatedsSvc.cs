using Domain.Base_Interfaces;
using Domain;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Interfaces;

namespace Services
{
    public class RelatedsSvc : IRelatedsSvc<Relateds>
    {
        private readonly IRelatedToRepo<Relateds> _relateds;
        public RelatedsSvc(IRelatedToRepo<Relateds> Relateds)
        {
            _relateds = Relateds;
        }

        public async Task<ReturnResponse> Add(Relateds REQ)
        {
            ReturnResponse response = new ReturnResponse();
            if (await _relateds.Add(REQ) > 0)
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
            if (await _relateds.Delete(REQ) > 0)
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

        public async Task<IList<Relateds>> GetDataList()
        {
            return await _relateds.GetDataList();
        }

        public async Task<Relateds> GetDataRecord(Guid REQ)
        {
            return await _relateds.GetDataRecord(REQ);
        }

        public async Task<Relateds> Update(Guid Id, Relateds REQ)
        {
            return await _relateds.Update(Id, REQ);
        }
    }
}
