namespace BankOcrV2.tests
{
    [TestClass]
    public class TestGlyph
    {
        [TestMethod]
        public void TwoIsValid()
        {
            BitPattern bp = new();
            bp.Concat(0b010011110, 9);
            Glyph two = Glyph.FromBitPattern(bp);
            Assert.IsTrue(two.IsDigit);
            Assert.AreEqual(2, two.Value);
        }

        [TestMethod]
        public void AlteredTwoINotsValid()
        {
            BitPattern bp = new();
            bp.Concat(0b110011110, 9);
            Glyph notTwo = Glyph.FromBitPattern(bp);
            Assert.IsFalse(notTwo.IsDigit);
        }
    }
}
