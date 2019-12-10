using QinGy.DotNetCoreStudy.SystemData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Xunit;

namespace QinGy.DotNetCoreStudy.SystemUnitTest
{
    public class MssqlHelperTester
    {
        public MssqlHelperTester()
        {
            MssqlHelper.ConnectionString = "Data Source=.;Initial Catalog=DbBaseInfo;User ID=sa;pwd=3295";
        }
        [Fact]
        public void TestExecuteSql()
        {
            string insertString = "INSERT INTO  [tbTemp]([RegionCode] ,[RegionName] ,[InputString] ,[Upcode]) values(@RegionCode,@RegionName,@InputString,@Upcode)";
            Dictionary<string, object> dicParameters = new Dictionary<string, object>();
            dicParameters.Add("@RegionCode", Guid.NewGuid().ToString());
            dicParameters.Add("@RegionName", "jinke");
            dicParameters.Add("@InputString","jkjc");
            dicParameters.Add("@Upcode", "");
            int result = MssqlHelper.ExecuteNonQuerySql(insertString,dicParameters);
            Assert.True(result == 1);
        }
        [Fact]
        public void TestQueryToDataTable()
        {
            string sqlString = "select * from tbTemp";
            DataTable table = MssqlHelper.QueryToDataTable(sqlString,null);
            Assert.True(table.Rows.Count > 0);
        }
        [Fact]
        public void TestQueryToDataSet()
        {
            string sqlString = "select * from tbTemp";
            DataSet dataSet = MssqlHelper.QueryToDataSet(sqlString, null);
            Assert.True(dataSet.Tables[0].Rows.Count > 0);
        }

    }
}
