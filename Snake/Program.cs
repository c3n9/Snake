using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(120, 60);
            Console.SetBufferSize(120, 60);

            Console.ForegroundColor = ConsoleColor.Green;
            Walls walls = new Walls(50, 20);
            walls.Draw();

            Point p = new Point(4, 5, '*');
            Console.ForegroundColor = ConsoleColor.Yellow;

            Snake snake = new Snake(p, 10, Direction.Right);
            snake.DrawFigure();

            FoodCreator foodCreator = new FoodCreator(50, 20, 'a');
            Point food = foodCreator.CreateFood();
            food.Draw();

            while (true)
            {
                if (walls.IsHit(snake) || snake.IsHitTail())
                    break;
                if (snake.Eat(food))
                {
                    food = foodCreator.CreateFood();
                    food.Draw();
                }
                else
                {
                    snake.Move();
                }
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandledKey(key.Key);
                }
                Thread.Sleep(200);
                snake.Move();
            }

        }
    }
}
