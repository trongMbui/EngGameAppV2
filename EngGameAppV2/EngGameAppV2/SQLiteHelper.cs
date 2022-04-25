using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Threading.Tasks;
using EngGameAppV2.Models;

namespace EngGameAppV2
{
    public class SQLiteHelper
    {
        private readonly SQLiteAsyncConnection db;

        public SQLiteHelper (string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<WordModel>();

        }

        public Task<int> CreateWord(WordModel word)
        {
            return db.InsertAsync(word);
        }

        public async Task<IEnumerable<WordModel>> ReadWords()
        {
            return await Task.FromResult(await db.Table<WordModel>().ToListAsync()); 
        }
        public Task<int> UpdateWord(WordModel word)
        {

            return db.UpdateAsync(word);
        }

        public Task<int> DeleteWord(WordModel word)
        {
            return db.DeleteAsync(word);
        }

    }
}
