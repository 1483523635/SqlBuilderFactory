using System;
using System.Collections.Generic;
using System.Text;

namespace Reflect
{
    public interface IDelete
    {
        string DeleteSqlString(string TableName,int Id);
    }
}
