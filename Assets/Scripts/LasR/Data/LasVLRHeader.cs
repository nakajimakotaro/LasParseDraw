namespace LasR.Data
{
    public struct LasVLRHeader
    {
        public ushort Reserved;
        public char[] UserID; //16bytes
        public ushort RecordID;
        public ushort RecordLengthAfterHeader;
        public char[] Description; //32bytes
    }
}