using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Uber.Infrastructure.Data.Configuration
{
    public static class SeedHelper
    {
        public static List<TEntity> SeedData<TEntity>(string fileName)
        { 
            string currentDirecctory = "D:\\UberProject\\Uber\\Uber.Infrastructure";
            string path = "Static";
            string fullPath = Path.Combine(currentDirecctory, path, fileName);
            var result = new List<TEntity>();
            using (StreamReader reader = new StreamReader(fullPath))
            {
                string json = reader.ReadToEnd();
                result = JsonConvert.DeserializeObject<List<TEntity>>(json);
            }
            return result;
        }
    }
}
