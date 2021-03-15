using DirectoryOfPersons.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace DirectoryOfPersons.Domain.Entities
{
    public class RelationshipType : BaseEntity<int>
    {
        public string Name { get; set; }
    }
}
