using Helpers;
using PantheonCRMSync.Data;
using PantheonCRMSync.Models;
using System.Data.Entity.Core.Objects;
using System.Web.Http;

namespace PantheonCRMSync.Controllers
{
    public class StrnController : ApiController
    {
        string connString = ConnectionHelper.GetSqlConnectionString();

        [HttpPost]
        public int StrnPost([FromBody]Strn s)
        {
            using (DBEntities db = new DBEntities())
            {
                try
                {
                    db.Database.Connection.ConnectionString = connString;

                    ObjectParameter qid = new ObjectParameter("QId", typeof(int));
                    ObjectParameter error = new ObjectParameter("error", typeof(string));

                    db.OS_StrnPost(s.CostDrv, s.CostName, s.Classif, s.Consignee, s.Dept, qid, error);
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
