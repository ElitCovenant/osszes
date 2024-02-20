using KonyvtarBackEnd.Dto;
using KonyvtarBackEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace KonyvtarBackEnd.Controllers
{
    [ApiController]
    [Route("/Publisher")]
    public class PublisherController : ControllerBase
    {
        [HttpPost]
        public ActionResult<PublisherDto> Post(CreateOrModifyPublisherDto createOrModifyPublisherDto)
        {
            var UjKiado = new Publisher
            {
                Id = createOrModifyPublisherDto.Id,
                Name = createOrModifyPublisherDto.Name
            };
            using (var context = new KonyvtarDbContext())
            {
                if (context != null)
                {
                    try
                    {
                        context.Publishers.Add(UjKiado);
                        context.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        return BadRequest("Hiba lépett fel : "+e.Message);
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
        public ActionResult<PublisherDto> GetAll()
        {
            using (var context = new KonyvtarDbContext())
            {
                if (context != null)
                {
                    return Ok(context.Publishers.ToList());
                }
                else
                {
                    return StatusCode(503, "A szerver jelenleg nem elérhető");
                }
            }
        }

        [HttpGet("{id}")]
        public ActionResult<PublisherDto> Get(int id)
        {
            using (var context = new KonyvtarDbContext())
            {
                var kerdezett = context.Publishers.FirstOrDefault(x => x.Id == id);

                if (context != null)
                {
                    if (kerdezett != null)
                    {
                        return Ok(kerdezett);
                    }
                    else
                    {
                        return StatusCode(404, "A keresett kiadó nem létezik, vagy nincs eltárolva");
                    }
                }
                else
                {
                    return StatusCode(503, "A szerver jelenleg nem elérhető");
                }


            }
        }

        [HttpPut("{id}")]
        public ActionResult<PublisherDto> Put(int id, CreateOrModifyPublisherDto createOrModifyPublisherDto)
        {
            using (var context = new KonyvtarDbContext())
            {
                if (context != null)
                {
                    var valtoztatando = context.Publishers.FirstOrDefault(x => x.Id == id);
                    if (valtoztatando != null)
                    {
                        valtoztatando.Id = createOrModifyPublisherDto.Id;
                        valtoztatando.Name = createOrModifyPublisherDto.Name;
                        try
                        {
                            context.Publishers.Update(valtoztatando);
                            context.SaveChanges();
                        }
                        catch (Exception e)
                        {
                            return BadRequest("Hiba lépett fel : "+e.Message);
                        }
                        
                        return Ok("Sikeres adatváltoztatás!");
                    }
                    else
                    {
                        return StatusCode(404, "A keresett kiadó nem létezik, vagy nincs eltárolva");
                    }
                }
                else
                {
                    return StatusCode(503, "A szerver jelenleg nem elérhető");
                }
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<PublisherDto> Delete(int id)
        {
            using (var context = new KonyvtarDbContext())
            {
                var kerdezett = context.Publishers.FirstOrDefault(x => x.Id == id);

                if (context != null)
                {
                    if (kerdezett != null)
                    {
                        context.Publishers.Remove(kerdezett);
                        context.SaveChanges();
                        return Ok("A kiadó eltávolítása sikeresen megtörtént");
                    }
                    else
                    {
                        return StatusCode(404, "A keresett kiadó eddig sem létezett, vagy nem volt eltárolva");
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
