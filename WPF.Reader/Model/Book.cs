using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Reader.Model
{
    public class Book
    {
        public int Id { get; set; }

        //-------------------------------------------------------
        public string Nom { get; set; }
        public string Authors { get; set; }
        public double Prix { get; set; }
        public string Contenu { get; set; }
        public List<Genre> Genre { get; set; }
    }
}
