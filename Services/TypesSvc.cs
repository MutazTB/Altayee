using Domain.Base_Interfaces;
using Domain;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class TypesSvc : IBaseSvc<Types>
    {
        private readonly ITypesRepo<Types> _types;
        public TypesSvc(ITypesRepo<Types> Types)
        {
            _types = Types;
        }

        public async Task<ReturnResponse> Add(Types REQ)
        {
            ReturnResponse response = new ReturnResponse();
            if (await _types.Add(REQ) > 0)
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
            if (await _types.Delete(REQ) > 0)
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

        public async Task<IList<Types>> GetDataList()
        {
            return await _types.GetDataList();
        }

        public async Task<Types> GetDataRecord(Guid REQ)
        {
            return await _types.GetDataRecord(REQ);
        }

        public async Task<Types> Update(Guid Id, Types REQ)
        {
            return await _types.Update(Id, REQ);
        }
    }
}
