using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;
using IrohLang.AST;
using Newtonsoft.Json.Bson;
using Newtonsoft.Json;
using System.IO;

namespace IrohLang.PackageManager
{
    internal static class ZkEncoder
    {
        public static async Task<byte[]> Encode(IrohProgram ast)
        {
            using var bsonStream = new MemoryStream();
            var serailzer = new JsonSerializer();
            var bsonWriter = new BsonDataWriter(bsonStream);
            serailzer.Serialize(bsonWriter, ast);

            using var brotliStream = new MemoryStream();
            var brotliWriter = new BrotliStream(brotliStream, CompressionLevel.Fastest);
            await brotliWriter.WriteAsync(bsonStream.ToArray());
            return brotliStream.ToArray();
        }

        public static async Task<IrohProgram> Decode(Stream inputStream) 
        {
            using var brotliStream = new BrotliStream(inputStream, CompressionLevel.Fastest);
            using var outputStream = new MemoryStream();
            await brotliStream.CopyToAsync(outputStream);

            var reader = new BsonDataReader(outputStream);
            var serializer = new JsonSerializer();
            var ast = serializer.Deserialize<IrohProgram>(reader);
            return ast;
        }
    }
}
