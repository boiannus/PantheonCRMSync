using Helpers;
using PantheonCRMSync.Data;
using PantheonCRMSync.Models;
using System;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web.Http;

namespace PantheonCRMSync.Controllers
{
    public class FakturaController : ApiController
    {
        string connString = ConnectionHelper.GetSqlConnectionString();

        [HttpPost]
        public Response FakturaPost([FromBody] Faktura f)
        {
            using (DBEntities db = new DBEntities())
            {
                Response response = new Response();
                try
                {
                    string dokument;
                    db.Database.Connection.ConnectionString = connString;

                    ObjectParameter kljuc = new ObjectParameter("kljuc", typeof(string));
                    ObjectParameter error = new ObjectParameter("error", typeof(string));
                    ObjectParameter errorpoz = new ObjectParameter("error", typeof(string));

                    db.OS_FakturaPost(f.CRMDocumentId, f.DocType, f.Date, f.Receiver, f.Currency, f.FXRate, f.Doc1, f.DateDoc1, f.Doc2, f.DateDoc2, f.DateVAT, f.DateDue, f.Statement, f.UserId, error, kljuc);
                    dokument = kljuc.Value.ToString();
                    if (error.Value.ToString() == "OK" && dokument != "")
                    {
                        int errcount = 0;
                        foreach (var poz in f.Pozicije.OrderBy(x => x.No))
                        {
                            db.OS_FakturaPozPost(dokument, poz.No, poz.Ident, poz.Qty, poz.Price, poz.CostDrv, errorpoz);
                            if (errorpoz.Value.ToString() != "OK")
                            {
                                errcount++;
                            }
                        }

                        response.Id = dokument;
                        if (errcount == 0)
                        {
                            response.Status = "OK";
                            response.Opis = "";
                        }
                        else
                        {
                            response.Status = "ERROR";
                            response.Opis = "Desila se greška pri kreiranju neke pozicije.";
                        }                        
                    }
                    else
                    {
                        response.Id = "";
                        response.Status = "ERROR";
                        response.Opis = error.Value.ToString();
                    }
                }
                catch (Exception ex)
                {
                    response.Id = "";
                    response.Status = "ERROR";
                    response.Opis = ex.Message.ToString();
                }

                return response;
            }
        }
    }
}
