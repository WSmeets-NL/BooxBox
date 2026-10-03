using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using BooxBox.Models;

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

        public async Task<List<Book>> GetAllBooks()
        {
            await Init();
            return await database.Table<Book>().ToListAsync();
        }

        public async Task<List<Bookcase>> GetAllBookcases()
        {
            await Init();
            return await database.Table<Bookcase>().ToListAsync();
        }

        public async Task<List<BookCollection>> GetAllBookCollections()
        {
            await Init();
            return await database.Table<BookCollection>().ToListAsync();
        }
    }
}
