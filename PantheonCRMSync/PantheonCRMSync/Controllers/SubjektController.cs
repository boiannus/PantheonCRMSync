using Helpers;
using PantheonCRMSync.Data;
using PantheonCRMSync.Models;
using System.Data.Entity.Core.Objects;
using System.Web.Http;

namespace PantheonCRMSync.Controllers
{
    public class SubjektController : ApiController
    {
        string connString = ConnectionHelper.GetSqlConnectionString();

        [HttpPost]
        public int SubjektPost([FromBody]Subjekt s)
        {
            using (DBEntities db = new DBEntities())
            {
                try
                {
                    db.Database.Connection.ConnectionString = connString;

                    ObjectParameter qid = new ObjectParameter("QId", typeof(int));
                    ObjectParameter error = new ObjectParameter("error", typeof(string));

                    db.OS_SubjektPost(s.Subject, s.Name2, s.Address, s.Post, s.Country, s.Code, s.RegNo, s.Buyer, s.WayOfSale, s.Currency, s.Supplier, s.SuppSaleMet, s.SuppCurr, qid, error);
                    return (int)qid.Value;
                }
                catch
                {
                    return 0;
                }
            }
        }
    }
}
