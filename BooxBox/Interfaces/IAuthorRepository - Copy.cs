using BooxBox.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BooxBox.Interfaces
{
    public interface IIllustratorRepository
    {
        Task AddIllustrator(Illustrator illustrator);

        Task<Illustrator>? GetIllustratorById(int id);
        Task<Illustrator>? GetIllustratorByName(string name);
        Task<String>? GetIllustratorName(int id);
        Task<List<Illustrator>> GetAllIllustrators();
        Task UpdateIllustrator (Illustrator illustrator);
        Task DeleteIllustratorById (int id);
    }
}
