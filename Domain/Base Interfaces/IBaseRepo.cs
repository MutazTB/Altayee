using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Base_Interfaces
{
    public interface IBaseRepo<T>
    {
        Task<IList<T>> GetDataList();
        Task<T> GetDataRecord(Guid REQ);
        Task<int> Add(T REQ);
        Task<T> Update(Guid Id ,T REQ);
        Task<int> Delete(Guid REQ);
    }
}
