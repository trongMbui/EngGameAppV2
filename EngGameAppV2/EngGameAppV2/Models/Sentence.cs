using System;
using System.Collections.Generic;
using System.Text;

namespace EngGameAppV2.Models
{
    public class Sentence
    {
        public string EnglishSentence { get; set; }

        public Sentence(string sentence)
        {
            EnglishSentence = sentence;
        }
    }
}
