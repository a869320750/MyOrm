using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq2Oracle.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ColumnAttribute:Attribute
    {
        public string Name { get; set; }
    }
}
