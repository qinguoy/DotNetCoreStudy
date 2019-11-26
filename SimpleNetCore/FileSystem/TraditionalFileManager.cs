using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace QinGY.DotnetCoreStudy.SimpleNetCore.FileSystem
{
    public class TraditionalFileManager : IFileManagement
    {
        public Task<string> ReadTextAsync(string filePath)
        {
            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                var buffer = new byte[stream.Length];
                StreamReader reader = new StreamReader(stream);
                return reader.ReadToEndAsync();
            }
        }

        public void ShowStructure(Action<int, string> action)
        {
            var indent = -1;
            Render("");
            void Render(string subPath)
            {
                indent++;
                var files = Directory.GetFiles(subPath);
                foreach (var fileItem in files)
                {
                    action(indent, fileItem);
                }
                foreach (var directoryItem in Directory.GetDirectories(subPath))
                {
                    Render(directoryItem);
                }
                indent--;
            }
        }
    }
}
