using SampleWebApp.Models;

namespace SampleWebApp.Data
{
    public interface IPeopleRepository
    {
        List<Person> People { get; }
    }
}