using Helpers;
using PantheonCRMSync.Data;
using PantheonCRMSync.Models;
using System;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web.Http;

namespace PantheonCRMSync.Controllers
{
    public class RacunDobavljacaController : ApiController
    {
        string connString = ConnectionHelper.GetSqlConnectionString();

        [HttpPost]
        public Response RacunDobavljacaPost([FromBody] RacunDobavljaca r)
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

                    db.OS_RacunDobavljacaPost(r.CRMDocumentId, r.DocType, r.Date, r.Issuer, r.Currency, r.FXRate, r.Doc1, r.DateDoc1, r.DateVAT, r.DateDue, r.UserId, error, kljuc);
                    dokument = kljuc.Value.ToString();
                    if (error.Value.ToString() == "OK" && dokument != "")
                    {
                        int errcount = 0;
                        foreach (var poz in r.Pozicije.OrderBy(x => x.No))
                        {
                            db.OS_RacunDobavljacaPozPost(dokument, poz.No, poz.Ident, poz.Qty, poz.Price, poz.CostDrv, errorpoz);
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
