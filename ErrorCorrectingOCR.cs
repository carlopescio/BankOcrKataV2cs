

namespace BankOcrV2
{
    public class ErrorCorrectingOCR : OCR
    {
        public override Report Recognize(string[] rows)
        {
            Glyph[] digits = RecognizeDigits(rows);
            AccountNumber an = new(digits);

            if(an.HasInvalidDigits)
                return TryFixingInvalidDigits(digits, an);

            an.Validate();
            if(an.HasInvalidChecksum)
                return TryFixingInvalidChecksum(digits, an);

            return new Report(an);
        }

        private Report TryFixingInvalidChecksum(Glyph[] digits, AccountNumber an)
        {
            List<AccountNumber> outcomes = [];
            for(int i = 0; i < digits.Length; ++i)
            {
                outcomes.AddRange(TryAllReplacementsForSingleDigit(digits, i));
            }
            return new Report(an, outcomes);
        }

        private Report TryFixingInvalidDigits(Glyph[] digits, AccountNumber an)
        {
            int countInvalidDigits = digits.Count(d => !d.IsDigit);
            if(countInvalidDigits > 1)
                return new Report(an);
            else
                return TryFixingSingleInvalidDigit(digits, an);
        }

        private Report TryFixingSingleInvalidDigit(Glyph[] digits, AccountNumber an)
        {
            int n = Array.FindIndex(digits, d => !d.IsDigit);
            List<AccountNumber> outcomes = TryAllReplacementsForSingleDigit(digits, n);
            return new Report(an, outcomes);
        }

        private List<AccountNumber> TryAllReplacementsForSingleDigit(Glyph[] digits, int n)
        {
            IEnumerable<Glyph> alternatives = FixupTable.ReplacementsFor(digits[n]);
            List<AccountNumber> outcomes = [];
            Glyph[] scrap = [.. digits]; // that's a type-safe Clone :-)
            foreach(Glyph a in alternatives)
            {
                scrap[n] = a;
                AccountNumber tentative = new(scrap);
                tentative.Validate();
                if(!tentative.HasInvalidChecksum)
                {
                    outcomes.Add(tentative);
                    scrap = [.. digits];
                }
            }

            return outcomes;
        }
    }
}
