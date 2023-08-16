using System.IO;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.Text.Json.Nodes;
using System.Security.AccessControl;
using System.Diagnostics.CodeAnalysis;
using ErrorOr;
using MyCV.Domain.Entities;

namespace MyCV.Infrastructure.Persistence
{
    public class ApplicationJsonRepository<T>
    {
        private string _jsonPath = string.Empty;

        public ApplicationJsonRepository(string jsonPath)
        {
            _jsonPath = jsonPath;
        }

        public async Task<List<T>> ReadJsonFile()
        {

            List<T> objectList = new List<T>();

            try {

                await Task.Run(() =>{

                    string FileJson = File.ReadAllText(_jsonPath);
                    objectList =  JsonConvert.DeserializeObject<List<T>>(FileJson);
                });

                return objectList;
            }
            catch (Exception e)
            {
               throw new Exception("Error reading json file: " + e.Message);
            }

        }

        public async Task<bool> WriteJsonFile(T data)
        {
            try
            {
                var existingObjects = await ReadJsonFile();
              
 
                // string jsonData = JsonSerializer.Serialize(data, new JsonConvert. JsonSerializerOptions
                // {
                //     WriteIndented = true
                // });
                
                existingObjects.Append(data);

                using (StreamWriter sw = new StreamWriter(_jsonPath))
                {
                    sw.Write(existingObjects);
                }
                return true;
            }
            catch (Exception e)
            {
                 throw new Exception("Error writting json file: " + e.Message);
                 
            }
        }
    }
}