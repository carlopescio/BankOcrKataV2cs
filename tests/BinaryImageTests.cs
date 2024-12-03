namespace BankOcrV2.tests
{
    [TestClass]
    public class BinaryImageTests
    {
        [TestMethod]
        public void DigitSplits()
        {
            string row1 = "    _  _     _  _  _  _  _ ";
            string row2 = "  | _| _||_||_ |_   ||_||_|";
            string row3 = "  ||_  _|  | _||_|  ||_| _|";

            BinaryImage bin = new([row1, row2, row3]);
            BitPattern[] digits = bin.ToBitPatterns();
            for(int i = 0; i < 9; ++i)
            {
                Assert.AreEqual(Glyph.digits[i + 1].Pattern, digits[i].Value);
            }
        }
    }
}