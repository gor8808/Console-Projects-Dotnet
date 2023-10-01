using System;

namespace Maze
{
    public class MazeBoard
    {
        private static Random _rnd = new();

        private int _startX;
        private int _startY;

        private int _finishX;
        private int _finishY;

        public Player Player { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        private int[,] _grid;

        public int this[int x, int y]
        {
            get => _grid[x, y];
            set => _grid[x, y] = value;
        }

        public MazeBoard(int width, int height)
        {
            Width = width;
            Height = height;
            _grid = new int[width, height];

            GenerateRandomMaze();

            Player = new Player(_startX, _startY, this);

            _grid[_startX, _startY] = 2;
            _grid[_finishX, _finishY] = 3;
        }

        private void GenerateRandomMaze()
        {
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    //1 represents a wall
                    _grid[i, j] = 1;
                }
            }

            int startX = _rnd.Next(0, Width);
            int startY = _rnd.Next(0, Height);

            _startX = startX;
            _startY = startY;


            VisitCell(startX, startY);

            // Choose a random finish point
            _finishX = _rnd.Next(0, Width);
            _finishY = _rnd.Next(0, Height);

            // Ensure the finish point is reachable
            while (Math.Abs(_finishX - startX) + Math.Abs(_finishY - startY) < Width / 2)
            {
                _finishX = _rnd.Next(0, Width);
                _finishY = _rnd.Next(0, Height);
            }
        }

        private void VisitCell(int x, int y)
        {
            _grid[x, y] = 0; // 0 represents path

            List<(int, int)> directions = GetRandomDirections();

            foreach (var (dx, dy) in directions)
            {
                int newX = x + 2 * dx;
                int newY = y + 2 * dy;

                if (IsInBounds(newX, newY) && _grid[newX, newY] == 1)
                {
                    _grid[x + dx, y + dy] = 0;
                    VisitCell(newX, newY);
                }
            }
        }

        private static List<(int, int)> GetRandomDirections()
        {
            List<(int, int)> directions = new()
            {
                (0, -1), // Up
                (0, 1),  // Down
                (-1, 0), // Left
                (1, 0)   // Right
            };

            // Shuffle the list
            int n = directions.Count;

            while (n > 1)
            {
                n--;

                int k = _rnd.Next(n + 1);

                //Swap N and K values
                (directions[n], directions[k]) = (directions[k], directions[n]);
            }

            return directions;
        }

        public bool IsInBounds(int x, int y)
        {
            return x >= 0 && x < Width && y >= 0 && y < Height;
        }

        public void PrintMaze()
        {
            Console.Clear();
            Console.CursorVisible = false;
            //Console.Write(" ");
            //for (int j = 0; j < Width; j++)
            //{
            //    Console.Write(j);
            //}

            //Console.WriteLine();

            for (int i = 0; i < Height; i++)
            {
                //Console.Write(i);
                for (int j = 0; j < Width; j++)
                {
                    if (_grid[j, i] == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("A ");
                        Console.ResetColor();
                    }
                    else if (_grid[j, i] == 3)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("X ");
                        Console.ResetColor();
                    }
                    else if (_grid[j, i] == 1)
                    {
                        Console.Write("██");
                    }
                    else
                    {
                        Console.Write("  ");
                    }

                }

                Console.WriteLine();
            }

            //Console.WriteLine($"{_startX}:{_startY}");
        }
    }
}
