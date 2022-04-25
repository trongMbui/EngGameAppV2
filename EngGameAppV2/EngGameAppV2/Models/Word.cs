using System;
using System.Collections.Generic;
using System.Text;

namespace EngGameAppV2.Models
{
    public class Word
    {
        public int Id { get; set; }
        public string word { get; set; }
        public string Definition { get; set; }
       

        public Word(string Word,  string Definition)
        {
            this.word = Word;
            
            this.Definition = Definition;
        }

        public Word(string word)
        {
            this.word = word;
        }
    }
}
