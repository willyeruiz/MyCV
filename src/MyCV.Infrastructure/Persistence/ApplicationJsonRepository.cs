using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.Text.Json.Nodes;
using System.Security.AccessControl;
using System.Diagnostics.CodeAnalysis;
using ErrorOr;

namespace MyCV.Infrastructure.Persistence
{
    public class ApplicationJsonRepository<T>
    {
        private string _jsonPath = string.Empty;

        public ApplicationJsonRepository(string jsonPath)
        {
            _jsonPath = jsonPath;
        }
        
        public async Task<IEnumerable<T>> ReadJsonFile<T>()
        {
            
            List <T> objectList = new List<T>();
               
            try {
                
                await Task.Run(() =>{
                    
                    using (StreamReader r = new StreamReader(_jsonPath))
                    {
                        string json = r.ReadToEnd();
                        objectList =  JsonSerializer.Deserialize<List<T>>(json);   
                    }
                
                    
                });

                return objectList;
            }
            catch (Exception e)
            {
               throw new Exception("Error reading json file: " + e.Message);
            }

        }
        /*

        "Could not find a part of the path '/Users/williamruiz/MyCVProject/MyCV/MyCV.API/Data/Experiences.json'."
Source [string]:
"System.Private.CoreLib"
StackTrace [string]:
"   en Interop.ThrowExceptionForIoErrno(ErrorInfo errorInfo, String path, Boolean isDirectory, Func`2 errorRewriter)\n   en Microsoft.Win32.SafeHandles.SafeFileHandle.Open(String path, OpenFlags flags, Int32 mode)\n   en Microsoft.Win32.SafeHandles.SafeFileHandle.Open(String fullPath, FileMode mode, FileAccess access, FileShare share, FileOptions options, Int64 preallocationSize)\n   en System.IO.Strategies.OSFileStreamStrategy..ctor(String path, FileMode mode, FileAccess access, FileShare share, FileOptions options, Int64 preallocationSize)\n   en System.IO.Strategies.FileStreamHelpers.ChooseStrategy(FileStream fileStream, String path, FileMode mode, FileAccess access, FileShare share, Int32 bufferSize, FileOptions options, Int64 preallocationSize)\n   en System.IO.StreamWriter.ValidateArgsAndOpenPath(String path, Boolean append, Encoding encoding, Int32 bufferSize)\n   en System.IO.StreamWriter..ctor(String path)\n   en MyCV.Infrastructure.Persistence.ApplicationJsonRepository.<WriteJsonFile>d__3`1.MoveNext...
TargetSite [MethodBase]:
{Void ThrowExceptionForIoErrno(ErrorInfo, System.Stri

        */

        public async Task<bool> WriteJsonFile<T>(T data)
        {
            try
            {
                var existingObjects = await ReadJsonFile<T>();
              
 
                string jsonData = JsonSerializer.Serialize(data, new JsonSerializerOptions
                {
                    WriteIndented = true
                });
                
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