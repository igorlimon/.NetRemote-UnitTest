using System.Collections.Generic;

namespace Repository
{
    public interface IPersonRepository
    {
        IList<Person> GetAllPersons();
    }
}