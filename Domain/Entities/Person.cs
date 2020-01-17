using Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    [Table("persons")]
    public class Person : Entity<int>
    {
        [Column("firstname", TypeName = "varchar(50)", Order = 2)]
        [Required]
        //
        // Resumen:
        //     Primer nombre de la persona
        //
        // Devuelve:
        //     Primer nombre de la persona
        public string FirstName { set; get; }

        [Column("secondname", TypeName = "varchar(50)", Order = 3)]
        //
        // Resumen:
        //     Segundo nombre de la persona
        //
        // Devuelve:
        //     Segundo nombre de la persona
        public string SecondName { set; get; }


        [Column("first_lastname", TypeName = "varchar(50)", Order = 4)]
        [Required]
        //
        // Resumen:
        //     Primer apellido de la persona
        //
        // Devuelve:
        //    Primer apellido de la persona
        public string FirstLastName { set; get; }

        [Column("second_lastname", TypeName = "varchar(50)", Order = 5)]

        //
        // Resumen:
        //     Segundo apellido de la persona
        //
        // Devuelve:
        //     Segundo apellido de la persona
        public string SecondLastName { set; get; }



        [Column("user_id", TypeName ="integer", Order = 6)]
        [ForeignKey("user_id")]
        [Required]
        public int UserId { set; get; }

        public User User { set; get; }
    }
}
