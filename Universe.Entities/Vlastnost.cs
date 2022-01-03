using System;
using System.Collections;
using System.Linq;

using LinqToDB.DataProvider.SqlServer;
using LinqToDB.Mapping;

namespace Universe.Entities
{
    [Table("Vlastnost")]
    public class Vlastnost
    {
        [PrimaryKey, Identity]
        public int Id { get; set; }
        
        [Column, Nullable]
        public string Nazev { get; set; }
    }
}