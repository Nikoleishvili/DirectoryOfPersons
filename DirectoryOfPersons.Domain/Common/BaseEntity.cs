using System;
using System.Collections.Generic;
using System.Text;

namespace DirectoryOfPersons.Domain.Common
{
    public class BaseEntity<T>
    {
        public T Id { get; set; }
    }
}
