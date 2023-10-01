namespace Maze
{
    class Program
    {
        static void Main()
        {
            int width = 40;
            int height = 40;

            Game game = new(width, height);

            game.Start();
        }
    }
}