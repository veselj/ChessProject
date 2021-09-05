namespace SolarWinds.MSP.Chess
{
    public class ChessBoard
    {
        public static readonly int MaxBoardWidth = 8; 
        public static readonly int MaxBoardHeight = 8;
        public static readonly int MaxPawns = MaxBoardWidth;// chess game rule
        private Piece[,] pieces;
        private int pawns;

        public ChessBoard()
        {
            pieces = new Piece[MaxBoardWidth, MaxBoardHeight];
        }

        /// <summary>
        /// Adds a piece to board
        /// </summary>
        /// <param name="piece"></param>
        /// <param name="xCoordinate">row in range 0..7</param>
        /// <param name="yCoordinate">column in range 0..7</param>
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

        /// <summary>
        /// Checks if co-ordinates are in range of the chess board.
        /// </summary>
        /// <param name="xCoordinate"></param>
        /// <param name="yCoordinate"></param>
        /// <returns></returns>
        public static bool IsLegalBoardPosition(int xCoordinate, int yCoordinate)
        {
            return xCoordinate >= 0 && xCoordinate < MaxBoardWidth &&
                   yCoordinate >= 0 && yCoordinate < MaxBoardHeight;
        }

        /// <summary>
        /// Removes a piece from the board.
        /// </summary>
        /// <param name="xCoordinate"></param>
        /// <param name="yCoordinate"></param>
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
                p.ChessBoard = null;
            }
        }

        /// <summary>
        /// Access a piece on the board.
        /// </summary>
        /// <param name="xCoordinate"></param>
        /// <param name="yCoordinate"></param>
        /// <returns></returns>
        public Piece GetPiece(int xCoordinate, int yCoordinate)
        {
            if (IsLegalBoardPosition(xCoordinate, yCoordinate))
            {
                return pieces[xCoordinate, yCoordinate];
            }
            return null;
        }

        // Checks if a piece can be added to board based on chess rules.
        private bool PieceAllowed(Piece piece)
        {
            // TODO: need to update when more pieces are added
            // rules will likely need to be externalised from ChessBoard.
            switch (piece)
            {
                case Pawn:
                    return pawns < MaxPawns;
                default:
                    return false;
            }
        }
    }
}
