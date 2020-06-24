using System.IO;
using LasR.Data;
using LasR.Parser;

namespace LasR
{
    public static class LasReader
    {
        public static void Read(Stream stream, out LasData data)
        {
            using (var binaryStream = new BinaryReader(stream))
            {
                LasHeaderParser.Parse(binaryStream, out data.Header);
                data.LasVLRs = new LasVLR[data.Header.NumberOfVariableLengthRecords];
                for (var i = 0; i < data.Header.NumberOfVariableLengthRecords; i++)
                {
                    LasVLRParser.Parse(binaryStream, out data.LasVLRs[i]);
                }

                binaryStream.BaseStream.Position = data.Header.OffsetToPointData;
                data.LasPointDataRecordFormats = new LasPointDataRecordFormat[data.Header.LegacyNumberOfPointRecords];
                for(var i = 0uL;i < data.Header.LegacyNumberOfPointRecords;i++)
                {
                    LasPointDataRecordFormat2Parser.Parse(binaryStream, out data.LasPointDataRecordFormats[i]);
                }
            }
        }
    }
}
