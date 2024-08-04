using _30_07_2024_work.DTOs;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace _30_07_2024_work.Controllers;

[ApiController]
[Route("api/v1/HomeController")]
public class HomeController : ControllerBase
{
    public static List<Person> persons = new List<Person>
    {
        new Person { Id = 1, Name ="Tom" },
        new Person { Id = 2, Name = "Kate" }
    };

    [HttpGet]
    public ActionResult<List<Person>> GetPerson()
    {
        return Ok(persons);
    }

    [HttpPost]
    public ActionResult<Person> CreatePerson(CreatePersonRequest createPerson)
    {
        Person person = new Person { Id = createPerson.Id, Name = createPerson.Name, Email = createPerson.Email };

        persons.Add(person);

        return Ok(person);
    }

    [HttpDelete]
    public ActionResult<bool> DeletePerson(DelitePersonRequest delitePerson)
    {
        var person = persons.FirstOrDefault(x => x.Id == delitePerson.Id);
        persons.Remove(person);
        return Ok(true);
    }

    [HttpGet("{id}")]
    public ActionResult<Person> GetPersonById(int id)
    {
        var person = persons.FirstOrDefault(p => p.Id == id);
        if (person == null)
        {
            return NotFound();
        }
        return Ok(person);
    }

    [HttpPatch]
    public ActionResult<Person> PatchPersonById(PatchPersonById patchPersonById)
    {
        var person = persons.FirstOrDefault(p => p.Id == patchPersonById.Id);

        persons.Remove(person);
        person = new Person { Id = person.Id, Name = patchPersonById.Name, Email = person.Email };
        persons.Add(person);

        return Ok(person);
    }

    [HttpPut]
    public ActionResult<Person> PutPersonById(PutPersonById putPersonById)
    {
        var person = persons.FirstOrDefault(p => p.Id == putPersonById.Id);
        
        person.Name = putPersonById.Name;
        person.Email = putPersonById.Email;
        return Ok(person);
    }
}

public class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}