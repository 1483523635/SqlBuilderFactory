using System;
using System.Collections.Generic;
using System.Text;

namespace Reflect
{
    public interface ICreate
    {
        string CreateSqlString(object obj);
    }
}
