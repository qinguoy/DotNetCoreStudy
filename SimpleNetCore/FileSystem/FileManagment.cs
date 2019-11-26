using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.Extensions.FileProviders;
using System.Threading.Tasks;
using Microsoft.Extensions.Primitives;

namespace QinGY.DotnetCoreStudy.SimpleNetCore.FileSystem
{
    public class FileManagment : IFileManagement
    {
        private readonly IFileProvider fileProvider = null;
        public FileManagment(IFileProvider provider)
        {
            this.fileProvider = provider;
        }

        public async Task<string> ReadTextAsync(string filePath)
        {
            byte[] buffer;
            using (var stream = fileProvider.GetFileInfo(filePath).CreateReadStream())
            {
                buffer = new byte[stream.Length];
                await stream.ReadAsync(buffer,0, buffer.Length);
            }
            return Encoding.Default.GetString(buffer);
        }

        public void ShowStructure(Action<int, string> action)
        {
            int indent = -1;
            Render("");
            void Render(string subpath)
            {
                indent++;
                foreach (var fileItem in fileProvider.GetDirectoryContents(subpath))
                {
                    action(indent, fileItem.Name);
                    if (fileItem.IsDirectory)
                    {
                        string path = $@"{subpath}\{fileItem.Name}".TrimStart('\\');
                        Render(path);
                    }
                }
                indent--;
            }
        }
        public async void  WatchFile(string filePath)
        {
            using (var fileProvider = new PhysicalFileProvider(filePath))
            {
                string original = null;
                ChangeToken.OnChange(() => fileProvider.Watch("data.txt"), Callback);
                while (true)
                {
                    File.WriteAllText(@"c:\test\data.txt", DateTime.Now.ToString());
                    await Task.Delay(5000);
                }

                async void Callback()
                {
                    var stream = fileProvider.GetFileInfo("data.txt").CreateReadStream();
                    {
                        var buffer = new byte[stream.Length];
                        await stream.ReadAsync(buffer, 0, buffer.Length);
                        string current = Encoding.Default.GetString(buffer);
                        if (current != original)
                        {
                            Console.WriteLine(original = current);
                        }
                    }
                }
            }
        }

    }
}
