using CrazyMusicians.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrazyMusicians.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Musicians : ControllerBase
    {
        private static List<Musician> musicians = new List<Musician>()
        {
            new Musician{Id = 1, Name = "Ahmet Çalgı", Profession = "Ünlü Çalgı Çalar", FunFeature = "Her zaman yanlış nota çalar, ama çok eğlenceli."},
            new Musician{Id = 2, Name = "Zeynep Melodi", Profession = "Popüler Melodi Yazarı", FunFeature = "Şarkıları yanlış anlaşılır ama çok popüler."},
            new Musician{Id = 3, Name = "Cemil Akor", Profession = "Çılgın Akorist", FunFeature = "Akorları sık değiştirir, ama şaşırtıcı derecede yetenekli."},
            new Musician{Id = 4, Name = "Fatma Nota", Profession = "Sürpriz Nota Üreticisi", FunFeature = "Nota üretirken sürekli sürprizler hazırlar."},
            new Musician{Id = 5, Name = "Hasan Ritim", Profession = "Ritim Canavarı", FunFeature = "Her ritmi kendi tarzında yapar, hiç uymaz ama komiktir."},
            new Musician{Id = 6, Name = "Elif Armoni", Profession = "Armoni Ustası", FunFeature = "Armonilerini bazen yanlış çalar, ama çok yaratıcıdır."},
            new Musician{Id = 7, Name = "Ali Perde", Profession = "Perde Uygulayıcı", FunFeature = "Her perdeyi farklı şekilde çalar, her zaman sürprizlidir."},
            new Musician{Id = 8, Name = "Ayşe Rezonans", Profession = "Rezonans Uzmanı", FunFeature = "Rezonans konusunda uzman, ama bazen çok gurultu çıkarır."},
            new Musician{Id = 9, Name = "Murat Ton", Profession = "Tonlama Meraklısı", FunFeature = "Tonlamalarındaki farklılıklar bazen komik, ama oldukça ilginç."},
            new Musician{Id = 10, Name = "Selin Akor", Profession = "Akor Sihirbazı", FunFeature = "Akorları değiştirdiğinde bazen sihirli bir hava yaratır."}
        };


        [HttpGet]
        public IActionResult GetAllMusicians()
        {
            return Ok(musicians);
        }

        [HttpGet("search")]
        public IActionResult SearchMusicians([FromQuery] string name)
        {
            var result = musicians.Where(m => m.Name.Contains(name, System.StringComparison.OrdinalIgnoreCase)).ToList();
            if (!result.Any())
                return NotFound("No musicians found with the given name.");
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public ActionResult<Musician> GetMusician(int id)
        {
            var musician = musicians.FirstOrDefault(m => m.Id == id);
            if (musician == null)
                return NotFound("Musician not found");
            return Ok(musician);
        }


        [HttpPost]
        public IActionResult AddMusician([FromBody] Musician newMusician)
        {
            if (musicians.Any(m => m.Id == newMusician.Id))
                return BadRequest("A musician with the given ID already exists.");

            musicians.Add(newMusician);
            return CreatedAtAction(nameof(GetAllMusicians), new { id = newMusician.Id }, newMusician);
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateMusician(int id, [FromBody] Musician updatedMusician)
        {
            var musician = musicians.FirstOrDefault(m => m.Id == id);
            if (musician == null)
                return NotFound("Musician not found.");

            musician.Name = updatedMusician.Name;
            musician.Profession = updatedMusician.Profession;
            musician.FunFeature = updatedMusician.FunFeature;

            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateMusicianFeature(int id, [FromBody] string newFeature)
        {
            var musician = musicians.FirstOrDefault(m => m.Id == id);
            if (musician == null)
                return NotFound("Musician not found.");

            musician.FunFeature = newFeature;
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteMusician(int id)
        {
            var musician = musicians.FirstOrDefault(m => m.Id == id);
            if (musician == null)
                return NotFound("Musician not found.");

            musicians.Remove(musician);
            return NoContent();
        }
    }
}
