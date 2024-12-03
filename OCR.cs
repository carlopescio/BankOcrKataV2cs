using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOcrV2
{
    public class OCR
    {
        public virtual Report Recognize(string[] rows)
        {
            Glyph[] digits = RecognizeDigits(rows);
            AccountNumber an = new(digits);
            an.Validate();
            return new Report(an);
        }


        internal Glyph[] RecognizeDigits(string[] rows)
        {
            BinaryImage img = new(rows);
            BitPattern[] figures = img.ToBitPatterns();
            Glyph[] digits = new Glyph[figures.Length];

            for(int i = 0; i < figures.Length; ++i)
            {
                digits[i] = Glyph.FromBitPattern(figures[i]);
            }

            return digits;
        }
    }
}
