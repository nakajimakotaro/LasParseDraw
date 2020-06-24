namespace LasR.Data
{
    public struct LasPointDataRecordFormat
    {
        public int X;
        public int Y;
        public int Z;
        public ushort Intensity;
        public byte ReturnNumber;// 3 bits (bits 0, 1, 2) 3 bits
        public byte NumberOfReturns;// (given pulse) 3 bits (bits 3, 4, 5) 3 bits
        public bool ScanDirectionFlag;// 1 bit (bit 6) 1 bit
        public bool EdgeOfFlightLine;// 1 bit (bit 7) 1 bit
        public byte Classification;
        public byte ScanAngleRank;// (-90 to +90) – Left side unsigned char 1 byte
        public byte UserData;
        public ushort PointSourceID;
        public double GpsTime;
        public ushort Red;
        public ushort Green;
        public ushort Blue;
    }
}