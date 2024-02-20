using KonyvtarBackEnd.Dto;
using KonyvtarBackEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace KonyvtarBackEnd.Controllers
{
    [ApiController]
    [Route("/Author")]
    public class AuthorController : ControllerBase
    {
        [HttpPost]
        public ActionResult<AuthorDto> Post(CreateOrModifyAuthorDto createOrModifyAuthorDto)
        {
            var UjSzerzo = new Author
            {
                Id = createOrModifyAuthorDto.Id,
                Name = createOrModifyAuthorDto.Name
            };
            using (var context = new KonyvtarDbContext())
            {
                if (context != null)
                {
                    try
                    {
                        context.Authors.Add(UjSzerzo);
                        context.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        return BadRequest("Hiba lépett fel! : "+e.Message);
                    }
                    
                    return StatusCode(201, "Az adatok sikeresen eltárolva!");
                }
                else
                {
                    return StatusCode(406, "Nem megfeleő az adat formátuma!");
                }
            }
        }

        [HttpGet]
        public ActionResult<AuthorDto> GetAll()
        {
            using (var context = new KonyvtarDbContext())
            {
                if (context != null)
                {
                    return Ok(context.Authors.ToList());
                }
                else
                {
                    return StatusCode(503, "A szerver jelenleg nem elérhető");
                }
            }
        }

        [HttpGet("{id}")]
        public ActionResult<AuthorDto> Get(int id)
        {
            using (var context = new KonyvtarDbContext())
            {
                var kerdezett = context.Authors.FirstOrDefault(x => x.Id == id);

                if (context != null)
                {
                    if (kerdezett != null)
                    {
                        return Ok(kerdezett);
                    }
                    else
                    {
                        return StatusCode(404, "A keresett szerző nem létezik, vagy nincs eltárolva");
                    }
                }
                else
                {
                    return StatusCode(503, "A szerver jelenleg nem elérhető");
                }


            }
        }

        [HttpPut("{id}")]
        public ActionResult<AuthorDto> Put(int id, CreateOrModifyAuthorDto createOrModifyAuthorDto)
        {
            using (var context = new KonyvtarDbContext())
            {
                if (context != null)
                {
                    var valtoztatando = context.Authors.FirstOrDefault(x => x.Id == id);
                    if (valtoztatando != null)
                    {
                        valtoztatando.Id = createOrModifyAuthorDto.Id;
                        valtoztatando.Name = createOrModifyAuthorDto.Name;
                        try
                        {
                            context.Authors.Update(valtoztatando);
                            context.SaveChanges();
                        }
                        catch (Exception e)
                        {

                            return BadRequest("Hiba lépett fel! : " + e.Message);
                        }
                        
                        return Ok("Sikeres adatváltoztatás!");
                    }
                    else
                    {
                        return StatusCode(404, "A keresett szerző nem létezik, vagy nincs eltárolva");
                    }
                }
                else
                {
                    return StatusCode(503, "A szerver jelenleg nem elérhető");
                }
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<AuthorDto> Delete(int id)
        {
            using (var context = new KonyvtarDbContext())
            {
                var kerdezett = context.Authors.FirstOrDefault(x => x.Id == id);

                if (context != null)
                {
                    if (kerdezett != null)
                    {
                        context.Authors.Remove(kerdezett);
                        context.SaveChanges();
                        return Ok("A szerző eltávolítása sikeresen megtörtént");
                    }
                    else
                    {
                        return StatusCode(404, "A keresett szerző eddig sem létezett, vagy nem volt eltárolva");
                    }
                }
                else
                {
                    return StatusCode(503, "A szerver jelenleg nem elérhető");
                }

            }
        }



    }
}
