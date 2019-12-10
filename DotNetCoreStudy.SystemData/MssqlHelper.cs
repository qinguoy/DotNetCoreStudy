using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QinGy.DotNetCoreStudy.SystemData
{
    /// <summary>
    /// 
    /// </summary>
    public class MssqlHelper
    {
        /// <summary>
        /// 
        /// </summary>
        public static string ConnectionString { get; set; }

        /// <summary>
        /// 查询，返回DataTable
        /// </summary>
        /// <param name="cmdString"></param>
        /// <param name="parameters"></param>
        /// <param name="cmdType"></param>
        /// <returns></returns>
        public static DataTable QueryToDataTable(string cmdString, Dictionary<string, object> parameters, CommandType cmdType = CommandType.Text)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                using (var cmd = new SqlCommand(cmdString, conn))
                {
                    conn.Open();
                    cmd.CommandType = cmdType;
                    if (parameters != null && parameters.Count > 0)
                    {
                        foreach (var item in parameters)
                        {
                            cmd.Parameters.Add(new SqlParameter(item.Key, item.Value));
                        }
                    }
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmdString"></param>
        /// <param name="parameters"></param>
        /// <param name="cmdType"></param>
        /// <returns></returns>
        public static DataSet QueryToDataSet(string cmdString, Dictionary<string, object> parameters, CommandType cmdType = CommandType.Text)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                using (var cmd = new SqlCommand(cmdString, conn))
                {
                    conn.Open();
                    cmd.CommandType = cmdType;
                    if (parameters != null && parameters.Count > 0)
                    {
                        foreach (var item in parameters)
                        {
                            cmd.Parameters.Add(new SqlParameter(item.Key, item.Value));
                        }
                    }
                    DataSet ds = new DataSet();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(ds);
                    return ds;
                }

            }
        }
        /// <summary>
        /// 执行sql,返回受影响行数
        /// </summary>
        /// <param name="cmdString"></param>
        /// <param name="parameters"></param>
        /// <param name="cmdType"></param>
        /// <returns></returns>
        public static int ExecuteNonQuerySql(string cmdString, Dictionary<string, object> parameters, CommandType cmdType = CommandType.Text)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(cmdString, conn))
                {
                    cmd.CommandType = cmdType;
                    if (parameters != null && parameters.Count > 0)
                    {
                        foreach (var item in parameters)
                        {
                            cmd.Parameters.Add(new SqlParameter(item.Key, item.Value));
                        }
                    }
                    return cmd.ExecuteNonQuery();
                }
            }

        }

        /// <summary>
        /// 通过SqlBulkCopy保存数据
        /// </summary>
        /// <param name="dataTable"></param>
        /// <param name="targetTableName"></param>
        /// <param name="timeoutSecond"></param>
        public static void SaveBySqlBulkCopy(DataTable dataTable, string targetTableName, int timeoutSecond = 600)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                using (var bulkCopy = new SqlBulkCopy(conn))
                {
                    bulkCopy.BulkCopyTimeout = timeoutSecond;
                    bulkCopy.DestinationTableName = targetTableName;
                    bulkCopy.WriteToServer(dataTable);
                }
            }
        }

    }
}
