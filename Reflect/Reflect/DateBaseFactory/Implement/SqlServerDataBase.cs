using Microsoft.Extensions.Configuration;
using Reflect.DateBaseFactory.BaseClass;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net.Http.Headers;

namespace Reflect.DateBaseFactory.Implement
{
    public class SqlServerDatabase : BasicsDatabase
    {
        private SqlBuilderFactory SqlBuilder;

        public SqlServerDatabase() : base()
        {
            base.Connection = new SqlConnection(DatabaseConncetionString());
            Connection.Open();
            base.Command = new SqlCommand();
            Command.Connection = base.Connection;
            SqlBuilder=new SqlBuilderFactory();
        }

        public override List<T> GetAllInfo<T>()
        {
            throw new NotImplementedException();
        }
        public override bool Add(object data)
        {       
            Command.CommandText = SqlBuilder.CreateSqlString(data);
            return Command.ExecuteNonQuery() > 0;
        }
        public override bool Remove(object data)
        {
            Command.CommandText = SqlBuilder.DeleteSqlString(data);
            return Command.ExecuteNonQuery() > 0;
        }

        public override bool Update(object data)
        {
            Command.CommandText = SqlBuilder.UpdateSqlString(data);
            return Command.ExecuteNonQuery() > 0;
        }

        protected override string DatabaseConncetionString()
        {
            return base.Configuration.GetConnectionString("UserInfoContext");
        }


    }
}
