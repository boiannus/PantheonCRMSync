using System.Collections.Generic;

namespace PantheonCRMSync.Models
{
    public class RacunDobavljaca
    {
        public string CRMDocumentId { get; set; }
        public string DocType { get; set; }
        public string Date { get; set; }
        public string Issuer { get; set; }
        public string Currency { get; set; }
        public decimal FXRate { get; set; }
        public string Doc1 { get; set; }
        public string DateDoc1 { get; set; }
        public string DateVAT { get; set; }
        public string DateDue { get; set; }
        public List<RacunDobavljacaPoz> Pozicije { get; set; }
    }

    public class RacunDobavljacaPoz
    {
        public int No { get; set; }
        public string Ident { get; set; }
        public decimal Qty { get; set; }
        public decimal Price { get; set; }
        public string Dept { get; set; }
        public string CostDrv { get; set; }
    }
}