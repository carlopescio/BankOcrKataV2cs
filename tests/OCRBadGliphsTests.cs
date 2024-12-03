namespace BankOcrV2.tests
{
    [TestClass]
    public class OCRBadGliphsTests
    {
        [TestMethod]
        public void SingleBadGlyphFixable1()
        {
            string row1 = "    _  _     _  _  _  _  _ ";
            string row2 = " _| _| _||_||_ |_   ||_||_|";
            string row3 = "  ||_  _|  | _||_|  ||_| _|";

            ErrorCorrectingOCR o = new();
            Report r = o.Recognize([row1, row2, row3]);
            Assert.AreEqual("123456789", r.ToString());
        }

        [TestMethod]
        public void SingleBadGlyphFixable2()
        {
            string row1 = " _     _  _  _  _  _  _     ";
            string row2 = "| || || || || || || ||_   | ";
            string row3 = "|_||_||_||_||_||_||_| _|  | ";

            ErrorCorrectingOCR o = new();
            Report r = o.Recognize([row1, row2, row3]);
            Assert.AreEqual("000000051", r.ToString());
        }

        [TestMethod]
        public void SingleBadGlyphFixable3()
        {
            string row1 = "    _  _  _  _  _  _     _  ";
            string row2 = "|_||_|| ||_||_   |  |  | _  ";
            string row3 = "  | _||_||_||_|  |  |  | _| ";


            ErrorCorrectingOCR o = new();
            Report r = o.Recognize([row1, row2, row3]);
            Assert.AreEqual("490867715", r.ToString());
        }

        [TestMethod]
        public void SingleBadGlyphUnfixable1()
        {
            string row1 = "    _  _  _  _  _  _     _  ";
            string row2 = "|_||_|| ||_||_   |  |  | _  ";
            string row3 = "  | _||_||_||_|  |  |  | _  ";


            ErrorCorrectingOCR o = new();
            Report r = o.Recognize([row1, row2, row3]);
            Assert.AreEqual("49086771? ILL", r.ToString());
        }

        [TestMethod]
        public void SingleBadGlyphUnfixable2()
        {
            string row1 = "    _  _  _  _  _  _     _  ";
            string row2 = "|_||_|| ||_||_   |  |  | _  ";
            string row3 = "  | _||_||_||_|  |  |  ||_  ";

            ErrorCorrectingOCR o = new();
            Report r = o.Recognize([row1, row2, row3]);
            Assert.AreEqual("49086771? ILL", r.ToString());
        }

        [TestMethod]
        public void MultipleBadGlyphsUnfixable()
        {
            string row1 = "    _  _     _  _  _  _  _ ";
            string row2 = " _| _  _||_||_ |_   ||_||_|";
            string row3 = "  ||_  _|  | _||_|  ||_| _|";

            ErrorCorrectingOCR o = new();
            Report r = o.Recognize([row1, row2, row3]);
            Assert.AreEqual("??3456789 ILL", r.ToString());
        }

    }
}