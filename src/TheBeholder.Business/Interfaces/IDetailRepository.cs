using System.Threading.Tasks;
using TheBeholder.Business.Models;

namespace TheBeholder.Business.Interfaces
{
    public interface IDetailRepository : IRepository<Detail> 
    { 
         Task<Detail> GetByTicketAsync(string ticket);
    }
}