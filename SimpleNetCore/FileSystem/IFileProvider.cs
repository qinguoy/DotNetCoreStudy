using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QinGY.DotnetCoreStudy.SimpleNetCore.FileSystem
{
    /// <summary>
    /// 定义文件提供者接口---对应IFileProvider
    /// </summary>
    public interface IFileManagement
    {
        void ShowStructure(Action<int, string> render);
        Task<string> ReadTextAsync(string filePath);
    }
}
