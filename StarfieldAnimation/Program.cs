using System;

namespace StarfieldAnimation
{
    class Program
    {
        private static readonly Random _rnd = new();

        static void Main()
        {
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.DarkGreen;


            int windowWidth = Console.WindowWidth;
            int windowHeight = Console.WindowHeight;

            var stars = InitializeStars(windowWidth, windowHeight);

            while (true)
            {
                Console.Clear();

                foreach (Star star in stars)
                {
                    star.MoveFromLeftToRight();
                    star.Draw();
                }

                Thread.Sleep(20);
            }
        }

        private static Star[] InitializeStars(int width, int height)
        {
            int numStars = 100;

            var stars = new Star[numStars];

            for (int i = 0; i < numStars; i++)
            {
                int x = _rnd.Next(width);
                int y = _rnd.Next(height);
                int speed = _rnd.Next(1, 4);

                stars[i] = new Star(x, y, speed);
            }

            return stars;
        }
    }

    internal class Star
    {
        private static readonly Random _rnd = new();
        private static readonly char[] _chars = new[] { '*', '#', '$' };
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Speed { get; private set; }
        public char Character { get; private set; }


        public Star(int x, int y, int speed, char? character = null)
        {
            X = x;
            Y = y;
            Speed = speed;

            Character = character ?? _chars[_rnd.Next(0, _chars.Length)];
        }

        public void MoveFromRightToLeft()
        {
            X -= Speed;

            if (X < 0)
            {
                X = Console.WindowWidth - 1;
                Y = _rnd.Next(Console.WindowHeight);
                Speed = _rnd.Next(1, 4);

                Character = _chars[_rnd.Next(0, _chars.Length)];
            }
        }

        public void MoveFromLeftToRight()
        {
            X += Speed;

            if (X >= Console.WindowWidth)
            {
                X = 0;
                Y = _rnd.Next(Console.WindowHeight);
                Speed = _rnd.Next(1, 4);

                Character = _chars[_rnd.Next(0, _chars.Length)];
            }
        }

        public void MoveFromDownToUp()
        {
            Y -= Speed;

            if (Y < 0)
            {
                Y = Console.WindowHeight - 1;
                X = _rnd.Next(Console.WindowWidth);
                Speed = _rnd.Next(1, 3);

                Character = _chars[_rnd.Next(0, _chars.Length)];
            }
        }

        public void MoveFromUpToDown()
        {
            Y += Speed;

            if (Y >= Console.WindowHeight)
            {
                Y = 0;
                X = _rnd.Next(Console.WindowWidth);
                Speed = _rnd.Next(1, 3);

                Character = _chars[_rnd.Next(0, _chars.Length)];
            }
        }

        public void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(Character);
        }
    }

}
