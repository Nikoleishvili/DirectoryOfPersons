using DirectoryOfPersons.Domain.Common;

namespace DirectoryOfPersons.Domain.Entities
{
    public class Gender : BaseEntity<int>
    {
        public string Name { get; set; }
    }
}