using System;

namespace SolarWinds.MSP.Chess
{
    public class Pawn
    {
        private ChessBoard chessBoard;
        private int xCoordinate = -1;
        private int yCoordinate = -1;
        private PieceColor pieceColor;
        
        public ChessBoard ChessBoard
        {
            get { return chessBoard; }
            set { chessBoard = value; }
        }

        public int XCoordinate
        {
            get { return xCoordinate; }
            set { xCoordinate = value; }
        }
        
        public int YCoordinate
        {
            get { return yCoordinate; }
            set { yCoordinate = value; }
        }

        public PieceColor PieceColor
        {
            get { return pieceColor; }
            private set { pieceColor = value; }
        }

        public Pawn(PieceColor pieceColor)
        {
            this.pieceColor = pieceColor;
        }

        public void Move(MovementType movementType, int newX, int newY)
        {
            if (chessBoard == null || !chessBoard.IsLegalBoardPosition(newX, newY))
            {
                return;
            }
            int dx = newX - xCoordinate;
            int dy = pieceColor == PieceColor.White ?
                       newY - yCoordinate : yCoordinate - newY;
            switch (movementType)
            {
                case MovementType.Move:
                    if (dx == 0 && dy == 1 && null == chessBoard.GetPawn(newX, newY))
                    {
                        xCoordinate = newX;
                        yCoordinate = newY;
                    }
                    break;
                case MovementType.Capture:
                    Pawn p = chessBoard.GetPawn(newX, newY);
                    if (p != null)
                    {
                        PieceColor c = p.PieceColor;
                        if ((dx == 1 || dx == -1) && dy == 1 &&
                             PieceColor == c.Invert())
                        {
                            xCoordinate = newX;
                            yCoordinate = newY;
                        }
                    }
                    break;
            }
        }

        public override string ToString()
        {
            return CurrentPositionAsString();
        }

        protected string CurrentPositionAsString()
        {
            string nl = Environment.NewLine;
            return $"Current X: {XCoordinate}{nl}Current Y: {YCoordinate}{nl}Piece Color: {PieceColor}";
        }

    }
}
