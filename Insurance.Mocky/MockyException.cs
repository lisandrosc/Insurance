using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Mocky
{
    public class MockyException:Exception
    {
        public MockyException(string message):base(message)
        {

        }
    }
}
