using NUnit.Framework;

namespace SolarWinds.MSP.Chess
{
    [TestFixture]
    public class ChessBoardTest
    {
        private ChessBoard chessBoard;

        [SetUp]
        public void SetUp()
        {
            chessBoard = new ChessBoard();
        }

        [Test]
        public void Has_MaxBoardWidth_of_7()
        {
            Assert.AreEqual(7, ChessBoard.MaxBoardWidth);
        }

        [Test]
        public void Has_MaxBoardHeight_of_7()
        {
            Assert.AreEqual(7, ChessBoard.MaxBoardHeight);
        }

        // Simplifying by doing boundary checks
        [TestCase(0, 0, true)]
        [TestCase(0, 7, true)]
        [TestCase(7, 0, true)]
        [TestCase(7, 7, true)]
        [TestCase(8, 0, false)]
        [TestCase(0, 8, false)]
        [TestCase(-1, 0, false)]
        [TestCase(0, -1, false)]
        public void IsLegalBoardPosition_True(int xPos, int yPos, bool expected)
        {
            var isValidPosition = ChessBoard.IsLegalBoardPosition(xPos, yPos);
            Assert.AreEqual(expected, isValidPosition);
        }

        [Test]
        public void Avoids_Duplicate_Positioning()
        {
            Pawn firstPawn = new Pawn(PieceColor.Black);
            Pawn secondPawn = new Pawn(PieceColor.Black);
            chessBoard.Add(firstPawn, 6, 3);
            chessBoard.Add(secondPawn, 6, 3);
            Assert.AreEqual(6, firstPawn.XCoordinate);
            Assert.AreEqual(3, firstPawn.YCoordinate);
            Assert.AreEqual(-1, secondPawn.XCoordinate);
            Assert.AreEqual(-1, secondPawn.YCoordinate);
        }

        [Test]
        public void Limits_The_Number_Of_Pawns()
        {
            // place black pawns on the starting row and any 
            // overspill on the row below
            for (int i = 0; i < 10; i++)
            {
                Pawn pawn = new Pawn(PieceColor.Black);
                int column = i % (ChessBoard.MaxBoardWidth + 1);
                int row = 6 - i / (ChessBoard.MaxBoardWidth + 1);
                chessBoard.Add(pawn, column, row);
                if (row == 6)
                {
                    Assert.AreEqual(column, pawn.XCoordinate);
                    Assert.AreEqual(row, pawn.YCoordinate);
                }
                else
                {
                    Assert.AreEqual(-1, pawn.XCoordinate);
                    Assert.AreEqual(-1, pawn.YCoordinate);
                }
            }
        }

        public void Limit_Updated_Removed_Pawn()
        {
            for (int i = 0; i < 8; i++)
            {
                Pawn p = new Pawn(PieceColor.White);
                chessBoard.Add(p, i, 1);
                Assert.AreEqual(i, p.XCoordinate);
                Assert.AreEqual(1, p.YCoordinate);
            }
            Pawn pawn = new Pawn(PieceColor.White);
            chessBoard.Add(pawn, 0, 2);
            Assert.AreEqual(-1, pawn.XCoordinate);
            Assert.AreEqual(-1, pawn.YCoordinate);
            chessBoard.Remove(0, 1);
            chessBoard.Add(pawn, 0, 2);
            Assert.AreEqual(0, pawn.XCoordinate);
            Assert.AreEqual(2, pawn.YCoordinate);
        }
    }
}
