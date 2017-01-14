using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace zme
{
    enum Direction
    {
        UP,
        DOWN,
        LEFT,
        RIGHT
    }

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

    class snake : figure
    {
        Direction direction;

        public snake(point tail, int lenght, Direction _direction)
        {
            direction = _direction;
            for(int i = 0; i < lenght; i++)
            {
                point p = new point(tail);
                p.move(i, direction);
                pList.Add(p);
            }
                
        }

        internal void Move()
        {
            point tail = pList.First();
            pList.Remove(tail);
            point head = GetNextPoint();
            pList.Add(head);

            tail.clear();
            head.Draw();
        }

        public point GetNextPoint()
        {
            point head = pList.Last();
            point nextPoint = new point(head);
            nextPoint.move(1, direction);
            return nextPoint;
        }

        public void HandlKey(ConsoleKey kl)
        {
            if (kl == ConsoleKey.LeftArrow)
                direction = Direction.LEFT;
            if (kl == ConsoleKey.RightArrow)
                direction = Direction.RIGHT;
            if (kl == ConsoleKey.UpArrow)
                direction = Direction.UP;
            if (kl == ConsoleKey.DownArrow)
                direction = Direction.DOWN;
        }

        internal bool eat(point food)
        {
            point head = GetNextPoint();
            if (head.IsHit(food))
            {
                food.sym = head.sym;
                pList.Add(food);
                return true;
            }
            else return false;
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

    class FoodCreator
    {
        int mapWidght;
        int mapHeight;
        char sym;

        Random random = new Random();

        public FoodCreator(int mapWidght, int mapHeight, char sym)
        {
            this.mapHeight = mapHeight;
            this.mapWidght = mapWidght;
            this.sym = sym;
        }

        public point CreateFood()
        {
            int x = random.Next(2, mapWidght - 2);
            int y = random.Next(2, mapHeight - 2);
            return new point(x, y, sym);
              
        }

    }

    class point
    {
        public int x;
        public int y;
        public char sym;
        
        public point(int _x, int _y, char _sym)
        {
            x = _x;
            y = _y;
            sym = _sym;
        }

        public point(point p)
        {
            x = p.x;
            y = p.y;
            sym = p.sym;
        }

        public void move( int offset, Direction direction)
        {
            if(direction == Direction.RIGHT)
                x = x + offset;            
            if (direction == Direction.LEFT)
                x = x - offset;
            if (direction == Direction.UP)
                y = y - offset;
            if (direction == Direction.DOWN)
                y = y + offset;        
        }    

        public void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(sym);
        }

        public void clear()
        {
            sym = ' ';
            Draw();
        }

        public bool IsHit(point p)
        {
            return p.x == this.x && return p.x == this.x;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.SetBufferSize(80, 25);

            Vline leftline = new Vline(0, 0, 23, '+');
            Vline rightline = new Vline(78, 0, 23, '+');
            Hline upline = new Hline(0, 78, 0, '+');
            Hline downline = new Hline(0, 78, 23, '+');

            leftline.Drow();
            rightline.Drow();
            upline.Drow();
            downline.Drow();
            
            point p = new point(4, 5, '*');
            snake Snake = new snake(p, 4, Direction.RIGHT);
            Snake.Drow();

            FoodCreator foodCr = new FoodCreator(80, 25, '#');
            point food = foodCr.CreateFood();
            food.Draw();

            while(true)
            {
                if(snake.eat(food))
                {
                    food = foodCr.CreateFood;
                    food.Draw;
                }

                //*/
                else
                {
                    Snake.Move();
                }
                Thread.Sleep(150);
                //*/

                if(Console.KeyAvailable)
                {
                    ConsoleKeyInfo kl = Console.ReadKey();
                    Snake.HandlKey(kl.Key);                 
                }

                Thread.Sleep(150);
                Snake.Move();
            }
        }
    }
}
