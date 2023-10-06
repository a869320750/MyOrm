using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq2Oracle.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class TableAttribute:Attribute
    {
        public string Name { get; set; }
    }
}
