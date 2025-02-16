using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using NUnit.Framework;

namespace getting_started_with_CSharp.BasicProgramming
{
    public class NaturalNumbers
    {
        [Test]
        public void PrintNaturalNumbers()
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}