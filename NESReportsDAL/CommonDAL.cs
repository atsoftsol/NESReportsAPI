using MySql.Data.MySqlClient;
using NESReportsDTO;
using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NESReportsDAL
{
    public class CommonDAL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public static AVReportDTO DataTableToJsonstring(MySqlCommand cmd)
        {
            AVReportDTO avReport = new AVReportDTO();
            using (MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                sqlDataAdapter.Fill(dt);

                if (dt != null && dt.Rows.Count > 0)
                {
                    avReport.columns = CollectColumns(dt);
                    avReport.data = JsonConvert.SerializeObject(dt);
                    avReport.sorting = "Per(%)";
                    List<string> strList = new List<string>();
                    strList.Add("Duration");
                    strList.Add("Per(%)");
                    strList.Add("Strength"); 
                    avReport.footerTotalColumns = strList;
                    return avReport;
                }
            }

            return null;
        }


        public static List<string> CollectColumns(DataTable dt)
        {
            List<string> columns = new List<string>();
            foreach (DataColumn column in dt.Columns)
            {
                columns.Add(column.ColumnName);
            }
            return columns;
        }


        // function that creates a list of an object from the given data table
        public static List<T> CreateListFromTable<T>(DataTable tbl) where T : new()
        {
            // define return list
            List<T> lst = new List<T>();

            // go through each row
            foreach (DataRow r in tbl.Rows)
            {
                // add to the list
                lst.Add(CreateItemFromRow<T>(r));
            }

            // return the list
            return lst;
        }

        // function that creates an object from the given data row
        public static T CreateItemFromRow<T>(DataRow row) where T : new()
        {
            // create a new object
            T item = new T();

            // set the item
            SetItemFromRow(item, row);

            // return 
            return item;
        }

        public static void SetItemFromRow<T>(T item, DataRow row) where T : new()
        {
            // go through each column
            foreach (DataColumn c in row.Table.Columns)
            {
                // find the property for the column
                PropertyInfo p = item.GetType().GetProperty(c.ColumnName);

                // if exists, set the value
                if (p != null && row[c] != DBNull.Value)
                {
                    p.SetValue(item, row[c], null);
                }
            }
        }

        //call stored procedure to get data.
        public static DataSet GetRecordWithExtendedTimeOut(string SPName, params MySqlParameter[] SqlPrms)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;
            DataSet ds = new DataSet();
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataAdapter da = new MySqlDataAdapter();
            MySqlConnection con = new MySqlConnection(connectionString);

            try
            {
                cmd = new MySqlCommand(SPName, con);
                cmd.Parameters.AddRange(SqlPrms);
                cmd.CommandTimeout = 240;
                cmd.CommandType = CommandType.StoredProcedure;
                da.SelectCommand = cmd;
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                return null;
            }

            return ds;
        }
         

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public static AVReportDTO OracleDataTableToJsonstring(OracleCommand cmd)
        {
            AVReportDTO avReport = new AVReportDTO();
            using (OracleDataAdapter sqlDataAdapter = new OracleDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                sqlDataAdapter.Fill(dt);

                if (dt != null && dt.Rows.Count > 0)
                {
                    avReport.columns = CollectColumns(dt);
                    avReport.data = JsonConvert.SerializeObject(dt);
                    return avReport;

                }
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CodeSeparter"></param>
        /// <returns></returns>
        public static string AddingDoubleCodes(string CodeSeparter)
        {
            StringBuilder Codestring = new StringBuilder();
            foreach (string code in CodeSeparter.Split(','))
            {
                Codestring.Append("\"" + code + "\"" + ",");
            }
            return Codestring.ToString().TrimEnd(',');
        }

    }


}
