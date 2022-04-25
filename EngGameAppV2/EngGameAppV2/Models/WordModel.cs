using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace EngGameAppV2.Models
{
    public class WordModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(50)]
        public string ActualWord { get; set; }
        public string Definition { get; set; }
    }
}
