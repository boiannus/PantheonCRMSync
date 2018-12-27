using Helpers;
using PantheonCRMSync.Data;
using PantheonCRMSync.Models;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web.Http;

namespace PantheonCRMSync.Controllers
{
    public class RacunDobavljacaController : ApiController
    {
        string connString = ConnectionHelper.GetSqlConnectionString();

        [HttpPost]
        public string RacunDobavljacaPost([FromBody] RacunDobavljaca r)
        {
            using (DBEntities db = new DBEntities())
            {
                try
                {
                    string dokument;
                    db.Database.Connection.ConnectionString = connString;

                    ObjectParameter kljuc = new ObjectParameter("kljuc", typeof(string));
                    ObjectParameter error = new ObjectParameter("error", typeof(string));

                    db.OS_RacunDobavljacaPost(r.CRMDocumentId, r.DocType, r.Date, r.Issuer, r.Currency, r.FXRate, r.Doc1, r.DateDoc1, r.DateVAT, r.DateDue, error, kljuc);
                    dokument = kljuc.Value.ToString();
                    if (error.Value.ToString() == "OK" && dokument != "")
                    {
                        foreach (var poz in r.Pozicije.OrderBy(x => x.No))
                        {
                            db.OS_RacunDobavljacaPozPost(dokument, poz.No, poz.Ident, poz.Qty, poz.Price, poz.Dept, poz.CostDrv, error);
                        }
                        return dokument;
                    }
                    else
                    {
                        return "";
                    }
                }
                catch
                {
                    return "";
                }
            }
        }
    }
}
