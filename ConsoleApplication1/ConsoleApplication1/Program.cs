using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zme
{
    class figure
    {
        protected List<point> pList = new List<point>();

        public void Drow()
        {
            foreach (point p in pList)
            {
                p.Draw();
            }
        }
    }
    class Hline : figure
    {
        public Hline(int xLeft, int xRight, int y, char sym)
        {
            //pList = new List<point>();
            for (int x = xLeft; x <= xRight; x++)
            {
                point p = new point(x, y, sym);
                pList.Add(p);
            }
        }
    }

    class Vline : figure
    {
        public Vline(int x, int yLow, int yHight, char sym)
        {
            //pList = new List<point>();
            for (int y = yLow; y <= yHight; y++)
            {
                point p = new point(x, y, sym);
                pList.Add(p);
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
            Console.SetBufferSize(80, 25);

            //отрисовка рамки            
            Vline leftline = new Vline(0, 0, 23, '+');
            Vline rightline = new Vline(78, 0, 23, '+');
            Hline upline = new Hline(0, 78, 0, '+');
            Hline downline = new Hline(0, 78, 23, '+');

            leftline.Drow();
            rightline.Drow();
            upline.Drow();
            downline.Drow();

            Console.ReadLine();
        }
    }
}
