using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessEF.Entities
{
    [Table("QuestionTypes")]
    public class QuestionType
    {
        [Key]
        [Column("Id", Order = 1)]
        public int QuestionTypeId { get; set; }

        [Column("Description", Order = 2, TypeName = "nVarchar")]
        [MaxLength(200)]
        [Required]
        public string Description { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
