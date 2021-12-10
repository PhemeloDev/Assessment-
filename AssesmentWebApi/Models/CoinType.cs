using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace AssesmentWebApi.Models
{
    public partial class CoinType
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Denomination { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Value { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal Volume { get; set; }
    }
}
