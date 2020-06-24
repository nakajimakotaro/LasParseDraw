using System.IO;
using LasR.Data;

namespace LasR.Parser
{
    public static class LasVLRHeaderParser
    {
        public static void Parse(BinaryReader binaryReader, out LasVLRHeader header)
        {
            header.Reserved = binaryReader.ReadUInt16();
            header.UserID = binaryReader.ReadChars(16);
            header.RecordID = binaryReader.ReadUInt16();
            header.RecordLengthAfterHeader = binaryReader.ReadUInt16();
            header.Description = binaryReader.ReadChars(32);
        }
    }
}