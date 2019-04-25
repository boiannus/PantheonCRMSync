using Helpers;
using PantheonCRMSync.Data;
using PantheonCRMSync.Models;
using System;
using System.Data.Entity.Core.Objects;
using System.Web.Http;

namespace PantheonCRMSync.Controllers
{
    public class StrnController : ApiController
    {
        string connString = ConnectionHelper.GetSqlConnectionString();

        [HttpPost]
        public Response StrnPost([FromBody]Strn s)
        {
            Response response = new Response();
            using (DBEntities db = new DBEntities())
            {
                try
                {
                    db.Database.Connection.ConnectionString = connString;

                    ObjectParameter qid = new ObjectParameter("QId", typeof(int));
                    ObjectParameter error = new ObjectParameter("error", typeof(string));

                    db.OS_StrnPost(s.CostDrv, s.CostName, s.Classif, s.Consignee, s.Dept, qid, error);
                    if (error.Value.ToString() == "OK")
                    {
                        response.Id = qid.Value.ToString();
                        response.Status = "OK";
                        response.Opis = "";
                    }
                    else if (error.Value.ToString() == "Duplikat")
                    {
                        response.Id = qid.Value.ToString();
                        response.Status = "Duplikat";
                        response.Opis = "";
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
            }

            return response;
        }
    }
}
