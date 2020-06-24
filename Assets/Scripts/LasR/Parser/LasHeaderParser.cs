using System.IO;
using LasR.Data;

namespace LasR.Parser
{
    public static class LasHeaderParser
    {
        public static void Parse(BinaryReader binaryReader, out LasHeader header)
        {
            header = default;
            
            header.FileSignature = binaryReader.ReadChars(4);
            header.FileSourceID = binaryReader.ReadUInt16();
            header.GlobalEncoding = binaryReader.ReadUInt16();
            header.ProjectIDGUIDData1 = binaryReader.ReadUInt32();
            header.ProjectIDGUIDData2 = binaryReader.ReadUInt16();
            header.ProjectIDGUIDData3 = binaryReader.ReadUInt16();
            header.ProjectIDGUIDData4 = binaryReader.ReadBytes(8);
            header.VersionMajor = binaryReader.ReadByte();
            header.VersionMinor = binaryReader.ReadByte();
            header.SystemIdentifier = binaryReader.ReadChars(32);
            header.GeneratingSoftware = binaryReader.ReadChars(32);
            header.FileCreationDayOfYear = binaryReader.ReadUInt16();
            header.FileCreationYear = binaryReader.ReadUInt16();
            header.HeaderSize = binaryReader.ReadUInt16();
            header.OffsetToPointData = binaryReader.ReadUInt32();
            header.NumberOfVariableLengthRecords = binaryReader.ReadUInt32();
            header.PointDataRecordFormat = binaryReader.ReadByte();
            header.PointDataRecordLength = binaryReader.ReadUInt16();
            header.LegacyNumberOfPointRecords = binaryReader.ReadUInt32();
            header.LegacyNumberOfPointByReturn = new uint[5];
            for (int i = 0; i < 5; i++)
            {
                header.LegacyNumberOfPointByReturn[i] = binaryReader.ReadUInt32();
            }

            header.XScaleFactor = binaryReader.ReadDouble();
            header.YScaleFactor = binaryReader.ReadDouble();
            header.ZScaleFactor = binaryReader.ReadDouble();
            header.XOffset = binaryReader.ReadDouble();
            header.YOffset = binaryReader.ReadDouble();
            header.ZOffset = binaryReader.ReadDouble();
            header.MaxX = binaryReader.ReadDouble();
            header.MinX = binaryReader.ReadDouble();
            header.MaxY = binaryReader.ReadDouble();
            header.MinY = binaryReader.ReadDouble();
            header.MaxZ = binaryReader.ReadDouble();
            header.MinZ = binaryReader.ReadDouble();
            if (header.VersionMajor == 1 && header.VersionMinor == 2)
            {
                return;
            }
            header.StartOfWaveformDataPacketRecord = binaryReader.ReadUInt64();
            header.StartOfFirstExtendedVariableLengthRecord = binaryReader.ReadUInt64();
            header.NumberOfExtendedVariableLengthRecords = binaryReader.ReadUInt32();
            header.NumberOfPointRecords = binaryReader.ReadUInt64();
            header.NumberOfPointsByReturn = new ulong[15];
            for (int i = 0; i < 15; i++)
            {
                header.NumberOfPointsByReturn[i] = binaryReader.ReadUInt64();
            }
        }
    }
}