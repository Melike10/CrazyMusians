using CrazyMusians.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CrazyMusians.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CrazyMusicianController : ControllerBase
    {
        static List<Musician> _musicians = new List<Musician>()
        {
            new Musician{Id=1,Name= "Ahmet Çalgı", Job="Ünlü Çalgı Çalar",FunSpeciality="Her zaman yanlış nota çalar ama eğlencelidir."},
            new Musician{Id=2,Name="Zeynep Melodi",Job="Popüler Melodi Yazarı",FunSpeciality ="Şarkıları yanlış anlaşılır ama çok popüler"}
        };

        [HttpGet]
        public IActionResult GetAll()
        {
            if (_musicians.Count == 0) 
                return NotFound();
            return Ok(_musicians);

        }
        [HttpGet("{id:int:min(1)}")]
        public IActionResult Get(int id) {
          var musician = _musicians.FirstOrDefault(x => x.Id == id);
            if (musician == null)
                return NotFound();
            return Ok(musician);
        }
        [HttpGet("search")]
        public IActionResult Search([FromQuery] string name) {
         var musician = _musicians.Where(m=>m.Name.ToLower().Contains(name.ToLower())).ToList();

            if (musician.Count == 0)
                return NotFound();


            return Ok(musician);
        }

       [HttpPost]
        public IActionResult Post([FromBody] Musician musician)
        {
            var id = _musicians.Max(x=> x.Id)+1;
            musician.Id = id;
            _musicians.Add(musician);

            return CreatedAtAction(nameof(Get),new {id=musician.Id},musician);
        }

       [HttpPatch("{id:int:min(1)}/{newFunSpeciality}/")]
        public IActionResult Patch(int id,string newFunSpeciality,[FromBody] JsonPatchDocument<Musician> newMusicianSpeciality)
        {
            var musician = _musicians.FirstOrDefault(x => x.Id == id);

            if(musician is null)
                return NotFound();

            musician.FunSpeciality = newFunSpeciality;
            newMusicianSpeciality.ApplyTo(musician);
            return CreatedAtAction(nameof(Get), new { id = musician.Id }, musician);

        }
     
        [HttpPut("{id:int:min(1)}")]
        public IActionResult Put(int id, [FromBody] Musician musician)
        {
            if(musician is null || musician.Id != id)
                return BadRequest();

            var m = _musicians.FirstOrDefault(x=> x.Id == id);
            if(m is null)
                return NotFound();
            m.Name = musician.Name;
            m.Job = musician.Job;
            m.FunSpeciality= musician.FunSpeciality;
            return Ok(m);
        }

        [HttpDelete("{id:int:min(1)}")]
        public IActionResult Delete(int id) {
            var musician = _musicians.FirstOrDefault(x=>x.Id == id);
            if(musician is null)
                return NotFound();
            _musicians.Remove(musician);
            return NoContent(); }
    }
}
