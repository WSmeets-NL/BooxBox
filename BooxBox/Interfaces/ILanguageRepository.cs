using System;
using System.Collections.Generic;
using System.Text;
using BooxBox.Models;

namespace BooxBox.Interfaces
{
    public interface ILanguageRepository
    {
        Task<List<Language>> GetAllLanguages();

        Task<Language> GetLanguageById(int id);

        Task AddLanguageAsync(Language language);
    }
}
