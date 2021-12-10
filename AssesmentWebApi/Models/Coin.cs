using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace AssesmentWebApi.Models
{
    [Table("Coin")]
    public partial class Coin
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Amount { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Volume { get; set; }
    }
}
