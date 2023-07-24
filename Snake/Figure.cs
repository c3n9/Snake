using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Figure
    {
        protected List<Point> points;
        public void DrawFigure()
        {
            foreach (var p in points)
            {
                p.Draw();
            }
        }
        public bool IsHit(Figure figure)
        {
            foreach (var p in points)
            {
                if (figure.IsHit(p))
                    return true;
            }
            return false;
        }
        private bool IsHit(Point point)
        {
            foreach(var p in points)
            {
                if(p.IsHit(point))
                    return true;
            }
            return false;
        }
    }
}
