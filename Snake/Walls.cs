using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Walls
    {
        List<Figure> walls;
        public Walls(int mapWidth, int mapHeight)
        {
            walls = new List<Figure>();

            HorizontalLine upLine = new HorizontalLine(1, mapWidth - 2, 1, '#');
            HorizontalLine downLine = new HorizontalLine(1, mapWidth - 2, mapHeight - 1, '#');
            VerticalLine leftLine = new VerticalLine(1, mapHeight - 1, 1, '#');
            VerticalLine rightLine = new VerticalLine(1, mapHeight - 1, mapWidth - 2, '#');
            walls.Add(upLine);
            walls.Add(downLine);
            walls.Add(leftLine);
            walls.Add(rightLine);
        }
        public void Draw()
        {
            foreach(var wall in walls)
                wall.DrawFigure();
        }

        internal bool IsHit(Figure figure)
        {
            foreach(var wall in walls)
            {
                if (wall.IsHit(figure))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
