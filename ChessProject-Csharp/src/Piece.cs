using System;

namespace SolarWinds.MSP.Chess
{
    /// <summary>
    /// Piece represents common behavious of all chess pieces
    /// </summary>
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

        /// <summary>
        /// Move returns true if the move was successful,
        /// otherwise the piece remains where it was.
        /// </summary>
        /// <param name="movementType"></param>
        /// <param name="newX"></param>
        /// <param name="newY"></param>
        /// <returns></returns>
        abstract public bool Move(MovementType movementType, int newX, int newY);

        public void Remove()
        {
            if (ChessBoard != null)
            {

            }
        }

        public override string ToString()
        {
            string nl = Environment.NewLine;
            return $"Current X: {XCoordinate}{nl}Current Y: {YCoordinate}{nl}Piece Color: {PieceColor}";
        }
    }
}
