using NUnit.Framework;

namespace SolarWinds.MSP.Chess
{
    [TestFixture]
    public class PawnTest
    {
        private ChessBoard chessBoard;
        private Pawn pawn;

        [SetUp]
        public void SetUp()
        {
            chessBoard = new ChessBoard();
            pawn = new Pawn(PieceColor.Black);
        }

        [Test]
        public void ChessBoard_Add_Sets_XCoordinate()
        {
            chessBoard.Add(pawn, 6, 3);
            Assert.AreEqual(6, pawn.XCoordinate);
        }

        [Test]
        public void ChessBoard_Add_Sets_YCoordinate()
        {
            chessBoard.Add(pawn, 6, 3);
            Assert.AreEqual(3, pawn.YCoordinate);
        }

        [Test]
        public void ChessBoard_Move_No_Chessboard()
        {
            bool moved = pawn.Move(MovementType.Move, 0, 2);
            Assert.AreEqual(false, moved);
            Assert.AreEqual(-1, pawn.YCoordinate);
            Assert.AreEqual(-1, pawn.XCoordinate);

            moved = pawn.Move(MovementType.Capture, 1, 2);
            Assert.AreEqual(false, moved);
            Assert.AreEqual(-1, pawn.YCoordinate);
            Assert.AreEqual(-1, pawn.XCoordinate);
        }

        [Test]
        public void Pawn_Move_IllegalCoordinates_Right_DoesNotMove()
        {
            chessBoard.Add(pawn, 6, 3);
            pawn.Move(MovementType.Move, 7, 3);
            Assert.AreEqual(6, pawn.XCoordinate);
            Assert.AreEqual(3, pawn.YCoordinate);
        }

        [Test]
        public void Pawn_Move_IllegalCoordinates_Left_DoesNotMove()
        {
            chessBoard.Add(pawn, 6, 3);
            pawn.Move(MovementType.Move, 4, 3);
            Assert.AreEqual(6, pawn.XCoordinate);
            Assert.AreEqual(3, pawn.YCoordinate);
        }

        [Test]
        public void Pawn_Move_LegalCoordinates_Forward_Black_UpdatesCoordinates()
        {
            chessBoard.Add(pawn, 6, 3);
            bool moved = pawn.Move(MovementType.Move, 6, 2);
            Assert.AreEqual(true, moved);
            Assert.AreEqual(6, pawn.XCoordinate);
            Assert.AreEqual(2, pawn.YCoordinate);
        }

        [Test]
        public void Pawn_Move_LegalCoordinates_Forward_White_UpdatesCoordinates()
        {
            pawn.PieceColor = PieceColor.White;
            chessBoard.Add(pawn, 4, 1);
            bool moved = pawn.Move(MovementType.Move, 4, 2);
            Assert.AreEqual(true, moved);
            Assert.AreEqual(4, pawn.XCoordinate);
            Assert.AreEqual(2, pawn.YCoordinate);
        }

        [Test]
        public void Pawn_Capture_LegalCoordinates_White_UpdatesCoordinates()
        {
            chessBoard.Add(pawn, 2, 6);
            Pawn pawn2 = new Pawn(PieceColor.White);
            chessBoard.Add(pawn2, 3, 5);
            bool moved = pawn.Move(MovementType.Capture, 3, 5);
            Assert.AreEqual(true, moved);
            Assert.AreEqual(3, pawn.XCoordinate);
            Assert.AreEqual(5, pawn.YCoordinate);
            Assert.AreEqual(-1, pawn2.XCoordinate);
            Assert.AreEqual(-1, pawn2.YCoordinate);
        }

        [Test]
        public void Pawn_Capture_LegalCoordinates_Black_UpdatesCoordinates()
        {
            chessBoard.Add(pawn, 7, 6);
            Pawn pawn2 = new Pawn(PieceColor.White);
            chessBoard.Add(pawn2, 6, 5);
            pawn.Move(MovementType.Capture, 6, 5);
            Assert.AreEqual(6, pawn.XCoordinate);
            Assert.AreEqual(5, pawn.YCoordinate);
            Assert.AreEqual(-1, pawn2.XCoordinate);
            Assert.AreEqual(-1, pawn2.YCoordinate);
        }

        [Test]
        public void Pawn_ToString()
        {
            Assert.AreEqual("Current X: -1\r\nCurrent Y: -1\r\nPiece Color: Black", pawn.ToString());
            chessBoard.Add(pawn, 0, 6);
            Assert.AreEqual("Current X: 0\r\nCurrent Y: 6\r\nPiece Color: Black", pawn.ToString());
        }
    }
}
