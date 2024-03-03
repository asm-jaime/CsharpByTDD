namespace spiral;

public enum Direction { Right, Down, Left, Up };

public class Position
{
    private int _x;
    private int _y;

    private int[,] _array;

    private int _len;
    private int _last_x;
    private int _last_y;

    public Position(int[,] array)
    {
        _array = array;
        _len = array.GetLength(0);

        if(_len == 1)
        {
            _last_x = 0;
            _last_y = 0;
        }
        else if(_len == 2)
        {
            _last_x = 1;
            _last_y = 1;
        }
        else if(_len == 3)
        {
            _last_x = 0;
            _last_y = 2;
        }
        else if(_len % 2 == 0)
        {
            _last_x = _len / 2 - 2;
            _last_y = _len / 2;
        }
        else
        {
            _last_x = _len / 2;
            _last_y = _len / 2;
        }
    }

    private Direction _direction = Direction.Right;

    public int Current => _array[_y, _x];

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

    private bool IsOutOfRange(int value, int min, int max) => value < min || value > max;

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

        if(_x == _last_x && _y == _last_y)
        {
            return false;
        }

        (_x, _y) = (nextX, nextY);


        return true;
    }

}

public class Solution
{
    public static int[,] Spiralize(int size)
    {
        var array = new int[size, size];
        var pointer = new Position(array);

        var tick = 0;
        while(pointer.Next())
        {
            tick++;
            if(tick is 100) break;
        }

        return array;
    }
}
