using System;
using System.Collections.Generic;
using System.Text;

namespace Reflect
{
    interface IUpdate
    {
        string UpdateSqlString(object obj);
    }
}
