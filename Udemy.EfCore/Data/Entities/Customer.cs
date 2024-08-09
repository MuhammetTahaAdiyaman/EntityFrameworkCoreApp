using System.ComponentModel.DataAnnotations;

namespace Udemy.EfCore.Data.Entities
{
    public class Customer
    {
        //[Key] --> ilgili tek kolonu primary key yapar.
        public int Number { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
