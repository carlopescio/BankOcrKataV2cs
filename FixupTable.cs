namespace BankOcrV2
{
    internal static class FixupTable
    {
        static FixupTable()
        {
            for(int i = 0; i < neighbourDigits.Length; ++i)
                neighbourDigits[i] = [];

            foreach(Glyph g in Glyph.digits)
            {
                IEnumerable<ushort> neighbours = HammingOneNeighbours(Glyph.BitsPerGlyph, g.Pattern);
                foreach(ushort n in neighbours)
                {
                    neighbourDigits[n].Add(g);
                }
            }
        }

        internal static IEnumerable<Glyph> ReplacementsFor(Glyph g)
        {
            return neighbourDigits[g.Pattern];
        }

        private static IEnumerable<ushort> HammingOneNeighbours(int bits, ushort pattern)
        {
            ushort mask = 1;
            for(int i = 0; i < bits; ++i)
            {
                yield return (ushort)(pattern ^ mask);
                mask <<= 1;
            }
        }

        private static readonly List<Glyph>[] neighbourDigits = new List<Glyph>[1 << Glyph.BitsPerGlyph];
    }
}
