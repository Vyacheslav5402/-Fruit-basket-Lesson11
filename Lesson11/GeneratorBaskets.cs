using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson11
{
    internal class GeneratorBaskets
    {
        public void Baskets(out int basketWeight)
        {
            Random random = new Random();
            basketWeight = random.Next(40, 139);
        }
    }
}
