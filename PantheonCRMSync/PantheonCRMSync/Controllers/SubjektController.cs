using Helpers;
using PantheonCRMSync.Data;
using PantheonCRMSync.Models;
using System;
using System.Data.Entity.Core.Objects;
using System.Web.Http;

namespace PantheonCRMSync.Controllers
{
    public class SubjektController : ApiController
    {
        string connString = ConnectionHelper.GetSqlConnectionString();

        [HttpPost]
        public Response SubjektPost([FromBody]Subjekt s)
        {
            Response response = new Response();
            using (DBEntities db = new DBEntities())
            {                
                try
                {
                    db.Database.Connection.ConnectionString = connString;

                    ObjectParameter qid = new ObjectParameter("QId", typeof(int));
                    ObjectParameter error = new ObjectParameter("error", typeof(string));

                    db.OS_SubjektPost(s.Subject, s.Name2, s.Address, s.Post, s.Country, s.Code, s.RegNo, s.Buyer, s.WayOfSale, s.Currency, s.Supplier, s.SuppSaleMet, s.SuppCurr, s.Clerk, s.SuppClerk, qid, error);
                    if (error.Value.ToString() == "OK")
                    {
                        response.Id = qid.Value.ToString();
                        response.Status = "OK";
                        response.Opis = "";
                    }
                    else if (error.Value.ToString() == "Exists")
                    {
                        response.Id = qid.Value.ToString();
                        response.Status = "Customer exists";
                        response.Opis = "Postoji kupac sa tim nazivom";
                    }
                    else
                    {
                        response.Id = "";
                        response.Status = "ERROR";
                        response.Opis = error.Value.ToString();
                    }
                }
                catch(Exception ex)
                {
                    response.Id = "";
                    response.Status = "ERROR";
                    response.Opis = ex.Message.ToString();
                }
            }

            return response;
        }
    }
}
