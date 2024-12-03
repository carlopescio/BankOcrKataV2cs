namespace BankOcrV2.tests
{
    [TestClass]
    public class OCRTests
    {
        [TestMethod]
        public void Recognize123456789()
        {
            string row1 = "    _  _     _  _  _  _  _ ";
            string row2 = "  | _| _||_||_ |_   ||_||_|";
            string row3 = "  ||_  _|  | _||_|  ||_| _|";

            OCR o = new();
            Report r = o.Recognize([row1, row2, row3]);
            Assert.AreEqual("123456789", r.ToString());
        }

        [TestMethod]
        public void Recognize000000051()
        {
            string row1 = " _  _  _  _  _  _  _  _    ";
            string row2 = "| || || || || || || ||_   |";
            string row3 = "|_||_||_||_||_||_||_| _|  |";

            OCR o = new();
            Report r = o.Recognize([row1, row2, row3]);
            Assert.AreEqual("000000051", r.ToString());
        }

        [TestMethod]
        public void Recognize444444444()
        {
            string row1 = "                           ";
            string row2 = "|_||_||_||_||_||_||_||_||_|";
            string row3 = "  |  |  |  |  |  |  |  |  |";

            OCR o = new();
            Report r = o.Recognize([row1, row2, row3]);
            Assert.AreEqual("444444444 ERR", r.ToString());
        }

        [TestMethod]
        public void InvalidPattern1()
        {
            string row1 = "    _  _  _  _  _  _     _ ";
            string row2 = "|_||_|| || ||_   |  |  | _ ";
            string row3 = "  | _||_||_||_|  |  |  | _|";

            OCR o = new();
            Report r = o.Recognize([row1, row2, row3]);
            Assert.AreEqual("49006771? ILL", r.ToString());
        }


        [TestMethod]
        public void InvalidPattern2()
        {
            string row1 = "    _  _     _  _  _  _  _ ";
            string row2 = "  | _| _||_| _ |_   ||_||_|";
            string row3 = "  ||_  _|  | _||_|  ||_| _ ";

            OCR o = new();
            Report r = o.Recognize([row1, row2, row3]);
            Assert.AreEqual("1234?678? ILL", r.ToString());
        }
    }
}