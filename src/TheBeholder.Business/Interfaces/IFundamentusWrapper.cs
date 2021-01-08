using System.Collections.Generic;
using System.Threading.Tasks;
using TheBeholder.Business.Models;

namespace TheBeholder.Business.Interfaces
{
    public interface IFundamentusWrapper
    {
        Task<IEnumerable<Fundamentus>> GetPageDataAsync();
    }
}