using EngGameAppV2.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EngGameAppV2.Services
{
    public class WordBankStorage : IDataStore<Word>
    {
        readonly IList<Word> wordList;

        readonly IList<Sentence> sentenceList;
        public WordBankStorage()
        {
            wordList = new List<Word>()
            {
                new Word( "Hi", "a way of greeting"),
                new Word( "Dog", "humans best friend"),
                new Word( "Game", "entertainment system"),
                new Word( "House", "where humans live"),
                new Word("Hej", "a way of greeting"),
                new Word("Hund", "humans best friend"),
                new Word("Spel", "entertainment system"),
                new Word("Hus",  "where humans live"),

            };

            sentenceList = new List<Sentence>()
            {
                new Sentence("How are you today?")
            };
        }

        public Task<IList<Word>> ListAsync() => Task.FromResult(wordList);

        public Task<IList<Sentence>> SenListAsync() => Task.FromResult(sentenceList);

        public Task<bool> AddItemAsync(Word item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Word> GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Word>> GetItemsAsync(bool forceRefresh = false)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateItemAsync(Word item)
        {
            throw new NotImplementedException();
        }
    }
}
