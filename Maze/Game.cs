namespace Maze
{
    public class Game
    {
        private MazeBoard _board;

        public Game(int width, int height)
        {
            _board = new MazeBoard(width, height);
        }

        public void Start()
        {
            while (true)
            {
                _board.PrintMaze();

                var key = Console.ReadKey().Key;

                var won = key switch
                {
                    ConsoleKey.UpArrow => _board.Player.Move(0, -1),
                    ConsoleKey.DownArrow => _board.Player.Move(0, 1),
                    ConsoleKey.RightArrow => _board.Player.Move(1, 0),
                    ConsoleKey.LeftArrow => _board.Player.Move(-1, 0),
                    _ => false
                };

                if (won)
                {
                    _board.PrintMaze();
                    Console.WriteLine("You win!!");
                    break;
                }

            }
        }
    }
}
