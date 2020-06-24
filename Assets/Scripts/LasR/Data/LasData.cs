namespace LasR.Data
{
    public struct LasData
    {
        public LasHeader Header;
        public LasVLR[] LasVLRs;
        public LasPointDataRecordFormat[] LasPointDataRecordFormats;
    }
}