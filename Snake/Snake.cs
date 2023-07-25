using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Snake
{
    public class Snake : Figure
    {
        Direction direction;
        public Snake(Point tail, int length, Direction _direction)
        {
            direction = _direction;
            points = new List<Point>();
            for (int i = 0; i < length; i++)
            {
                Point p = new Point(tail);
                p.Move(i, direction);
                points.Add(p);
            }
        }

        public void Move()
        {
            Point tail = points.First();
            points.Remove(tail);
            Point head = GetNextPosition();
            points.Add(head);
            tail.Clear();
            head.Draw();
        }

        private Point GetNextPosition()
        {
            Point head = points.Last();
            Point nextPoint = new Point(head);
            nextPoint.Move(1, direction);
            return nextPoint;
        }
        public void HandledKey(ConsoleKey key)
        {
            if (key == ConsoleKey.LeftArrow && direction != Direction.Right)
                direction = Direction.Left;
            else if (key == ConsoleKey.RightArrow && direction != Direction.Left)
                direction = Direction.Right;
            else if (key == ConsoleKey.DownArrow && direction != Direction.Up)
                direction = Direction.Down;
            else if (key == ConsoleKey.UpArrow && direction != Direction.Down)
                direction = Direction.Up;
        }

        internal bool Eat(Point food)
        {
            Point head = GetNextPosition();
            if (head.IsHit(food))
            {
                food.sym = head.sym;
                points.Add(food);
                return true;
            }
            else
                return false;
        }

        internal bool IsHitTail()
        {
            var head = points.Last();
            for(int i =0; i < points.Count - 2; i++)
            {
                if (head.IsHit(points[i]))
                    return true;
            }
            return false;
        }
    }
}
