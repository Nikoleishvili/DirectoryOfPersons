using System;
using System.Collections.Generic;
using System.Text;

namespace DirectoryOfPersons.Application.Models
{
    public class TypeData<T>
    {
        public int Id { get; set; }
        public T Type { get; set; }
        public string Value { get; set; }
    }
}
