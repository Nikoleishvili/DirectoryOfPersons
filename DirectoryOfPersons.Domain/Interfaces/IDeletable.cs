using System;
using System.Collections.Generic;
using System.Text;

namespace DirectoryOfPersons.Domain.Interfaces
{
    public interface IDeletable
    {
        public DateTime? DateDeleted { get; set; }
    }
}
