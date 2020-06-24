namespace LasR.Data
{
    public struct LasHeader
    {
        public char[] FileSignature;//4bites
        public ushort FileSourceID;
        public ushort GlobalEncoding;
        public uint ProjectIDGUIDData1;
        public ushort ProjectIDGUIDData2;
        public ushort ProjectIDGUIDData3;
        public byte[] ProjectIDGUIDData4; //8bytes
        public byte VersionMajor;
        public byte VersionMinor;
        public char[] SystemIdentifier;//32bytes
        public char[] GeneratingSoftware;//32bytes
        public ushort FileCreationDayOfYear;
        public ushort FileCreationYear;
        public ushort HeaderSize;
        public uint OffsetToPointData;
        public uint NumberOfVariableLengthRecords;
        public byte PointDataRecordFormat;
        public ushort PointDataRecordLength;
        public uint LegacyNumberOfPointRecords;
        public uint[] LegacyNumberOfPointByReturn;//20bytes
        public double XScaleFactor;
        public double YScaleFactor;
        public double ZScaleFactor;
        public double XOffset;
        public double YOffset;
        public double ZOffset;
        public double MaxX;
        public double MinX;
        public double MaxY;
        public double MinY;
        public double MaxZ;
        public double MinZ;
        public ulong StartOfWaveformDataPacketRecord;
        public ulong StartOfFirstExtendedVariableLengthRecord;
        public uint NumberOfExtendedVariableLengthRecords;
        public ulong NumberOfPointRecords;
        public ulong[] NumberOfPointsByReturn; //120bytes
    }
}