using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NESReportsDAL
{
    public class CommonDAL
    {
        public static string DataTableToJsonstring(MySqlCommand cmd)
        {
            using (MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                sqlDataAdapter.Fill(dt);

                if (dt != null && dt.Rows.Count > 0)
                {
                    return JsonConvert.SerializeObject(dt);
                }
            }

            return null;
        }

    }
}
