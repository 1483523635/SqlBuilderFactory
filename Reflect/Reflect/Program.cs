using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Reflect
{
    class Program
    {
        static void Main(string[] args)
        {

              Members();
           // GetMemberReturntype();
            Console.Read();
        }

        #region 获取成员

        static void Members()
        {

            Type t = typeof(ReflectTestClass);
            //这样可以获取到私有的成员变量
            var members_private = t.GetMembers(BindingFlags.NonPublic | BindingFlags.Instance);
            var members_All = t.GetMembers().ToList().FindAll(member => member.MemberType == MemberTypes.Property);
            Console.WriteLine(members_All[0].Name);
            Toconsole(members_All);
            //TestGeterAndSetter(t, members_All.ToList());
            //TestTeXing(t, members_All.ToList());
            //Toconsole(key);

        }

        #endregion

        #region 测试获取特性

        static void TestTeXing(Type t, List<MemberInfo> members_All)
        {

            var member = members_All.FirstOrDefault(m => m.Name == "CusotmeName");
        
            var attrs = member.CustomAttributes;
            var result = attrs.FirstOrDefault(a => a.AttributeType == typeof(KeyAttribute));
            //下边这行是重点代码
            var mykey = result.NamedArguments[0].TypedValue.Value;
            Console.WriteLine(result);
            Console.WriteLine(mykey);

        }

        #endregion

        #region testGetterAndSetter

        static void TestGeterAndSetter(Type t, List<MemberInfo> members_All)
        {
         
            var keys = members_All.ToList().FirstOrDefault(m => m.Name=="key");
            var setkey = t.GetProperty(keys.Name);
            var TestClass = new ReflectTestClass();
            setkey.SetValue(TestClass,10);
            Console.WriteLine(TestClass.key);
            
        }

        #endregion

        #region 将listORArray输出到控制台上
        static void Toconsole<T>(T list) where T : IEnumerable
        {

            foreach (var i in list)
            {
                Console.WriteLine($"{i}");
            }
        }


        #endregion

        #region 测试获取Member的返回值类型

        static void GetMemberReturntype()
        {
            Type t = typeof(ReflectTestClass);
            var Members = t.GetMembers();
            MemberInfo member = Members.FirstOrDefault(m => m.Name == "key");
            PropertyInfo property = t.GetProperty(member.Name);
            var type = property.PropertyType.Name;
            Console.WriteLine(type);
            
         

        }

        #endregion


        #region property

        

        #endregion

    }
}