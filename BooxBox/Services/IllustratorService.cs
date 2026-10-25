using BooxBox.Repos;
using BooxBox.Interfaces;
using BooxBox.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BooxBox.Services
{
    public class IllustratorService
    {
        private readonly IIllustratorRepository _Repo;

        public IllustratorService(IIllustratorRepository illustratorRepository)
        {
            _Repo = illustratorRepository;
        }

        public async Task AddIllustrator(Illustrator illustrator)
        {
            _Repo.AddIllustrator(illustrator);
        }

        public async Task<Illustrator>? GetIllustratorById(int id)
        {
            Illustrator? illustrator = await _Repo.GetIllustratorById(id);
            return illustrator;
        }

        public async Task<Illustrator>? GetIllustratorByName(string name)
        {
            Illustrator? illustrator = await _Repo.GetIllustratorByName(name);
            return illustrator;            
        }

        public async Task<string> GetIllustratorName(int id)
        {
            string illustratorName = await _Repo.GetIllustratorName(id);
            return illustratorName;
        }
    }
}
