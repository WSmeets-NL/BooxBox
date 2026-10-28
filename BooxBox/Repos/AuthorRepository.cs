using BooxBox.Data;
using BooxBox.Interfaces;
using BooxBox.Models;
using SQLitePCL;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace BooxBox.Repos
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly BooxBoxDbWrapper _wrapper;

        public AuthorRepository(BooxBoxDbWrapper wrapper)
        {
            _wrapper = wrapper;
            _wrapper.GetConnectionAsync();
        }

        public async Task AddAuthor(Author author)
        {
            await _wrapper._database.InsertAsync(author);
        }

        public async Task<Author>? GetAuthorById(int id)
        {
            Author author = await _wrapper._database.Table<Author>().Where(author => author.Id == id).FirstOrDefaultAsync();
            if (author != null)
            {
                return author;
            }

            else
            {
                throw new FileNotFoundException();
            }

        }

        public async Task<Author>? GetAuthorByName(string name)
        {
            Author author = await _wrapper._database.Table<Author>().Where(author => author.Name == name).FirstOrDefaultAsync();
            return author;
        }

        public async Task<String>? GetAuthorName(int id)
        {
            Author author = await _wrapper._database.Table<Author>().Where(author => author.Id == id).FirstOrDefaultAsync();
            return author.Name;
        }

        public async Task<List<Author>> GetAllAuthorsAsync()
        {
            return await _wrapper._database.Table<Author>().ToListAsync();
        }

        public async Task UpdateAuthor(Author updatedAuthor)
        {
            Author foundAuthor = await GetAuthorById(updatedAuthor.Id);
            if (foundAuthor != null)
            {
                foundAuthor = updatedAuthor;
                await _wrapper._database.UpdateAsync(foundAuthor);
                return;
            }

            else
            {
                return;
            }
        }

        public async Task DeleteAuthorById(int id)
        {
            Author foundAuthor = await GetAuthorById(id);
            if (foundAuthor != null)
            {
                await _wrapper._database.DeleteAsync(foundAuthor);
            }

            else
            {
                return;
            }
        }

    }
}
