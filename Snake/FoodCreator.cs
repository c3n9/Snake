using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class FoodCreator
    {
        int mapWidth;
        int mapHeight;
        char sym;
        Random rnd = new Random();
        public FoodCreator(int mapWidth, int mapHeight, char sym)
        {
            this.mapWidth = mapWidth;
            this.mapHeight = mapHeight;
            this.sym = sym;
        }

        public Point CreateFood()
        {
            int x = rnd.Next(2, mapWidth - 2);
            int y = rnd.Next(2, mapHeight - 2);
            Console.ForegroundColor = ConsoleColor.Red;
            return new Point(x, y, sym);
        }
    }
}
