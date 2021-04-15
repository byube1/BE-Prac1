using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIMongoDB.Models
{

    public interface IDatabaseSetting
    {
         string ConnectionString { get; set; }
         string DatabaseName { get; set; }
    }
    public class DatabaseSetting:IDatabaseSetting
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
