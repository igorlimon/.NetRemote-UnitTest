using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly string _userFilePath;

        public PersonRepository(string userFilePath)
        {
            _userFilePath = userFilePath;
        }

        public IList<Person> GetAllPersons()
        {
            var persons = new List<Person>();
            if (File.Exists(_userFilePath))
            {
                try
                {
                    string templateStr = File.ReadAllText(_userFilePath);
                    persons = JsonHelper.Deserialize<List<Person>>(templateStr);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    Console.ReadKey();
                }
            }

            return persons;
        }
    }
}
