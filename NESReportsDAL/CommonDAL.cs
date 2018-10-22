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
            try
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
                        strList.Add("Strength");
                        strList.Add("Duration");
                        strList.Add("Per(%)");
                        avReport.footerTotalColumns = strList;
                    }

                    return avReport;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<string> CollectColumns(DataTable dt)
        {
            try
            {
                List<string> columns = new List<string>();
                foreach (DataColumn column in dt.Columns)
                {
                    columns.Add(column.ColumnName);
                }
                return columns;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// function that creates a list of an object from the given data table
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tbl"></param>
        /// <returns></returns>
        public static List<T> CreateListFromTable<T>(DataTable tbl) where T : new()
        {
            try
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
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        ///  function that creates an object from the given data row
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="row"></param>
        /// <returns></returns>
        public static T CreateItemFromRow<T>(DataRow row) where T : new()
        {
            try
            {
                // create a new object
                T item = new T();

                // set the item
                SetItemFromRow(item, row);

                // return 
                return item;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <param name="row"></param>
        public static void SetItemFromRow<T>(T item, DataRow row) where T : new()
        {
            try
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
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// call stored procedure to get data.
        /// </summary>
        /// <param name="SPName"></param>
        /// <param name="SqlPrms"></param>
        /// <returns></returns>
        public static DataSet GetRecordWithExtendedTimeOut(string SPName, params MySqlParameter[] SqlPrms)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;
                DataSet ds = new DataSet();
                MySqlCommand cmd = new MySqlCommand();
                MySqlDataAdapter da = new MySqlDataAdapter();
                MySqlConnection con = new MySqlConnection(connectionString);
                cmd = new MySqlCommand(SPName, con);
                cmd.Parameters.AddRange(SqlPrms);
                cmd.CommandTimeout = 240;
                cmd.CommandType = CommandType.StoredProcedure;
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public static AVReportDTO OracleDataTableToJsonstring(OracleCommand cmd)
        {
            try
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
                    }
                }
                return avReport;
            }
            catch (Exception)
            {
                throw;
            }



        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CodeSeparter"></param>
        /// <returns></returns>
        public static string AddingDoubleCodes(string CodeSeparter)
        {
            try
            {
                StringBuilder Codestring = new StringBuilder();
                foreach (string code in CodeSeparter.Split(','))
                {
                    Codestring.Append("\"" + code + "\"" + ",");
                }
                return Codestring.ToString().TrimEnd(',');
            }
            catch (Exception)
            {
                throw;
            }
        }

    }


}
