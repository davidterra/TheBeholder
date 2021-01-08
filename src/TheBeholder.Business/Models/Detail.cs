using System;

namespace TheBeholder.Business.Models
{
    public class Detail : EntityBase
{
        public Detail(string ticket)
        {
            Ticket = ticket;
        }
        
        public string Ticket { get; set; }
        public decimal Cotacao { get; set; }
        public decimal PL { get; set; }
        public decimal PVP { get; set; }
        public decimal PSR { get; set; }
        public decimal DivYield { get; set; }
        public decimal PAtivo { get; set; }
        public decimal PCapGiro { get; set; }
        public decimal PEBIT { get; set; }
        public decimal PAtivCircLiq { get; set; }
        public decimal EVEBIT { get; set; }
        public decimal EVEBITDA { get; set; }
        public decimal MrgEbit { get; set; }
        public decimal MrgLiq { get; set; }
        public decimal LiqCorr { get; set; }
        public decimal ROIC { get; set; }
        public decimal ROE { get; set; }
        public decimal Liq2meses { get; set; }
        public decimal PatrimLiq { get; set; }
        public decimal DivBrutPatrim { get; set; }
        public decimal CrescRec5a { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}