using Helpers;
using PantheonCRMSync.Data;
using PantheonCRMSync.Models;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web.Http;

namespace PantheonCRMSync.Controllers
{
    public class FakturaController : ApiController
    {
        string connString = ConnectionHelper.GetSqlConnectionString();

        [HttpPost]
        public string FakturaPost([FromBody] Faktura f)
        {
            using (DBEntities db = new DBEntities())
            {
                try
                {
                    string dokument;
                    db.Database.Connection.ConnectionString = connString;

                    ObjectParameter kljuc = new ObjectParameter("kljuc", typeof(string));
                    ObjectParameter error = new ObjectParameter("error", typeof(string));

                    db.OS_FakturaPost(f.CRMDocumentId, f.DocType, f.Date, f.Receiver, f.Currency, f.FXRate, f.Doc1, f.DateDoc1, f.DateVAT, f.DateDue, error, kljuc);
                    dokument = kljuc.Value.ToString();
                    if (error.Value.ToString() == "OK" && dokument != "")
                    {
                        foreach (var poz in f.Pozicije.OrderBy(x => x.No))
                        {
                            db.OS_FakturaPozPost(dokument, poz.No, poz.Ident, poz.Qty, poz.Price, poz.Dept, poz.CostDrv, error);
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
