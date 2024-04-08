using System.IO;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
namespace FilesService
{
    public class ReadAndWrite : IFile
    {

        public ReadAndWrite(string path)
        {
            this.FilePath = path;

        }
        public ReadAndWrite()
        {
            this.FilePath = Path.Combine(Environment.CurrentDirectory, "File");

        }
        public string FilePath { get; set; }
        public void WriteMessage(string path, string message)
        {
            if (File.Exists(path))
            {
                File.WriteAllText(path, $"{message}\n");
            }
        }
        public void WriteLog(string log, string _path)
        {
            string path = Path.Combine(this.FilePath, _path);

                File.AppendAllText(path, $"{log}\n");
        }
        public void Write<T>(T data, string _path)
        {
            string path = Path.Combine(this.FilePath, _path);
            string json = File.ReadAllText(path);
            List<T> TList;
            if (json == null || json == ""||json=="\n")
                TList = new List<T>();

            else
            {
                TList = JsonSerializer.Deserialize<List<T>>(json);

            }
            TList.Add(data);
            json = JsonSerializer.Serialize(TList);
            WriteMessage(path, json);


        }

        public List<T> Read<T>(string _path)
        {
            string path = Path.Combine(this.FilePath, _path);
            string json = File.ReadAllText(path);
            if (json != null&& json != ""&&json!="\n")
            {
                var TList= JsonSerializer.Deserialize<List<T>>(json);
                return TList;
            }
            List<T> l=new List<T>();    
            return l;

        }

        public void DeleteAllText(string _path)
        {
            string path = Path.Combine(this.FilePath, _path);
            if (File.Exists(path))
            {
                File.Delete(path);
                File.AppendAllText(path, "\n");


            }

        }
        public void Update<T>(string _path, List<T> list)
        {
            string path = Path.Combine(this.FilePath, _path);
            string json = JsonSerializer.Serialize(list);
            WriteMessage(path, json);
        }

    }
}
