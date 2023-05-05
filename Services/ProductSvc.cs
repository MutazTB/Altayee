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
    public class ProductSvc : IProductsSvc<Products>
    {
        private readonly IProductsRepo<Products> _products;
        private readonly IImagesRepo<Images> _images;
        private readonly IRelatedToRepo<Relateds> _relateds;
        private readonly ITypesRepo<Types> _types;


        public ProductSvc(IProductsRepo<Products> Products , IImagesRepo<Images> images, IRelatedToRepo<Relateds> relateds , ITypesRepo<Types> types)
        {
            _products = Products;
            _images = images;
            _relateds = relateds;
            _types = types;
        }

        public async Task<ReturnResponse> Add(Products REQ)
        {
            //foreach (var item in REQ.Images)
            //{
            //    await _images.Add(item);
            //}
            //foreach (var item in REQ.Types)
            //{
            //    await _types.Add(item);
            //}
            //foreach (var item in REQ.Relateds)
            //{
            //    await _relateds.Add(item);
            //}
            //return await _products.Add(REQ);
            ReturnResponse response = new ReturnResponse();
            if (await _products.Add(REQ) > 0)
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
            //var productToDelete = await _products.GetDataRecord(REQ);
            //if(productToDelete != null)
            //{
            //    foreach (var item in productToDelete.Images)
            //    {
            //        await _images.Delete(item.Id);
            //    }
            //    foreach (var item in productToDelete.Relateds)
            //    {
            //        await _relateds.Delete(item.Id);
            //    }
            //    foreach (var item in productToDelete.Types)
            //    {
            //        await _types.Delete(item.Id);
            //    }
            //    await _products.Delete(REQ);
            ReturnResponse response = new ReturnResponse();
            if (await _products.Delete(REQ) > 0)
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
        

        public async Task<IList<Products>> GetDataList()
        {
            return await _products.GetDataList();
        }

        public async Task<Products> GetDataRecord(Guid REQ)
        {
            return await _products.GetDataRecord(REQ);
        }

        public async Task<Products> Update(Guid Id, Products REQ)
        {
            return await _products.Update(Id, REQ);
        }
    }
}
