using FD.ProjectBuilder.Core.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.ShortUrl.T4
{
    internal class Program
    {
        static void Main()
        {
            var typeDef = new Dictionary<string, string>()
            {
                { "NUMBER", "int" },
                { "VARCHAR2", "string" },
                 { "NVARCHAR2", "string" },
                { "DATE", "DateTime" },
            };
            var path = System.AppDomain.CurrentDomain.BaseDirectory;
            var dbHelper = new DbHelper();
            var dbClient = dbHelper.GetDbInstance();

            //var tables = dbClient.DbSchema.GetTableInfoList();
            //foreach (var table in tables)
            //{
            //    table.columns = dbClient.DbSchema.GetColumnInfosByTableName(table.name);
            //    ITextTemplate template = new TableEntityTemplate(typeDef,"FD.ShortUrl", table);
            //    File.WriteAllText(path + table.name + ".cs", template.TransformText());
            //}

            var table = new DbTable("T_SHORT_URL");
            var columns = dbClient.DbSchema.GetColumnInfosByTableName(table.name);
            table.columns = columns;

            ITextTemplate template = new TableEntityTemplate(typeDef, "FD.ShortUrl", table);         
            File.WriteAllText(path + table.name + ".cs", template.TransformText());

            //Console.WriteLine(template.TransformText());
        }
    }
}
