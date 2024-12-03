namespace BankOcrV2
{
    internal class Glyph
    {
        static internal Glyph FromBitPattern(BitPattern pattern)
        {
            return digits.FirstOrDefault(d => d.Pattern == pattern.Value) ?? new Glyph(pattern.Value);
        }

        private Glyph(byte digit, ushort pattern)
        {
            Value = digit;
            Pattern = pattern;
            IsDigit = true;
        }
        private Glyph(ushort pattern)
        {
            Value = 255;
            Pattern = pattern;
            IsDigit = false;
        }

        public static readonly Glyph[] digits =
            [
            new(0, 0b010101111),
            new(1, 0b000001001),
            new(2, 0b010011110),
            new(3, 0b010011011),
            new(4, 0b000111001),
            new(5, 0b010110011),
            new(6, 0b010110111),
            new(7, 0b010001001),
            new(8, 0b010111111),
            new(9, 0b010111011)
            ];

        private static readonly int RowsPerGlyph = 3;
        internal static readonly int ColumnsPerGlyph = 3;
        internal static readonly int BitsPerGlyph = ColumnsPerGlyph * RowsPerGlyph;

        internal byte Value { get; private set; }
        internal ushort Pattern { get; private set; }
        internal bool IsDigit { get; private set; }
    }
}
