namespace BankOcrV2.tests
{
    [TestClass]
    public class OCRBadChecksumTests
    {
        [TestMethod]
        public void Fixable711111111()
        {
            string row1 = "                           ";
            string row2 = "  |  |  |  |  |  |  |  |  |";
            string row3 = "  |  |  |  |  |  |  |  |  |";

            ErrorCorrectingOCR o = new();
            Report r = o.Recognize([row1, row2, row3]);
            Assert.AreEqual("711111111", r.ToString());
        }

        [TestMethod]
        public void Fixable777777177()
        {
            string row1 = " _  _  _  _  _  _  _  _  _ ";
            string row2 = "  |  |  |  |  |  |  |  |  |";
            string row3 = "  |  |  |  |  |  |  |  |  |";

            ErrorCorrectingOCR o = new();
            Report r = o.Recognize([row1, row2, row3]);
            Assert.AreEqual("777777177", r.ToString());
        }

        [TestMethod]
        public void Fixable200800000()
        {
            string row1 = " _  _  _  _  _  _  _  _  _ ";
            string row2 = " _|| || || || || || || || |";
            string row3 = "|_ |_||_||_||_||_||_||_||_|";

            ErrorCorrectingOCR o = new();
            Report r = o.Recognize([row1, row2, row3]);
            Assert.AreEqual("200800000", r.ToString());
        }

        [TestMethod]
        public void Fixable333393333()
        {
            string row1 = " _  _  _  _  _  _  _  _  _ ";
            string row2 = " _| _| _| _| _| _| _| _| _|";
            string row3 = " _| _| _| _| _| _| _| _| _|";

            ErrorCorrectingOCR o = new();
            Report r = o.Recognize([row1, row2, row3]);
            Assert.AreEqual("333393333", r.ToString());
        }

        [TestMethod]
        public void Unfixable888888888()
        {
            string row1 = " _  _  _  _  _  _  _  _  _ ";
            string row2 = "|_||_||_||_||_||_||_||_||_|";
            string row3 = "|_||_||_||_||_||_||_||_||_|";

            ErrorCorrectingOCR o = new();
            Report r = o.Recognize([row1, row2, row3]);
            Assert.AreEqual("888888888 AMB ['888886888', '888888880', '888888988']", r.ToString());
        }

        [TestMethod]
        public void Unfixable555555555()
        {
            string row1 = " _  _  _  _  _  _  _  _  _ ";
            string row2 = "|_ |_ |_ |_ |_ |_ |_ |_ |_ ";
            string row3 = " _| _| _| _| _| _| _| _| _|";

            ErrorCorrectingOCR o = new();
            Report r = o.Recognize([row1, row2, row3]);
            Assert.AreEqual("555555555 AMB ['555655555', '559555555']", r.ToString());
        }
        

        [TestMethod]
        public void Unfixable666666666()
        {
            string row1 = " _  _  _  _  _  _  _  _  _ ";
            string row2 = "|_ |_ |_ |_ |_ |_ |_ |_ |_ ";
            string row3 = "|_||_||_||_||_||_||_||_||_|";

            ErrorCorrectingOCR o = new();
            Report r = o.Recognize([row1, row2, row3]);
            Assert.AreEqual("666666666 AMB ['666566666', '686666666']", r.ToString());
        }

        [TestMethod]
        public void Unfixable999999999()
        {
            string row1 = " _  _  _  _  _  _  _  _  _ ";
            string row2 = "|_||_||_||_||_||_||_||_||_|";
            string row3 = " _| _| _| _| _| _| _| _| _|";

            ErrorCorrectingOCR o = new();
            Report r = o.Recognize([row1, row2, row3]);
            Assert.AreEqual("999999999 AMB ['899999999', '993999999', '999959999']", r.ToString());
        }
        

        [TestMethod]
        public void Unfixable490067715()
        {
            string row1 = "    _  _  _  _  _  _     _ ";
            string row2 = "|_||_|| || ||_   |  |  ||_ ";
            string row3 = "  | _||_||_||_|  |  |  | _|";

            ErrorCorrectingOCR o = new();
            Report r = o.Recognize([row1, row2, row3]);
            Assert.AreEqual("490067715 AMB ['490067115', '490067719', '490867715']", r.ToString());
        }
    }
}