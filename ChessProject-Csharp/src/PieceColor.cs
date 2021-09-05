namespace SolarWinds.MSP.Chess
{
    public enum PieceColor
    {
        Black = 0,
        White = 1
    }

    public static class PieceColorExtensions
    {
        public static PieceColor Invert(this PieceColor color)
        {
            return (PieceColor)(((int)color + 1) % 2);
        }
    }
}
