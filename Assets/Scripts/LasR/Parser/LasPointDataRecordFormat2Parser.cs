using System.IO;
using LasR.Data;

namespace LasR.Parser
{
    public class LasPointDataRecordFormat2Parser
    {
        public static void Parse(BinaryReader binaryReader, out LasPointDataRecordFormat data)
        {
            data = default;
            data.X = binaryReader.ReadInt32();
            data.Y = binaryReader.ReadInt32();
            data.Z = binaryReader.ReadInt32();
            data.Intensity = binaryReader.ReadUInt16();
            
            var b = binaryReader.ReadByte();
            data.ReturnNumber = (byte)(b & 0b111);
            data.NumberOfReturns = (byte)((b >> 3) & 0b111);
            data.ScanDirectionFlag = ((b >> 6) & 0b1)==1;
            data.EdgeOfFlightLine = ((b >> 7) & 0b1)==1;
            
            data.Classification = binaryReader.ReadByte();
            data.ScanAngleRank = binaryReader.ReadByte();
            data.UserData = binaryReader.ReadByte();
            data.PointSourceID = binaryReader.ReadUInt16();
            data.Red = binaryReader.ReadUInt16();
            data.Green = binaryReader.ReadUInt16();
            data.Blue = binaryReader.ReadUInt16();
        }
    }
}