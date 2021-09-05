using System;

namespace SolarWinds.MSP.Chess
{
    // Piece represents common behavious of all chess pieces
    abstract public class Piece
    {
        public Piece(PieceColor pieceColor)
        {
            PieceColor = pieceColor;
            XCoordinate = YCoordinate = -1;
        }
        public ChessBoard ChessBoard { get; set; }

        public int XCoordinate { get; set; }

        public int YCoordinate { get; set; }

        public PieceColor PieceColor { get; set; }

        abstract public void Move(MovementType movementType, int newX, int newY);

        public override string ToString()
        {
            string nl = Environment.NewLine;
            return $"Current X: {XCoordinate}{nl}Current Y: {YCoordinate}{nl}Piece Color: {PieceColor}";
        }
    }
}
