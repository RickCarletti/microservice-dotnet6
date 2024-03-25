using RestWithASPNETUdemyPerson.Model;

namespace RestWithASPNETUdemyPerson.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private volatile int count;

        public Person Create(Person person)
        {
           return person;
        }

        public void Delete(long id)
        {

        }

        public List<Person> FindAll()
        {
            List<Person> persons = new List<Person>();
            for (int i = 0; i<10; i++)
            {
                Person person = MockPerson(i);
                persons.Add(person);
            }


            return persons;
        }

        public Person FindById(long id)
        {
            return new Person
            {
                Id = 1,
                FirstName = "Ricardo",
                LastName = "Carletti",
                Address = "Logo ali",
                Gender = "Helicopitero"
            };
        }

        public Person Update(Person person)
        {
            return person;
        }

        private Person MockPerson(int i)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "Person FirstName" + i,
                LastName = "Person LastName" + i,
                Address = "Person Address" + i,
                Gender = "Gender"
            };
        }

        private int IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }
    }
}
