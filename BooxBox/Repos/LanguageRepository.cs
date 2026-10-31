
using BooxBox.Data;
using BooxBox.Interfaces;
using BooxBox.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BooxBox.Repos
{
    public class LanguageRepository : ILanguageRepository
    {
        private readonly BooxBoxDbWrapper _wrapper;

        public LanguageRepository(BooxBoxDbWrapper wrapper)
        {
            _wrapper = wrapper;
        }

        public async Task<List<Language>> GetAllLanguages()
        {
            return await _wrapper._database.Table<Language>().ToListAsync();
        }

        public async Task<Language> GetLanguageById(int id)
        {
            Language language = await _wrapper._database.Table<Language>().Where(l => l.Id == id).FirstOrDefaultAsync();
            return language;
        }

        public async Task AddLanguageAsync(Language language)
        {
            await _wrapper._database.InsertAsync(language);
        }
    }
}
