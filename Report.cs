using System.Text;

namespace BankOcrV2
{
    public class Report
    {
        internal Report(AccountNumber an) : this(an, [])
        {
        }

        internal Report(AccountNumber an, List<AccountNumber> fixups)
        {
            if(fixups.Count == 1)
            {
                account = fixups.First();
                attempts = [];
            }
            else
            {
                account = an;
                attempts = fixups;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new();
            sb.Append(account.ToString());

            if(attempts.Count > 0)
            {
                List<String> l = attempts.Select(a => a.ToString()).ToList();
                l.Sort();
                sb.Append(" AMB ['");
                sb.AppendJoin("', '", l);
                sb.Append("']");

            }
            else if(account.HasInvalidDigits)
                sb.Append(" ILL");
            else if(account.HasInvalidChecksum)
                sb.Append(" ERR");

            return sb.ToString();
        }

        private readonly AccountNumber account;
        private readonly List<AccountNumber> attempts;
    }
}
