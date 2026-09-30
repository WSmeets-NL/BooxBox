using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using BooxBox.Models

namespace BooxBox.Data
{
    public class BooxBoxDbWrapper
    {
        SQLiteAsyncConnection database;

        async Task Init()
        {
            if (database is not null)
                return;

            database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            await database.CreateTableAsync<Book>();
            await database.CreateTableAsync<Bookcase>();
            await database.CreateTableAsync<BookCollection>();

        }
    }
}
