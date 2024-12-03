namespace BankOcrV2
{
    internal class BinaryImage(string[] Rows)
    {
        internal BitPattern[] ToBitPatterns()
        {
            BitPattern[] figures = new BitPattern[GlyphsPerRow];
            for(int g = 0; g < GlyphsPerRow; ++g)
            {
                figures[g] = new();
            }

            for(int r = 0; r < Rows.Length; ++r)
            {
                for(int g = 0; g < GlyphsPerRow; ++g)
                {
                    byte b = GlyphSlice(r, g);
                    figures[g].Concat(b, Glyph.ColumnsPerGlyph);
                }
            }

            return figures;
        }

        private byte GlyphSlice(int row, int glyphIndex)
        {
            string textChunk = Rows[row].Substring(glyphIndex * Glyph.ColumnsPerGlyph, Glyph.ColumnsPerGlyph);
            string binaryPattern = textChunk.Replace(' ', '0').Replace('|', '1').Replace('_', '1');
            return Convert.ToByte(binaryPattern, 2);
        }

        private static readonly int GlyphsPerRow = 9;
    }
}
