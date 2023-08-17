using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryAppEFCore.DataLayer
{
    public static class ViewExtension
    {
        public static void AddViewViaSql<T>(
            this MigrationBuilder migrationBuilder,
            string viewName, 
            string tableName, 
            string whereSql)
            where T : class
        {
            if (!migrationBuilder.IsSqlServer())                  
                throw new NotImplementedException("This command only works for SQL Server");

            var selectNamesString = string.Join(", ",             
                typeof(T).GetProperties()                     
                .Select(x => x.Name));                            

            var viewSql =
                $"CREATE OR ALTER VIEW {viewName} AS " +          
                $"SELECT {selectNamesString} FROM {tableName} " + 
                $"WHERE {whereSql}";                              

            migrationBuilder.Sql(viewSql);
        }
    }
}
