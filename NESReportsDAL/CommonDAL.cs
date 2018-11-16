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
                        avReport.columns = CollectColumnsStyle(dt);
                        avReport.data = JsonConvert.SerializeObject(dt);
                        avReport.sorting = "Per(%)";

                        List<Column> footercolumns = new List<Column>();
                        footercolumns.Add(new Column { align = "right", name = "Strength" });
                        footercolumns.Add(new Column { align = "center", name = "Target" });
                        footercolumns.Add(new Column { align = "center", name = "Duration" });
                        footercolumns.Add(new Column { align = "center", name = "Diff" });
                        footercolumns.Add(new Column { align = "right", name = "Per(%)" });
                        avReport.footerTotalColumns = footercolumns;

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
        /// 
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<Column> CollectColumnsStyle(DataTable dt)
        {
            try
            {
                Dictionary<string, string> dictionary = new Dictionary<string, string>();
                dictionary.Add("Sl.No", "right");
                dictionary.Add("Strength", "right");
                dictionary.Add("Target", "center");
                dictionary.Add("Duration", "center");
                dictionary.Add("Diff", "center");
                dictionary.Add("Per(%)", "right");

                List<Column> columns = new List<Column>();
                foreach (DataColumn column in dt.Columns)
                {
                    var thisTag = dictionary.FirstOrDefault(t => t.Key == column.ColumnName);

                    if (dictionary.ContainsKey(column.ColumnName))
                    {
                        columns.Add(new Column { align = thisTag.Value, name = thisTag.Key });
                    }
                    else
                    {
                        columns.Add(new Column { align = "left", name = column.ColumnName });
                    }
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

                    /// adding strength
                    List<Column> footercolumns = new List<Column>();
                    footercolumns.Add(new Column { align = "right", name = "Strength" });
                    footercolumns.Add(new Column { align = "center", name = "Target" });
                    footercolumns.Add(new Column { align = "center", name = "Duration" });
                    footercolumns.Add(new Column { align = "center", name = "Diff" });
                    footercolumns.Add(new Column { align = "right", name = "Per(%)" });

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        DataColumn Col = dt.Columns.Add("Diff", typeof(string));
                        int position = dt.Columns.IndexOf("Duration");
                        Col.SetOrdinal(position + 1);
                        string fromDate = string.Empty;
                        string toDate = string.Empty;

                        foreach (DataRow dr in dt.Rows)
                        {
                            fromDate = dr["Target"].ToString();
                            toDate = dr["Duration"].ToString();

                            if (fromDate != "00:00:00")
                            {

                                string[] splitfromDate = fromDate.Split(':');
                                TimeSpan spfromdate = new TimeSpan(int.Parse(splitfromDate[0]), int.Parse(splitfromDate[1]), int.Parse(splitfromDate[2]));
                                string[] splittoDate = toDate.Split(':');
                                TimeSpan sptodate = new TimeSpan(int.Parse(splittoDate[0]), int.Parse(splittoDate[1]), int.Parse(splittoDate[2]));
                                TimeSpan difference = spfromdate.Subtract(sptodate);

                                if (difference.TotalHours >= 0)
                                {
                                    dr["Diff"] = string.Format("{0}:{1}:{2}",
                                        difference.TotalHours < 10 ?
                                        "0" + ((int)difference.Hours).ToString() : ((int)difference.Hours).ToString(),
                                        difference.Minutes < 10 ?
                                        "0" + ((int)difference.Minutes).ToString() : ((int)difference.Minutes).ToString()
                                    , difference.Seconds < 10 ?
                                        "0" + ((int)difference.Seconds).ToString() : ((int)difference.Seconds).ToString());
                                }
                                else
                                {
                                    int hours = (int)difference.Hours;
                                    int minutes = (int)difference.Minutes;
                                    int seconds = (int)difference.Seconds;

                                    if (hours < 0)
                                    {
                                        hours = hours * -1;
                                    }

                                    if (minutes < 0)
                                    {
                                        minutes = minutes * -1;
                                    }

                                    if (seconds < 0)
                                    {
                                        seconds = seconds * -1;
                                    }


                                    dr["Diff"] = "-" + string.Format("{0}:{1}:{2}",
                                        (hours < 10) ?
                                        "0" + (hours).ToString() : (hours).ToString(),
                                        (minutes < 10) ?
                                        "0" + (minutes).ToString() : (minutes).ToString()
                                    , (seconds < 10) ?
                                        "0" + (seconds).ToString() : (seconds).ToString());
                                }
                            }
                            else
                            {
                                dr["Diff"] = "00:00:00";
                            }
                        }

                        avReport.columns = CollectColumnsStyle(dt);
                        avReport.data = JsonConvert.SerializeObject(dt);
                        avReport.sorting = "Per(%)";
                        avReport.footerTotalColumns = footercolumns;
                    }
                    else
                    {
                        if (dt.Columns.Count > 0)
                        {
                            avReport.columns = CollectColumnsStyle(dt);
                            avReport.data = "[]";
                            avReport.sorting = "Per(%)";
                            avReport.footerTotalColumns = footercolumns;
                        }
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
        /// <param name="cmd"></param>
        /// <returns></returns>
        public static FeedBackDTO OracleDataTableFeedBackReportToJsonstring(OracleCommand cmd, string sortingType)
        {
            try
            {
                FeedBackDTO feedBackReport = new FeedBackDTO();
                using (OracleDataAdapter sqlDataAdapter = new OracleDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sqlDataAdapter.Fill(dt);

                    /// adding strength
                    List<Column> footercolumns = new List<Column>();

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        feedBackReport.columns = CollectColumnsStyle(dt);
                        feedBackReport.data = JsonConvert.SerializeObject(dt);
                        feedBackReport.sorting = sortingType;
                        //   feedBackReport.footerTotalColumns = footercolumns;
                    }
                    else
                    {
                        if (dt.Columns.Count > 0)
                        {
                            feedBackReport.columns = CollectColumnsStyle(dt);
                            feedBackReport.data = "[]";
                            feedBackReport.sorting = sortingType;
                            //     feedBackReport.footerTotalColumns = footercolumns;
                        }
                    }
                }
                return feedBackReport;
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

        /// <summary>
        /// check login
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public AdminLogin CheckLogin(string userName, string password)
        {
            try
            {
                AdminLogin adminLogin = new AdminLogin();
                string connectionString = ConfigurationManager.ConnectionStrings["OracleSchoolString"].ConnectionString;
                using (OracleConnection con = new OracleConnection(connectionString))
                {
                    using (OracleCommand cmd = new OracleCommand("AVMODULE_LOGINCHECK", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("iUSERNAME", OracleDbType.Varchar2).Value = userName;
                        cmd.Parameters.Add("iPASSWORD", OracleDbType.Varchar2).Value = password;
                        cmd.Parameters.Add("DATACUR", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                        using (OracleDataAdapter sda = new OracleDataAdapter(cmd))
                        {
                            using (OracleDataAdapter sqlDataAdapter = new OracleDataAdapter(cmd))
                            {
                                DataTable dt = new DataTable();
                                sqlDataAdapter.Fill(dt);

                                if (dt != null && dt.Rows.Count > 0)
                                {
                                    adminLogin.id = int.Parse(dt.Rows[0]["SLNO"].ToString());
                                    adminLogin.userName = dt.Rows[0]["USER_NAME"].ToString();
                                 
                                }
                                else
                                {

                                }
                            }

                        }
                    }
                }

                return adminLogin;

            }
            catch (Exception)
            {
                throw;
            }
        }
    }

}
