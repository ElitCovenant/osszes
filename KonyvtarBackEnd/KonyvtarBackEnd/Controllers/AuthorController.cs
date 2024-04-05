using KonyvtarBackEnd.Dto;
using KonyvtarBackEnd.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KonyvtarBackEnd.Controllers
{
    [ApiController,Authorize(Roles = "Admin")]
    [Route("/Author")]
    public class AuthorController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<AuthorDto>> Post(CreateOrModifyAuthorDto createOrModifyAuthorDto)
        {
            try
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
                            return BadRequest("Hiba lépett fel! : " + e.Message);
                        }

                        return StatusCode(201, "Az adatok sikeresen eltárolva!");
                    }
                    else
                    {
                        return StatusCode(406, "Nem megfeleő az adat formátuma!");
                    }
                }
            }
            catch (Exception e) { return StatusCode(500, e.Message); }

        }

        [HttpGet]
        public async Task<ActionResult<AuthorDto>> GetAll()
        {
            try
            {
                using (var context = new KonyvtarDbContext())
                {
                    if (context != null)
                    {
                        return Ok(context.Authors.Select(x => new { x.Id, x.Name }).ToList());
                    }
                    else
                    {
                        return StatusCode(503, "A szerver jelenleg nem elérhető");
                    }
                }
            }
            catch (Exception e) { return StatusCode(500, e.Message); }

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorDto>> Get(int id)
        {
            try
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
            catch (Exception e) { return StatusCode(500, e.Message); }

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<AuthorDto>> Put(int id, CreateOrModifyAuthorDto createOrModifyAuthorDto)
        {
            try
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
            catch (Exception e) { return StatusCode(500, e.Message); }

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<AuthorDto>> Delete(int id)
        {
            try
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
            catch (Exception e)
            {

                return StatusCode(500,e.Message);
            }

        }


    }
}
