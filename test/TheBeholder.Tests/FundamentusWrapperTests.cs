using System;
using System.Threading.Tasks;
using TheBeholder.Business;
using Xunit;

namespace TheBeholder.Tests
{
    public class FundamentusWrapperTests
    {
        [Fact]
        public async Task Should_be_list_all_elements()
        {
            var wrapper = new FundamentusWrapper();

           await wrapper.GetPageDataAsync();

        }
        
    }
}
