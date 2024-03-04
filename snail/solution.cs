using System.Collections.Generic;

namespace snail;

public enum Direction { Right, Down, Left, Up };

public class Position
{
    private int _x;
    private int _y;

    private readonly int[][] _array;

    public Position(int[][] array)
    {
        _array = array;
    }

    private Direction _direction = Direction.Right;

    public int Current => _array[_y][_x];

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

    private (int, int) NextPosition() => _direction switch
    {
        Direction.Right => (_x + 1, _y),
        Direction.Left => (_x - 1, _y),
        Direction.Down => (_x, _y + 1),
        Direction.Up => (_x, _y - 1),
        _ => (0, 0),
    };

    private void MarkCurrentAsVisited()
    {
        _array[_y][_x] = -1;
    }

    public bool Next()
    {
        (int nextX, int nextY) = NextPosition();
        if(nextX > _array.Length - 1 || nextX < 0 || nextY > _array.Length - 1 || nextY < 0 || _array[nextY][nextX] == -1)
        {
            NextDirection();
            (nextX, nextY) = NextPosition();
        }

        if(_array[nextY][nextX] == -1) return false;

        MarkCurrentAsVisited();

        (_x, _y) = (nextX, nextY);

        return true;
    }

}

public class SnailSolution
{
    public static int[] Snail(int[][] array)
    {
        if(array.Length == 0) return System.Array.Empty<int>();
        if(array.Length == 1) return new int[] { array[0][0] };

        var result = new List<int>();
        var pointer = new Position(array);

        do
        {
            result.Add(pointer.Current);
        } while(pointer.Next());

        return result.ToArray();
    }
}

