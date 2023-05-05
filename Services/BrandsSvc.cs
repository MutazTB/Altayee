using Domain;
using Domain.Base_Interfaces;
using Domain.Data;
using Repository.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BrandsSvc : IBrandsSvc<Brands>
    {
        private readonly IBrandsRepo<Brands> _brands;
        public BrandsSvc(IBrandsRepo<Brands> brands)
        {
            _brands = brands;
        }

        public async Task<ReturnResponse> Add(Brands REQ)
        {
            ReturnResponse response = new ReturnResponse();
            if (await _brands.Add(REQ) > 0)
            {
                response.IsSuccess = true;
                response.Code = "200";
                response.Status = Status.Success;
                response.Message = "Successful";
            }
            else
            {
                response.IsSuccess = false;
                response.Code = "400";
                response.Status = Status.Error;
                response.Message = "Cannot save this item now \n Please try again later ";
            }
            return response;
        }

        public async Task<ReturnResponse> Delete(Guid REQ)
        {
            ReturnResponse response = new ReturnResponse();
            if (await _brands.Delete(REQ) > 0)
            {
                response.IsSuccess = true;
                response.Code = "200";
                response.Status = Status.Success;
                response.Message = "Successful";
            }
            else
            {
                response.IsSuccess = false;
                response.Code = "400";
                response.Status = Status.Error;
                response.Message = "Cannot delete this item now \n Please try again later ";
            }
            return response;
            
        }

        public async Task<IList<Brands>> GetDataList()
        {
            return await _brands.GetDataList();
        }

        public async Task<Brands> GetDataRecord(Guid REQ)
        {
            return await _brands.GetDataRecord(REQ);
        }

        public async Task<Brands> Update(Guid Id, Brands REQ)
        {
            return await _brands.Update(Id, REQ);
        }
    }
}
