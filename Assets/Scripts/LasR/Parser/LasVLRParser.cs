using System.IO;
using LasR.Data;

namespace LasR.Parser
{
    public static class LasVLRParser
    {
        public static void Parse(BinaryReader binaryReader, out LasVLR lasVlr)
        {
            LasVLRHeaderParser.Parse(binaryReader, out lasVlr.LasVlrHeader);
            //TODO 拡張データの処理
            binaryReader.ReadBytes(lasVlr.LasVlrHeader.RecordLengthAfterHeader);
        }
    }
}