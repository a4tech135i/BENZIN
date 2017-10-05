using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BENZIN_1._0
{
    public class Save
    {
        private String name;
        private String complexity;

        public Save(String n, String com)
        {
            name = n;
            complexity = com;
        }
        public String getName()
        {
            return name;
        }
        public String getComplexity()
        {
            return complexity;
        }
    }
}
