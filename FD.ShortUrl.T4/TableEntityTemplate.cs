using FD.ProjectBuilder.Core.Model;
using System.Collections.Generic;

namespace FD.ShortUrl.T4
{
    public partial class TableEntityTemplate : ITextTemplate
    {
        /// <summary>
        /// Assigns Databases Column Type Name to .NET Type Name.
        /// </summary>
        private readonly Dictionary<string, string> _typeDictionary;

        /// <summary>
        /// Entity's Namespace.
        /// </summary>
        public string NameSpace { get; }

        /// <summary>
        /// Table Data.
        /// </summary>
        public DbTable Table { get; }

        /// <summary>
        /// Creates an Instance of TableEntityTemplate.
        /// </summary>
        /// <param name="typeDictionary">Assigns Databases Column Type Name to .NET Type Name.</param>
        /// <param name="nameSpace">Entity's Namespace.</param>
        /// <param name="table">Table Data.</param>
        public TableEntityTemplate(Dictionary<string, string> typeDictionary, string nameSpace, DbTable table)
            => (_typeDictionary, NameSpace, Table) = (typeDictionary, nameSpace, table);

        /// <summary>
        /// Get .NET Type Name from typeDictionary.
        /// </summary>
        /// <param name="column">Column's Data.</param>
        /// <returns>
        /// Returns typeDictionary's value if found.
        /// Returns <see cref="ColumnInfo.Type"/> if not found.
        /// If the column is nullable, add "?" To the return value.
        /// </returns>
        public string GetColumnType(DbColumn column)
            => _typeDictionary.TryGetValue(column.data_type, out string? n) ? n : column.data_type
                + (column.is_nullable ? "" : "?");
    }
}
