using QinGy.DotNetCoreStudy.SystemData;
using System;
using System.Data;
using Xunit;
using System.Collections;
using System.Collections.Generic;

namespace QinGy.DotNetCoreStudy.SystemUnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void TestGenerateTableToModelList()
        {
            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn("Id"));
            table.Columns.Add(new DataColumn("UserName"));
            table.Columns.Add(new DataColumn("Password"));
            table.Columns.Add(new DataColumn("Address"));
            table.Columns.Add(new DataColumn("Gender"));
            table.Columns.Add(new DataColumn("Status"));
            table.Columns.Add(new DataColumn("Created"));
            DataRow row = table.NewRow();
            row["Id"] = Guid.NewGuid().ToString();
            row["UserName"] = "qinGy";
            row["Password"] = "123456";
            row["Address"] = "lz";
            row["Gender"] = 1;
            row["Status"] = 1;
            row["Created"] = DateTime.Now;
            table.Rows.Add(row);
            DataRow row1 = table.NewRow();
            row1["Id"] = Guid.NewGuid().ToString();
            row1["UserName"] = "dingtang";
            row1["Password"] = "123456";
            row1["Address"] = "lz";
            row1["Gender"] = 0;
            row1["Status"] = 1;
            row1["Created"] = DateTime.Now;
            table.Rows.Add(row1);
            var result = ModelManagement.GenerateModelList<UserInfo>(table);
            Assert.True(result.Count > 0);
        }

        [Fact]
        public void TestGenerateDataTable()
        {
            List<UserInfo> userList = new List<UserInfo>();
            UserInfo u1 = new UserInfo() {
                Id = Guid.NewGuid().ToString(),
                Address="lz",
                Created=DateTime.Now,
                Gender=1,
                Password="123456",
                Status=1,
                UserName="QinGy", 
            };
            userList.Add(u1);
            UserInfo u2 = new UserInfo()
            {
                Id = Guid.NewGuid().ToString(),
                Address = "lz",
                Created = DateTime.Now,
                Gender = 0,
                Password = "123456",
                Status = 1,
                UserName = "zengdingtang",
            };
            userList.Add(u2);
            DataTable table = ModelManagement.GenerateDataTable(userList);
            Assert.True(table.Rows.Count == 2);
        }

    }

    public class UserInfo
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public int Gender { get; set; }
        public int Status { get; set; }
        public DateTime Created { get; set; }

    }

}
