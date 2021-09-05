using System;

namespace SolarWinds.MSP.Chess
{
    public class ChessBoard
    {
        public static readonly int MaxBoardWidth = 7; // chessboard width 0..7 inclusive
        public static readonly int MaxBoardHeight = 7; // chessboard height 0..7 inclusive
        public static readonly int MaxPawns = MaxBoardWidth + 1;// chess game rule
        private Pawn[,] pieces;
        private int pawns;

        public ChessBoard ()
        {
            pieces = new Pawn[MaxBoardWidth + 1, MaxBoardHeight + 1];
        }

        public void Add(Pawn pawn, int xCoordinate, int yCoordinate, PieceColor pieceColor)
        {
            if (IsLegalBoardPosition(xCoordinate, yCoordinate) &&
                pieceColor == pawn.PieceColor && // TODO - not clean, why is the parameter passed in?
                pieces[xCoordinate, yCoordinate] == null &&
                PieceAllowed(pawn))
            {
                pieces[xCoordinate, yCoordinate] = pawn;
                pawns++;
                pawn.ChessBoard = this;
                pawn.XCoordinate = xCoordinate;
                pawn.YCoordinate = yCoordinate;
            }
        }

        public bool IsLegalBoardPosition(int xCoordinate, int yCoordinate)
        {
            return xCoordinate >= 0 && xCoordinate <= MaxBoardWidth &&
                   yCoordinate >= 0 && yCoordinate <= MaxBoardHeight;
        }

        public void Remove(int xCoordinate, int yCoordinate)
        {
            if (pieces[xCoordinate, yCoordinate] != null)
            {
                pawns--;
                pieces[xCoordinate, yCoordinate] = null;
            }
        }

        public Pawn GetPawn(int xCoordinate, int yCoordinate)
        {
            return pieces[xCoordinate, yCoordinate];
        }

        private bool PieceAllowed(Pawn pawn)
        {
            return pawns < MaxPawns;
        }
    }
}
