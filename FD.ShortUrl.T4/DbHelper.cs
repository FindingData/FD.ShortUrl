using FD.ProjectBuilder.Core;
using FD.ProjectBuilder.Core.Model;
using Microsoft.Extensions.Configuration;

namespace FD.ShortUrl.T4
{
    public class DbHelper
    {
        public DbClient GetDbInstance()
        {

           
            DbClient db = new DbClient(new DBSetting()
            {
                ConnectionString = GetConnStr("ConnectionStrings:BaseDb"),
                DBType = DBType.Oracle,
            });
            return db;
        }


        public string GetConnStr(string alais)
        {
            var config = InitConfiguration();
            return config[alais];
        }

        public IConfiguration InitConfiguration()
        {
            var config = new ConfigurationBuilder()
                 .AddJsonFile($"appsettings.json", true, true)
                 .Build();
            return config;
        }

        public string TransTableToClass(string name)
        {
            string[] words = name.ToLower().Split('_');
            string cName = string.Empty;
            for (int i = 1; i < words.Length; i++)
            {
                cName += words[i].Substring(0, 1).ToUpper() + words[i].Substring(1, words[i].Length - 1);
            }
            return cName;
        }

    }
}