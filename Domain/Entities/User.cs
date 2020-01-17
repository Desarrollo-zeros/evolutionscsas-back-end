using Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    [Table("user")]
    
    public class User : Entity<int>
    {
        [Required]
        [Column("username", TypeName = "varchar(255)", Order = 2)]
        [MaxLength(20)]
        [MinLength(4)]
        public string Username { set; get; }

        [Required]
        [Column("password", TypeName = "varchar(255)", Order = 3)]
        [MaxLength(20)]
        [MinLength(4)]
        [JsonIgnore]
        public string Password { set; get; }

        [Required]
        [DefaultValue(0)]
        [Column("state", TypeName = "smallint", Order = 4)]
        public State State { set; get; }

    }
}
