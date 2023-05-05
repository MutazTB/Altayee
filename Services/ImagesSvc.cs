using Domain;
using Domain.Base_Interfaces;
using Repository.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ImagesSvc : IImagesSvc<Images>
    {
        private readonly IImagesRepo<Images> _images;
        public ImagesSvc(IImagesRepo<Images> Images)
        {
            _images = Images;
        }

        public async Task<ReturnResponse> Add(Images REQ)
        {
            ReturnResponse response = new ReturnResponse();
            if (await _images.Add(REQ) > 0)
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
            if (await _images.Delete(REQ) > 0)
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

        public async Task<IList<Images>> GetDataList()
        {
            return await _images.GetDataList();
        }

        public async Task<Images> GetDataRecord(Guid REQ)
        {
            return await _images.GetDataRecord(REQ);
        }

        public async Task<Images> Update(Guid Id, Images REQ)
        {
            return await _images.Update(Id, REQ);
        }
    }
}
