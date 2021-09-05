using System;

namespace SolarWinds.MSP.Chess
{
    public class Pawn: Piece
    {

        public Pawn(PieceColor pieceColor)
            : base(pieceColor)
        { }

        public override void Move(MovementType movementType, int newX, int newY)
        {
            if (ChessBoard == null || !ChessBoard.IsLegalBoardPosition(newX, newY))
            {
                return;
            }
            int dx = newX - XCoordinate;
            int dy = PieceColor == PieceColor.White ?
                       newY - YCoordinate : YCoordinate - newY;
            switch (movementType)
            {
                case MovementType.Move:
                    if (dx == 0 && dy == 1 && null == ChessBoard.GetPiece(newX, newY))
                    {
                        XCoordinate = newX;
                        YCoordinate = newY;
                    }
                    break;
                case MovementType.Capture:
                    Piece p = ChessBoard.GetPiece(newX, newY);
                    if (p != null)
                    {
                        PieceColor otherColor = p.PieceColor;
                        if ((dx == 1 || dx == -1) && dy == 1 &&
                             PieceColor == otherColor.Invert())
                        {
                            XCoordinate = newX;
                            YCoordinate = newY;
                        }
                    }
                    break;
            }
        }

    }
}
