namespace BankOcrV2
{
    internal class BitPattern
    {
        internal void Concat(ushort newBits, int significantBits)
        {
            Value <<= significantBits;
            Value |= newBits;
        }
        internal ushort Value { get; private set; }
    }
}
