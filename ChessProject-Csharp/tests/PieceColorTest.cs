using NUnit.Framework;

namespace SolarWinds.MSP.Chess
{
	[TestFixture]
	public class PieceColorTest
	{
		[Test]
		public void Invert_Black()
		{
			PieceColor black = PieceColor.Black;
			Assert.AreEqual(PieceColor.White, black.Invert());
		}

		[Test]
		public void Invert_White()
		{
			PieceColor white = PieceColor.White;
			Assert.AreEqual(PieceColor.Black, white.Invert());
		}
	}
}