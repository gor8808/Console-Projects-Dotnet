namespace Maze
{
    public class Player
    {
        private int _x;
        private int _y;
        private MazeBoard _board;

        public Player(int x, int y, MazeBoard board)
        {
            _x = x;
            _y = y;
            _board = board;

        }

        public bool Move(int xOffset = 0, int yOffset = 0)
        {
            if (_board.IsInBounds(_x + xOffset, _y + yOffset) && IsMovable(_x + xOffset, _y + yOffset))
            {
                //swap
                var val = _board[_x + xOffset, _y + yOffset];

                _board[_x, _y] = 0;
                _x += xOffset;
                _y += yOffset;
                _board[_x, _y] = 2;

                if (val == 3)
                {
                    return true;
                }
            }

            return false;
        }

        private bool IsMovable(int x, int y)
        {
            return _board[x, y] != 1;
        }
    }
}
