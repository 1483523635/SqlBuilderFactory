using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Reflect
{
    public  class SqlBuilderFactory : ICreate, IRead, IUpdate, IDelete
    {
        public string DeleteSqlString(string TableName, int Id)
        {
            throw new NotImplementedException();
        }

        string IRead.ReadSqlString(object obj)
        {
            var type = obj.GetType();
            var PropertyList = TypeHelperFactory.GetAllProperty(type);
            var TableName = TypeHelperFactory.GetTableName(type);
            string SelectString = string.Join(",", PropertyList);
            StringBuilder sqlBuilder=new StringBuilder();
            sqlBuilder.AppendFormat($"select {SelectString} from {TableName}");
            return sqlBuilder.ToString();
        }
    }
}
