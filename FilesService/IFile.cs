using System.IO;
using Microsoft.AspNetCore.Mvc;
namespace  FilesService
{
    public interface IFile{
        void Write<T>(T data,string path);
        void WriteLog(string log, string path);
        List<T> Read<T>(string path);
        void DeleteAllText(string path);
        void Update<T>(string path,List<T> list);
    }
}