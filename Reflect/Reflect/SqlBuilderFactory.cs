using System;
using System.Collections.Generic;
using System.Text;

namespace Reflect
{
    public  class SqlBuilderFactory : ICreate, IRead, IUpdate, IDelete
    {
     

        #region 获取Readsql语句 实现IRead接口

        public string ReadSqlString(object obj)
        {
            var type = obj.GetType();
            var PropertyList = TypeHelperFactory.GetAllProperty(type);
            var TableName = TypeHelperFactory.GetTableName(type);
            string SelectString = string.Join(",", PropertyList);
            StringBuilder SqlStatement = new StringBuilder();
            SqlStatement.AppendFormat($"select {SelectString} from {TableName}");
            return SqlStatement.ToString();
        }

        #endregion

        #region 获取Deletesql语句 实现IDelete接口
        public string DeleteSqlString(object obj)
        {
            var type = obj.GetType();
            var TableName = TypeHelperFactory.GetTableName(type);
            var PrimaryKey = TypeHelperFactory.GetPrimaryKey(type);     
            if (PrimaryKey == null)
            {    
                throw new Exception("不存在主键");
            }
            var PrimaryKeyValue = TypeHelperFactory.GetPrimaryKeyValue(obj, PrimaryKey);
            StringBuilder SqlStatement=new StringBuilder();
            SqlStatement.AppendFormat($"delete from {TableName} where {PrimaryKey}={PrimaryKeyValue}");
            return SqlStatement.ToString();
        }
        #endregion


    }
}
