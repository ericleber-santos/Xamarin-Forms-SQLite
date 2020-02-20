using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TesteSQLCipher.Models
{
    [Table("Class1")]
    public class Class1
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int ID { get; set; }
        public int CLASS_CODIGO { get; set; }
        public string CLASS_DESCRICAO { get; set; }
    }
}
