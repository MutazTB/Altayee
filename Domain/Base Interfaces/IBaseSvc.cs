using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Base_Interfaces
{
    public interface IBaseSvc<T>
    {
        Task<IList<T>> GetDataList();
        Task<T> GetDataRecord(Guid REQ);
        Task<ReturnResponse> Add(T REQ);
        Task<T> Update(Guid Id, T REQ);
        Task<ReturnResponse> Delete(Guid REQ);
    }
}
