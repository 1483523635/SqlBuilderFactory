using System;
using System.Collections.Generic;
using System.Text;

namespace Reflect
{
    public abstract class SqlBuilderFactory : ICreate, IRead, IUpdate, IDelete
    {
        public string DeleteSqlString(string TableName, int Id)
        {
            throw new NotImplementedException();
        }

        public string ReadSqlString
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
