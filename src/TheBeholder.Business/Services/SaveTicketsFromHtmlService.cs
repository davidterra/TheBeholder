using System.Threading.Tasks;
using TheBeholder.Business.Interfaces;

namespace TheBeholder.Business.Services
{

    public class SaveTicketsFromHtmlService : ISaveTicketsFromHtmlService
    {
        private readonly IHtmlWrapperFacade _htmlWrapper;
        private readonly IDetailRepository _detailRepository;
        public SaveTicketsFromHtmlService(IHtmlWrapperFacade htmlWrapper, IDetailRepository detailRepository)
        {
            _detailRepository = detailRepository;
            _htmlWrapper = htmlWrapper;
        }

        public async Task SaveAsync()
        {
            var data = await _htmlWrapper.GetDataAsync();

            await _detailRepository.InsertAsync(data);
        }
    }
}