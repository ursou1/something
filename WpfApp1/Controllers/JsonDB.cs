using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;

using System.Threading.Tasks;
using WpfApp1.Models;

namespace WpfApp1.Controllers
{
    public class JsonDB<T> : IDB<T> where T : DBObject
    {
        string pathJson;
        int autoincrement;
        
        public JsonDB(string pathJson)
        {
           this.pathJson = pathJson;
            if (!File.Exists(pathJson))
            {
                autoincrement = 1;
                Save(new List<T>());
                return;
            }
          using (var f = File.OpenRead(pathJson))
                using (var br = new BinaryReader(f))
            {
                autoincrement = br.ReadInt32();
            }
        }

        public void Add(T obj)
        {
                     
            obj.ID = autoincrement++;
            var all = GetAll().ToList();
            all.Add(obj);
            Save(all);
        }

        public void Delete(T obj)
        {
            var all = GetAll().ToList();
            var edit = all.FirstOrDefault(g => g.ID == obj.ID);
            if (edit == null)
                return;
            all.Remove(edit);
            Save(all);
        }

        public IEnumerable<T> GetAll()
        {
            DataContractJsonSerializer serializer = new
               DataContractJsonSerializer(typeof(List<T>));
            IEnumerable<T> result = null;
            using (var f = File.OpenRead(pathJson))
            using (var br = new BinaryReader(f))
            {
                f.Seek(4, SeekOrigin.Begin);
                result = (List<T>)
                      serializer.ReadObject(f);
            }
            return result;
        }

        public void Update(T obj)
        {
            var all = GetAll().ToList();
           var edit = all.First(g => g.ID == obj.ID);
            if (edit == null)
                return;
            all.Remove(edit);
            all.Add(obj);
            Save(all);
        }

        void Save(List<T> all)
        {
            DataContractJsonSerializer serializer = new
                DataContractJsonSerializer(typeof(List<T>));
            using (var fs = File.Create(pathJson))
                using (var bw = new BinaryWriter(fs))
            {
                bw.Write(autoincrement);
                serializer.WriteObject(fs, all);
            }
            
        }
    }
}
