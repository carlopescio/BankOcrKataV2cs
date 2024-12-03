namespace BankOcrV2.tests
{
    [TestClass]
    public class TestFixupTable
    {
        [TestMethod]
        public void FixingABadTwo()
        {
            BitPattern bp = new();
            bp.Concat(0b110011110, 9);
            Glyph notTwo = Glyph.FromBitPattern(bp);
            List<Glyph> l = FixupTable.ReplacementsFor(notTwo).ToList();
            CollectionAssert.Contains(l, Glyph.digits[2]);
        }

        [TestMethod]
        public void FiveIsOneFromNineAndSix()
        {
            List<Glyph> l = FixupTable.ReplacementsFor(Glyph.digits[5]).ToList();
            CollectionAssert.Contains(l, Glyph.digits[6]);
            CollectionAssert.Contains(l, Glyph.digits[9]);
        }
    }
}
