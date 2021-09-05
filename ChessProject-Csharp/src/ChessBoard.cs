namespace SolarWinds.MSP.Chess
{
    public class ChessBoard
    {
        public static readonly int MaxBoardWidth = 7; // chessboard width 0..7 inclusive
        public static readonly int MaxBoardHeight = 7; // chessboard height 0..7 inclusive
        public static readonly int MaxPawns = MaxBoardWidth + 1;// chess game rule
        private Piece[,] pieces;
        private int pawns;

        public ChessBoard()
        {
            pieces = new Piece[MaxBoardWidth + 1, MaxBoardHeight + 1];
        }

        public void Add(Piece piece, int xCoordinate, int yCoordinate)
        {
            if (IsLegalBoardPosition(xCoordinate, yCoordinate) &&
                pieces[xCoordinate, yCoordinate] == null &&
                PieceAllowed(piece))
            {
                pieces[xCoordinate, yCoordinate] = piece;
                pawns++;
                piece.ChessBoard = this;
                piece.XCoordinate = xCoordinate;
                piece.YCoordinate = yCoordinate;
            }
        }

        public static bool IsLegalBoardPosition(int xCoordinate, int yCoordinate)
        {
            return xCoordinate >= 0 && xCoordinate <= MaxBoardWidth &&
                   yCoordinate >= 0 && yCoordinate <= MaxBoardHeight;
        }

        public void Remove(int xCoordinate, int yCoordinate)
        {
            Piece p = GetPiece(xCoordinate, yCoordinate);
            if (p != null)
            {
                // TODO: generalise once more pieces are implemented
                pawns--;
                pieces[xCoordinate, yCoordinate] = null;
                p.XCoordinate = -1;
                p.YCoordinate = -1;
            }
        }

        public Piece GetPiece(int xCoordinate, int yCoordinate)
        {
            return pieces[xCoordinate, yCoordinate];
        }

        private bool PieceAllowed(Piece piece)
        {
            // TODO: need to update when more pieces are added
            // rules will likely need to be externalised from ChessBoard.
            return pawns < MaxPawns;
        }
    }
}
