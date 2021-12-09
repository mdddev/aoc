namespace aoc2021;

public class Day02
{
    private Position _position { get; set; } = new();
    private IEnumerable<Movement> _movements { get; set; } = Enumerable.Empty<Movement>();
    private async Task _part1()
    {
        _movements = await _getMovements();
        foreach (var move in _movements) _position.Move(move);
        WriteLine("Day2-1");
        _position.ProductOfCoordinates(); 
    }
    private void _part2()
    {
        _position.Reset();
        foreach (var move in _movements) _position.Move(move, useAim: true);
        WriteLine("Day2-2");
        _position.ProductOfCoordinates();
    }

    public async Task SolvePuzzles()
    {
        await _part1();
        _part2();
    }

    private async Task<IEnumerable<Movement>> _getMovements()
    {
        var input = await Files.ReadAsync("Input/day02.txt");
        return input.Split("\n")
            .Select(s => s.Split(" ", 2))
            .Select(s => new Movement {
                Units = int.Parse(s[1]),
                Direction = s[0] == "up" ? Direction.Up
                    : s[0] == "down" ? Direction.Down
                        : Direction.Forward
            });
    }

    public enum Direction
    {
        Up,
        Down,
        Forward
    }

    public class Movement
    {
        public Direction Direction { get; set; }
        public int Units { get; set; }
    }

    public class Position
    {
        private int _horizontal { get; set; }
        private int _depth { get; set; }
        private int _aim { get; set; }
        
        public void Move(Movement movement, bool useAim = false)
        {
            int units = movement.Units;
            switch (movement.Direction)
            {
                case Direction.Forward:
                    _horizontal += units;
                    if (useAim)
                    {
                        _depth += (_aim * units);
                    }
                    break;

                case Direction.Up:
                    _depth -= units;
                    if (useAim)
                    {
                        _aim -= units;
                    }
                    break;

                case Direction.Down:
                    _depth += units;
                    if (useAim)
                    {
                        _aim += units;
                    }
                    break;

                default: throw new ArgumentOutOfRangeException(nameof(movement.Direction));
            }
        }
        
        public void Reset()
        {
            _aim = 0;
            _depth = 0;  
            _horizontal = 0;
        }
        
        public void ProductOfCoordinates() => WriteLine($"Horizontal x Vertical = {_horizontal} x {_depth} = {_horizontal * _depth}");
    }
}
