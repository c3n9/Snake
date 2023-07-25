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
        static int gameStat;
        static void Main(string[] args)
        {
            gameStat = 0;
            Console.SetWindowSize(50, 24);
            Console.SetBufferSize(50, 24);
            Console.ForegroundColor = ConsoleColor.Gray;
            Walls walls = new Walls(50, 20);
            walls.Draw();

            Point p = new Point(4, 5, '*');
            Console.ForegroundColor = ConsoleColor.Green;

            Snake snake = new Snake(p, 3, Direction.Right);
            snake.DrawFigure();

            FoodCreator foodCreator = new FoodCreator(50, 20, 'a');
            Point food = foodCreator.CreateFood();
            food.Draw();
            GameStat();
            while (true)
            {
                if (walls.IsHit(snake) || snake.IsHitTail())
                    break;
                if (snake.Eat(food))
                {
                    food = foodCreator.CreateFood();
                    food.Draw();
                    if (snake.TailHitFood(food))
                    {
                        food = foodCreator.CreateFood();
                        food.Draw();
                    }
                    gameStat++;
                    GameStat();
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
                Thread.Sleep(100);
            }
            WriteGameOver();
            Console.ReadLine();
        }
        static void WriteGameOver()
        {
            int xOffset = 10;
            int yOffset = 8;
            Console.ForegroundColor = ConsoleColor.Yellow;
            WriteText("|============================|", xOffset, yOffset++);
            WriteText("| И Г Р А    О К О Н Ч Е Н А |", xOffset, yOffset++);
            WriteText("| G I T H U B :  @ C 3 N 9   |", xOffset, yOffset++);
            WriteText("|============================|", xOffset, yOffset++);
        }

        static void WriteText(String text, int xOffset, int yOffset)
        {
            Console.SetCursorPosition(xOffset, yOffset);
            Console.WriteLine(text);
        }

        static void GameStat()
        {
            int xOffset = 10;
            int yOffset = 20;
            Console.ForegroundColor = ConsoleColor.Gray;
            WriteText("===============================", xOffset, yOffset++);
            WriteText($" С Ъ Е Д Е Н О   Я Б Л О К : {gameStat}" , xOffset, yOffset++);
            WriteText("===============================", xOffset, yOffset++);
        }
    }
}
