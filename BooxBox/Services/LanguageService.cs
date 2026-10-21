using BooxBox.Interfaces;
using BooxBox.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BooxBox.Services
{
    public class LanguageService
    {
        private readonly ILanguageRepository _Repo;

        public LanguageService(ILanguageRepository languageRepository)
        {
            _Repo = languageRepository;
        }

        public async Task<List<Language>> GetAllLanguages()
        {
            return await _Repo.GetAllLanguages();
        }

        public async Task<Language> GetLanguageById(int id)
        {
            return await _Repo.GetLanguageById(id);
        }
    }
}
