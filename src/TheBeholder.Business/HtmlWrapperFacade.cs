using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheBeholder.Business.Interfaces;
using TheBeholder.Business.Models;

namespace TheBeholder.Business
{
    public class HtmlWrapperFacade : IHtmlWrapperFacade
    {
        private readonly IFundamentusWrapper _wrapper;
        public HtmlWrapperFacade(IFundamentusWrapper wrapper) => _wrapper = wrapper;

        public async Task<IEnumerable<Detail>> GetDataAsync()
        {
            IEnumerable<Fundamentus> data = await _wrapper.GetPageDataAsync();

            var details = new List<Detail>();

            foreach (var item in data)
            {
                var detail = new Detail(item.Papel);
                detail.Cotacao = item.Cotacao.ToMonetary();
                detail.PL = item.PL.ToMonetary();
                detail.PVP = item.PVP.ToMonetary();
                detail.PSR = item.PSR.ToMonetary();
                detail.DivYield = item.DivYield.ToMonetary();
                detail.PAtivo = item.PAtivo.ToMonetary();
                detail.PCapGiro = item.PCapGiro.ToMonetary();
                detail.PEBIT = item.PEBIT.ToMonetary();
                detail.PAtivCircLiq = item.PAtivCircLiq.ToMonetary();
                detail.EVEBIT = item.EVEBIT.ToMonetary();
                detail.EVEBITDA = item.EVEBITDA.ToMonetary();
                detail.MrgEbit = item.MrgEbit.ToMonetary();
                detail.MrgLiq = item.MrgLiq.ToMonetary();
                detail.LiqCorr = item.LiqCorr.ToMonetary();
                detail.ROIC = item.ROIC.ToMonetary();
                detail.ROE = item.ROE.ToMonetary();
                detail.Liq2meses = item.Liq2meses.ToMonetary();
                detail.PatrimLiq = item.PatrimLiq.ToMonetary();
                detail.DivBrutPatrim = item.DivBrutPatrim.ToMonetary();
                detail.CrescRec5a = item.CrescRec5a.ToMonetary();

                details.Add(detail);
            }

            return details;
        }
    }
}