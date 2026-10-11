using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using BooxBox.Models;
using System.Text.Json.Nodes;

namespace BooxBox.Data
{
    public class BooxBoxDbWrapper
    {
        public SQLiteAsyncConnection _database { get; private set; }

        async Task Init()
        {
            if (_database is not null)
                return;

            _database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            await _database.CreateTableAsync<Author>();
            await _database.CreateTableAsync<Book>();
            await _database.CreateTableAsync<BookGenre>();
            await _database.CreateTableAsync<BookCollection>();
            await _database.CreateTableAsync<Genre>();
            await _database.CreateTableAsync<Illustrator>();
            await _database.CreateTableAsync<Language>();
            await _database.CreateTableAsync<Models.Location>();
            await _database.CreateTableAsync<Publisher>();

        }

        public async Task<List<Book>> GetAllBooksAsync()
        {
            await Init();
            return await _database.Table<Book>().ToListAsync();
        }

        public async Task<List<Models.Location>> GetAllLocationssAsync()
        {
            await Init();
            return await _database.Table<Models.Location>().ToListAsync();
        }

        public async Task<List<BookCollection>> GetAllBookCollectionsAsync()
        {
            await Init();
            return await _database.Table<BookCollection>().ToListAsync();
        }

        //Create-methods
        public async Task AddBookAsync(Book book)
        {
            await Init();
            await _database.InsertAsync(book);

        }

        public async Task AddAuthorAsync(Author author)
        {
            await Init();
            await _database.InsertAsync(author);
        }

        public async Task<Author> GetAuthorByName(string name)
        {
            await Init();

            Author? author = await _database.Table<Author>().Where(a  => a.Name == name).FirstOrDefaultAsync();

            if (author != null)
            {
                return author;
            }

            else
            {
                Author newAuthor = new Author(name);
                await AddAuthorAsync(newAuthor);
                return newAuthor;
            }

        }
    }
}
