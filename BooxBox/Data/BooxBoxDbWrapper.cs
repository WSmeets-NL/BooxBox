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


        public async Task<SQLiteAsyncConnection> GetConnectionAsync()
        {
            if (_database is not null)
                return _database;
            else
            {
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
                return _database;
            }

        }

    }
}
