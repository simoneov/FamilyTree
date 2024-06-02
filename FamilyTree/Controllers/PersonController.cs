using FamilyTree.Dto;
using FamilyTree.Models;
using FamilyTree.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FamilyTree.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository _repo;
        public PersonController(IPersonRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("/father/{id}")]

        public async Task<Person> Father(int id)
        {
            return await _repo.showFather(id);
        }


        [Authorize(Roles ="Admin")]
        [HttpGet("/people")]
        public async Task<dynamic> People()
        {
            return await _repo.getAll();
        }

        [AllowAnonymous]
        [HttpGet("/mother/{id}")]
        public async Task<Person> Mother(int id)
        {
            return await _repo.showMother(id);
        }

        [HttpGet("/siblings/{id}")]
        //
        public async Task<List<Person>> Siblings(int id)
        {
            return await _repo.showSiblings(id);
        }

        [HttpDelete("/remove/{id}")]
        //
        public async Task removePerson(int id)
        {
            await _repo.deletePerson(id);
        }

        [HttpPost("/wedding/")]
        public async Task wedding([FromBody] WeddingDivorceDto wedding)
        {
            await _repo.setWedding(wedding);
        }

        [HttpPut("/divorce/")]
        public async Task divorce([FromBody] WeddingDivorceDto divorce)
        {
            await _repo.divorce(divorce);
        }

    }
 }

