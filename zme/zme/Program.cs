using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zme
{
    class VLine
    {
        List<point> pList = new List<point>();

        public VLine(int x, int yLow, int yHight, char sym)
        {
            //pList = new List<point>();
            for (int y = yLow; y <= yHight; y++)
            {
                point p = new point(x, y, sym);
                pList.Add(p);
            }
        }

        public void Drow()
        {
            foreach(point p in pList)
            {
                p.Draw();
            }
        }
    }

    class point
    {
        public int x;
        public int y;
        public char sym;

        public point()
        {
        }

        public point(int _x, int _y, char _sym)
        {
            x = _x;
            y = _y;
            sym = _sym;
        }

        public void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(sym);
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            point p1 = new point(1, 3, '*');           
            p1.Draw();
        
            point p2 = new point(4, 5, '#');
            p2.Draw();

            VLine line = new VLine(10, 3, 10, '*');
            line.Drow();
                        
            Console.ReadLine();
        }                
    }
}
