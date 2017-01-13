using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zme
{
    class Program
    {
        static void Main(string[] args)
        {
            int x1 = 1, y1 = 3,
                x2 = 4, y2 = 5;
            char sym1 = '*',
                 sym2 = '#';

            Draw(x1, y1, sym1);
            Draw(x2, y2, sym2);

            Console.ReadLine();
        }
        
        static void Draw (int x, int y, char sym)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(sym);
        }
    }           
}
