using System;

namespace NodeMaps.Entities
{
    public enum Direction
    {
        Left,
        Right,
        Up,
        Down,
        Front,
        Back
    }

    public static class DirectionTools
    {
        public static Direction GetOpposite(Direction direction)
        {
            return direction switch
            {
                Direction.Left => Direction.Right,
                Direction.Right => Direction.Left,
                Direction.Up => Direction.Down,
                Direction.Down => Direction.Up,
                Direction.Front => Direction.Back,
                Direction.Back => Direction.Front,
                _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
            };
        }
    }
}