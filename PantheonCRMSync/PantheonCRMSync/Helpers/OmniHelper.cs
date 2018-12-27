using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Configuration;
using System.Web;

namespace OmniMCloudPantheonWebApi.Helpers
{
    public static class OmniHelper
    {
        private static string GetUrlParams(string url, string api)
        {
            var uriBuilder = new UriBuilder(url);
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query["client"] = ConfigurationManager.AppSettings["client"];
            query["software"] = ConfigurationManager.AppSettings["software"];
            uriBuilder.Query = query.ToString();
            string apiURL = api + uriBuilder.Query;
            return apiURL;
        }

        public static void Logger(string lines)
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "errorLog.txt", true);
            try
            {                
                file.WriteLine(lines + " | " + DateTime.Now.ToString());                
            }
            finally
            {
                file.Close();
            }
        }

        public static DataTable LINQToDataTable<T>(IEnumerable<T> varlist)
        {
            DataTable dtReturn = new DataTable("tabela");

            // column names 
            PropertyInfo[] oProps = null;

            if (varlist == null) return dtReturn;

            foreach (T rec in varlist)
            {
                // Use reflection to get property names, to create table, Only first time, others will follow 
                if (oProps == null)
                {
                    oProps = ((Type)rec.GetType()).GetProperties();
                    foreach (PropertyInfo pi in oProps)
                    {
                        Type colType = pi.PropertyType;

                        if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition()
                        == typeof(Nullable<>)))
                        {
                            colType = colType.GetGenericArguments()[0];
                        }

                        dtReturn.Columns.Add(new DataColumn(pi.Name, colType));
                    }
                }

                DataRow dr = dtReturn.NewRow();

                foreach (PropertyInfo pi in oProps)
                {
                    dr[pi.Name] = pi.GetValue(rec, null) == null ? DBNull.Value : pi.GetValue
                    (rec, null);
                }

                dtReturn.Rows.Add(dr);
            }
            return dtReturn;
        }
    }
}
