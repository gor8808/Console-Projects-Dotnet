namespace Maze
{
    class Program
    {
        static void Main()
        {
            int width = 10;
            int height = 10;

            Game game = new(width, height);

            game.Start();
        }
    }
}