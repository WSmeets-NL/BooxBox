using BooxBox.Data;
using BooxBox.Interfaces;
using BooxBox.Models;
using SQLite;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Text;


namespace BooxBox.Repos
{
    public class IllustratorRepository : IIllustratorRepository
    {
        private readonly BooxBoxDbWrapper _wrapper;

        public IllustratorRepository(BooxBoxDbWrapper wrapper)
        {
            _wrapper = wrapper;
            _wrapper.GetConnectionAsync();
        }

        public async Task AddIllustrator(Illustrator illustrator)
        {
            await _wrapper._database.InsertAsync(illustrator);
        }

        public async Task<List<Illustrator>> GetAllIllustrators()
        {
            return await _wrapper._database.Table<Illustrator>().ToListAsync();
        }
        public async Task<Illustrator>? GetIllustratorById(int id)
        { 
            Illustrator illustrator = await _wrapper._database.Table<Illustrator>().Where(i => i.Id == id).FirstOrDefaultAsync();
            if (illustrator != null)
            {
                return illustrator;
            }

            else
            {
                throw new FileNotFoundException();
            }

        }

        public async Task<Illustrator>? GetIllustratorByName(string name)
        {
            Illustrator illustrator = await _wrapper._database.Table<Illustrator>().Where(i => i.Name == name).FirstOrDefaultAsync();
            return illustrator;
        }

        public async Task<String>? GetIllustratorName(int id)
        {
            Illustrator illustrator = await _wrapper._database.Table<Illustrator>().Where(i => i.Id == id).FirstOrDefaultAsync();
            if (illustrator != null)
            {
                return illustrator.Name;
            }

            else
            {
                throw new FileNotFoundException();
            }
        }

        public async Task<List<Illustrator>> GetIllustrators()
        {
            return await _wrapper._database.Table<Illustrator>().ToListAsync();
        }

        public async Task UpdateIllustrator(Illustrator updatedIllustrator)
        {
            Illustrator foundIllustrator = await GetIllustratorById(updatedIllustrator.Id);
            if (foundIllustrator != null)
            {
                foundIllustrator = updatedIllustrator;
                await _wrapper._database.UpdateAsync(foundIllustrator);
                return;
            }

            else
            {
                return;
            }
        }

        public async Task DeleteIllustratorById(int id)
        {
            Illustrator foundIllustrator = await GetIllustratorById(id);
            if (foundIllustrator != null)
            {
                await _wrapper._database.DeleteAsync(foundIllustrator);
            }

            else
            {
                return;
            }
        }

    }
}
