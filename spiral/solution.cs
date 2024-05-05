namespace spiral;

public enum Direction { Right, Down, Left, Up };

class Position
{
    private int _x;
    private int _y;

    private readonly int[,] _array;

    private readonly int _len;
    private readonly int _last_x;
    private readonly int _last_y;

    private Direction _direction = Direction.Right;

    public Position(int[,] array)
    {
        _array = array;
        _len = array.GetLength(0);
        (_last_x, _last_y) = DetermineLastCoordinate(_len);
    }

    private static (int, int) DetermineLastCoordinate(int len) => len switch
    {
        1 => (0, 0),
        2 => (1, 1),
        3 => (0, 2),
        var n when n % 2 == 0 => (n / 2 - 2, n / 2),
        var n => (n / 2, n / 2),
    };

    private void NextDirection()
    {
        _direction = _direction switch
        {
            Direction.Right => Direction.Down,
            Direction.Left => Direction.Up,
            Direction.Down => Direction.Left,
            Direction.Up => Direction.Right,
            _ => Direction.Right
        };
    }

    private (int, int) NextPosition(int x, int y) => _direction switch
    {
        Direction.Right => (x + 1, y),
        Direction.Left => (x - 1, y),
        Direction.Down => (x, y + 1),
        Direction.Up => (x, y - 1),
        _ => (0, 0),
    };

    private (int, int) PrevPosition(int x, int y) => _direction switch
    {
        Direction.Right => (x - 1, y),
        Direction.Left => (x + 1, y),
        Direction.Down => (x, y - 1),
        Direction.Up => (x, y + 1),
        _ => (0, 0),
    };

    private void MarkCurrentAsVisited()
    {
        _array[_y, _x] = 1;
    }

    private static bool IsOutOfRange(int value, int min, int max) => value < min || value > max;

    private bool IsCurrentXYLastXY() => _x == _last_x && _y == _last_y;

    public bool Next()
    {
        if(_array.Length == 1)
        {
            MarkCurrentAsVisited();
            return false;
        }

        var (nextX, nextY) = NextPosition(_x, _y);

        if(IsOutOfRange(nextX, 0, _len - 1))
        {
            NextDirection();
            return true;
        }

        if(IsOutOfRange(nextY, 0, _len - 1))
        {
            NextDirection();
            return true;
        }

        if(_array[nextY, nextX] == 1)
        {

            _array[_y, _x] = 0;
            var (prevX, prevY) = PrevPosition(_x, _y);
            (_x, _y) = (prevX, prevY);
            NextDirection();

            return true;
        }

        MarkCurrentAsVisited();

        if(IsCurrentXYLastXY())
        {
            return false;
        }

        (_x, _y) = (nextX, nextY);


        return true;
    }

}

class Solution
{
    public static int[,] Spiralize(int size)
    {
        var array = new int[size, size];
        var pointer = new Position(array);

        while(pointer.Next());

        return array;
    }
}
