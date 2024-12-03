using System.Text;


namespace BankOcrV2
{
    internal class AccountNumber
    {
        internal AccountNumber(Glyph[] figures)
        {
            this.figures = figures;
            HasInvalidDigits = figures.Any(f => !f.IsDigit);
        }

        internal void Validate()
        {
            long checksum = 0;
            for(int i = 0; i < figures.Length; ++i)
                checksum += figures[i].Value * (figures.Length - i);
            HasInvalidChecksum = checksum % 11 != 0;
        }

        public override string ToString()
        {
            StringBuilder sb = new();
            sb.AppendJoin("", figures.Select(g => g.IsDigit ? g.Value.ToString() : "?"));
            return sb.ToString();
        }

        internal bool HasInvalidDigits { get; private set; }
        internal bool HasInvalidChecksum { get; private set; }
        private readonly Glyph[] figures;
    }
}
