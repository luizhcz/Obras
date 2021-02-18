using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Obras.Commom.Models.AuthorsModels
{
    [Table("AuthorsInfo")]
    public class AttributesAuthors
    {
        [Key]
        public int Id { get; set; }
        [Column("Name")]
        public string Name { get; set; }
    }
}
