using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ASP.Server.Model
{
    public class Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Authors { get; set; }
        public double Prix { get; set; }
        public string Contenu { get; set; }
        public List<Genre> Genre { get; set; }

    }
}
