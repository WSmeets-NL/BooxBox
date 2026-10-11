using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using BooxBox.Models;

namespace BooxBox.Data
{
    public class BooxBoxDbWrapper
    {
        public SQLiteAsyncConnection database { get; private set; }

        async Task Init()
        {
            if (database is not null)
                return;

            database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            await database.CreateTableAsync<Author>();
            await database.CreateTableAsync<Book>();
            await database.CreateTableAsync<BookGenre>();
            await database.CreateTableAsync<BookCollection>();
            await database.CreateTableAsync<Genre>();
            await database.CreateTableAsync<Illustrator>();
            await database.CreateTableAsync<Language>();
            await database.CreateTableAsync<Models.Location>();
            await database.CreateTableAsync<Publisher>();

        }

        public async Task<List<Book>> GetAllBooksAsync()
        {
            await Init();
            return await database.Table<Book>().ToListAsync();
        }

        public async Task<List<Models.Location>> GetAllLocationssAsync()
        {
            await Init();
            return await database.Table<Models.Location>().ToListAsync();
        }

        public async Task<List<BookCollection>> GetAllBookCollectionsAsync()
        {
            await Init();
            return await database.Table<BookCollection>().ToListAsync();
        }

        public async Task AddBookAsync(Book book)
        {
            await Init();
            await database.InsertAsync(book);

        }
    }
}
