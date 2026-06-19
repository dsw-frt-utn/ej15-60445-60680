using System;
using System.Collections.Generic;
using System.Text;

namespace Dsw2026Ej15.Domain.Entities
{
    public class Speciality : BaseEntity
    {
        private string Name {  get; set; }
        private string Description { get; set; }

        public Speciality(string name, string description, Guid? id = null): base(id)
        {
            Name = name;
            Description = description;
        }
    }
}
