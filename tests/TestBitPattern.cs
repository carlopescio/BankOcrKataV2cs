namespace BankOcrV2.tests
{
    [TestClass]
    public class TestBitPattern
    {
        [TestMethod]
        public void TwoIsValid()
        {
            BitPattern bp = new();
            bp.Concat(0b010, 3);
            bp.Concat(0b011, 3);
            bp.Concat(0b110, 3);
            Assert.AreEqual(0b010011110, bp.Value);
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
