using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Text;

namespace Reflect
{
    public class ReflectTestClass
    {
        private string name;
        public string Name1 { get; set; }
        [Display(Name = "key")]
        public int key { get; set; }

        [Key]
        public string CusotmeName { get; set; }
        public static string NameStaitc = "你好世界";

        public ReflectTestClass()
        {
            this.name = "你好世界";
        }

        public ReflectTestClass(string name)
        {
            this.name = name;
        }

        public string GetName()
        {
            return this.name;
        }
    }
}
