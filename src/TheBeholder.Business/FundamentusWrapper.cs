using System.Collections.Generic;
using System.Threading.Tasks;
using AngleSharp;
using TheBeholder.Business.Interfaces;
using TheBeholder.Business.Models;

namespace TheBeholder.Business
{

    public class FundamentusWrapper : IFundamentusWrapper
    {
        const string Url = @"https://www.fundamentus.com.br/resultado.php";

        public async Task<IEnumerable<Fundamentus>> GetPageDataAsync()
        {

            var config = Configuration.Default.WithDefaultLoader();
            var context = BrowsingContext.New(config);
            var document = await context.OpenAsync(Url);

            var tableRows = document.QuerySelector("tbody").QuerySelectorAll(">tr");

            if (tableRows == null)
            {
                //TODO: cortar o  fluxo e alertar
            }

            var rows = new List<Fundamentus>();

            foreach (var row in tableRows)
            {
                var columns = row.QuerySelectorAll(">td");

                var fundamentus = new Fundamentus();
                fundamentus.Papel = columns[0].TextContent;
                fundamentus.Cotacao = columns[1].TextContent;
                fundamentus.PL = columns[2].TextContent;
                fundamentus.PVP = columns[3].TextContent;
                fundamentus.PSR = columns[4].TextContent;
                fundamentus.DivYield = columns[5].TextContent;
                fundamentus.PAtivo = columns[6].TextContent;
                fundamentus.PCapGiro = columns[7].TextContent;
                fundamentus.PEBIT = columns[8].TextContent;
                fundamentus.PAtivCircLiq = columns[9].TextContent;
                fundamentus.EVEBIT = columns[10].TextContent;
                fundamentus.EVEBITDA = columns[11].TextContent;
                fundamentus.MrgEbit = columns[12].TextContent;
                fundamentus.MrgLiq = columns[13].TextContent;
                fundamentus.LiqCorr = columns[14].TextContent;
                fundamentus.ROIC = columns[15].TextContent;
                fundamentus.ROE = columns[16].TextContent;
                fundamentus.Liq2meses = columns[17].TextContent;
                fundamentus.PatrimLiq = columns[18].TextContent;
                fundamentus.DivBrutPatrim = columns[19].TextContent;
                fundamentus.CrescRec5a = columns[20].TextContent;

                rows.Add(fundamentus);

            }

            return rows;
        }

    }
}