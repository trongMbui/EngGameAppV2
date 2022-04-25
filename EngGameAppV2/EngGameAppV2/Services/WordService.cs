using EngGameAppV2.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace EngGameAppV2.Services
{
    public class WordService
    {
        static SQLiteAsyncConnection db;
        static async Task init()
        {
            if (db != null)
                return;
            var databasePath = Path.Combine(Xamarin.Essentials.FileSystem.AppDataDirectory, "MyData.Db");
            db = new SQLiteAsyncConnection(databasePath);

            await db.CreateTableAsync<WordModel>();
        }

        public static async Task AddWord(string actualWord, string definition)
        {
            await init();
            var word = new WordModel
            {
                ActualWord = actualWord,
                Definition = definition
            };
            var id = db.InsertAsync(word);
        }

        public static async Task RemoveWord(int id)
        {
            await init();
            await db.DeleteAsync<WordModel>(id);

        }

        public static async Task <IEnumerable<WordModel>>GetWord()
        {
            await init();

            var word = await db.Table<WordModel>().ToListAsync();
            return word;
        } 
    }
}
