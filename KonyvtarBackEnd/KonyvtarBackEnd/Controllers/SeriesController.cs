using KonyvtarBackEnd.Dto;
using KonyvtarBackEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace KonyvtarBackEnd.Controllers
{
    [ApiController]
    [Route("/Series")]
    public class SeriesController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<SeriesDto>> Post(CreateOrModifySeriesDto createOrModifySeriesDto)
        {
            try
            {
                var UjSorozat = new Series
                {
                    Id = createOrModifySeriesDto.Id,
                    Name = createOrModifySeriesDto.Name
                };
                using (var context = new KonyvtarDbContext())
                {
                    if (context != null)
                    {
                        try
                        {
                            context.Series.Add(UjSorozat);
                            context.SaveChanges();
                        }
                        catch (Exception e) { return BadRequest("Hiba lépett fel : " + e.Message); }

                        return StatusCode(201, "Az adatok sikeresen eltárolva!");
                    }
                    else
                    {
                        return StatusCode(406, "Nem megfeleő az adat formátuma!");
                    }
                }
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }

        }

        [HttpGet]
        public async Task<ActionResult<SeriesDto>> GetAll()
        {
            try
            {
                using (var context = new KonyvtarDbContext())
                {
                    if (context != null)
                    {
                        return Ok(context.Series.Select(x=> new {x.Id,x.Name}).ToList());
                    }
                    else
                    {
                        return StatusCode(503, "A szerver jelenleg nem elérhető");
                    }
                }
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SeriesDto>> Get(int id)
        {
            try
            {
                using (var context = new KonyvtarDbContext())
                {
                    var kerdezett = context.Series.FirstOrDefault(x => x.Id == id);

                    if (context != null)
                    {
                        if (kerdezett != null)
                        {
                            return Ok(kerdezett);
                        }
                        else
                        {
                            return StatusCode(404, "A keresett sorozat nem létezik, vagy nincs eltárolva");
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

                return StatusCode(500, e.Message);
            }

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<SeriesDto>> Put(int id, CreateOrModifySeriesDto createOrModifySeriesDto)
        {
            try
            {
                using (var context = new KonyvtarDbContext())
                {
                    if (context != null)
                    {
                        var valtoztatando = context.Series.FirstOrDefault(x => x.Id == id);
                        if (valtoztatando != null)
                        {
                            valtoztatando.Id = createOrModifySeriesDto.Id;
                            valtoztatando.Name = createOrModifySeriesDto.Name;

                            try
                            {
                                context.Series.Update(valtoztatando);
                                context.SaveChanges();
                            }
                            catch (Exception e)
                            {
                                return BadRequest("Hiba lépett fel : " + e.Message);
                            }

                            return Ok("Sikeres adatváltoztatás!");
                        }
                        else
                        {
                            return StatusCode(404, "A keresett sorozat nem létezik, vagy nincs eltárolva");
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

                return StatusCode(500, e.Message);
            }

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<SeriesDto>> Delete(int id)
        {
            try
            {
                using (var context = new KonyvtarDbContext())
                {
                    var kerdezett = context.Series.FirstOrDefault(x => x.Id == id);

                    if (context != null)
                    {
                        if (kerdezett != null)
                        {
                            context.Series.Remove(kerdezett);
                            context.SaveChanges();
                            return Ok("A sorozat eltávolítása sikeresen megtörtént");
                        }
                        else
                        {
                            return StatusCode(404, "A keresett sorozat eddig sem létezett, vagy nem volt eltárolva");
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

                return StatusCode(500, e.Message);
            }

        }
    }
}
