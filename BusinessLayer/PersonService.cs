using System.Collections.Generic;
using System.Linq;
using Repository;

namespace BusinessLayer
{
    public class PersonService
    {
        private readonly IPersonRepository _blogRepository;

        public PersonService(IPersonRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public IList<Person> OlderPersons()
        {
            var persons = _blogRepository.GetAllPersons();
            if (persons.Count == 0)
            {
                return new List<Person>();
            }

            var smallestBirthDate = persons.Min(p => p.BirthDate);

            return persons
                .Where(p => p.BirthDate == smallestBirthDate)
                .ToList();
        }

        public IList<Person> YoungerPersons()
        {
            var persons = _blogRepository.GetAllPersons();
            var biggestBirthDate = persons.Max(p => p.BirthDate);

            return persons
                .Where(p => p.BirthDate == biggestBirthDate)
                .ToList();
        }

        public IList<Person> GetPersonsByGender(Gender gender)
        {
            var persons = _blogRepository.GetAllPersons();
            var personsGroupedByGender = persons
                .GroupBy(p => p.Gender)
                .ToList();

            return personsGroupedByGender
                .Where(p => p.Key == gender)
                .SelectMany(p => p)
                .ToList();
        }
    }
}
