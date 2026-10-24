using BooxBox.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
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
            await _database.CreateTableAsync<BookBookCollection>();
            await _database.CreateTableAsync<BookCollection>();
            await _database.CreateTableAsync<BookGenre>();
            await _database.CreateTableAsync<Genre>();
            await _database.CreateTableAsync<Illustrator>();
            await _database.CreateTableAsync<Language>();
            await _database.CreateTableAsync<BookLocation>();
            await _database.CreateTableAsync<Publisher>();

        }

        //Book-methodes

        public async Task<Book> GetBookById(int id)
        {
            await Init();
            Book foundBook = await _database.Table<Book>().Where(b => b.Id == id).FirstOrDefaultAsync();

            if (foundBook != null)
            {
                return foundBook;
            }

            else
            {
                throw new FileNotFoundException("Sorry, maar we konden dit boek niet vinden.");
            }
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


        public async Task AddPublisherAsync(Publisher publisher)
        {
            await Init();
            await _database.InsertAsync(publisher);
        }

        public async Task AddIllustratorAsync(Illustrator illustrator)
        {
            await Init();
            await _database.InsertAsync(illustrator);
        }
        //Manual-add methodes voor het ophalen van items o.b.v. de ingegeven naam


        public async Task<Publisher> GetPublisherByName(string name)
        {
            await Init();

            Publisher? publisher = await _database.Table<Publisher>().Where(p => p.Name == name).FirstOrDefaultAsync();

            if (publisher != null)
            {
                return publisher;
            }

            else
            {
                Publisher newPublisher = new Publisher(name);
                await AddPublisherAsync(newPublisher);
                return newPublisher;
            }

        }



        public async Task<Illustrator> GetIllustratorByName(string name)
        {
            await Init();

            Illustrator? illustrator = await _database.Table<Illustrator>().Where(i => i.Name == name).FirstOrDefaultAsync();

            if (illustrator != null)
            {
                return illustrator;
            }

            else
            {
                Illustrator newIllustrator = new Illustrator(name);
                await AddIllustratorAsync(newIllustrator);
                return newIllustrator;
            }

        }
    }
}
