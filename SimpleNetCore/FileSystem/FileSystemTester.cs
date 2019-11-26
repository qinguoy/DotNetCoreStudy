using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace QinGY.DotnetCoreStudy.SimpleNetCore.FileSystem
{
    public class FileSystemTester
    {
        public void TestPhysicalFile()
        {
            void Print(int index, string name) => Console.WriteLine($"{new string(' ', index * 4)}{name}");
            IFileManagement manager = new ServiceCollection()
                .AddSingleton<IFileProvider>(new PhysicalFileProvider(@"G:\Pic"))
                .AddSingleton<IFileManagement, FileManagment>()
                .BuildServiceProvider()
                .GetRequiredService<IFileManagement>();

            manager.ShowStructure(Print);
            var content = manager.ReadTextAsync(@"gaob.txt");
            Console.WriteLine(content.Result);
        }
        public void TestEmbeddedFile()
        {
            var assembly = Assembly.GetEntryAssembly();

            var content1 = new ServiceCollection()
                .AddSingleton<IFileProvider>(new EmbeddedFileProvider(assembly))
                .AddSingleton<IFileManagement, FileManagment>()
                .BuildServiceProvider()
                .GetRequiredService<IFileManagement>()
                .ReadTextAsync("data.txt");

            var stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.data.txt");
            var buffer = new byte[stream.Length];
            stream.Read(buffer, 0, buffer.Length);
            var content2 = Encoding.Default.GetString(buffer);
            Console.WriteLine(content1);
            Console.WriteLine(content2);
        }
    }
}
