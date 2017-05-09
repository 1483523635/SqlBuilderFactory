using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Reflect
{
    public static class TypeHelperFactory
    {
        #region 获取所有的属性

        /// <summary>
        /// 获取所有属性
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static List<string> GetAllProperty(Type type)
        {
            var Propertys = BaseTypeHelper
                          .GetAllMembers(type)
                          .ToList()
                          .FindAll(member => member.MemberType == MemberTypes.Property);
            var PropertyList = new List<string>();
            foreach (var item in Propertys)
            {
                PropertyList.Add(item.Name);
            }
            return PropertyList;
        }

        #endregion

        #region MyRegion

        

        #endregion

    }
}
