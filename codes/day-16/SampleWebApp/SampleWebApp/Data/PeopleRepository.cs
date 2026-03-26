using SampleWebApp.Models;

namespace SampleWebApp.Data
{
    public class PeopleRepository : IPeopleRepository
    {
        public List<Person> People { get; } = [new() { Location = "Bangalore", Name = "Joydip" }, new() { Location = "Chennai", Name = "Vinod" }];
    }
}
