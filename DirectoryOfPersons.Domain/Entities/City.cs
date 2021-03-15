using DirectoryOfPersons.Domain.Common;

namespace DirectoryOfPersons.Domain.Entities
{
    public class City : BaseEntity<int>
    {
        public string Name { get; set; }
    }
}