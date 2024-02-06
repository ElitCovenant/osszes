using KonyvtarBackEnd.Dto;
using KonyvtarBackEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace KonyvtarBackEnd.Controllers
{
    [ApiController]
    [Route("/Rule")]
    public class RuleController : ControllerBase
    {
        [HttpPost]
        public ActionResult<RuleDto> Post(CreateOrModifyRuleDto createOrModifyRuleDto)
        {
            var UjJog = new Rule
            {
                Id = createOrModifyRuleDto.Id,
                Name = createOrModifyRuleDto.Name
            };
            using (var context = new KonyvtarDbContext())
            {
                if (context != null)
                {
                    context.Rules.Add(UjJog);
                    context.SaveChanges();
                    return StatusCode(201, "Az adatok sikeresen eltárolva!");
                }
                else
                {
                    return StatusCode(406, "Nem megfeleő az adat formátuma!");
                }
            }
        }

        [HttpGet]
        public ActionResult<RuleDto> GetAll()
        {
            using (var context = new KonyvtarDbContext())
            {
                if (context != null)
                {
                    return Ok(context.Rules.ToList());
                }
                else
                {
                    return StatusCode(503, "A szerver jelenleg nem elérhető");
                }
            }
        }

        [HttpGet("{id}")]
        public ActionResult<RuleDto> Get(int id)
        {
            using (var context = new KonyvtarDbContext())
            {
                var kerdezett = context.Rules.FirstOrDefault(x => x.Id == id);

                if (context != null)
                {
                    if (kerdezett != null)
                    {
                        return Ok(kerdezett);
                    }
                    else
                    {
                        return StatusCode(404, "A keresett jog nem létezik, vagy nincs eltárolva");
                    }
                }
                else
                {
                    return StatusCode(503, "A szerver jelenleg nem elérhető");
                }


            }
        }

        [HttpPut("{id}")]
        public ActionResult<RuleDto> Put(int id, CreateOrModifyRuleDto createOrModifyRuleDto)
        {
            using (var context = new KonyvtarDbContext())
            {
                if (context != null)
                {
                    var valtoztatando = context.Rules.FirstOrDefault(x => x.Id == id);
                    if (valtoztatando != null)
                    {
                        valtoztatando.Id = createOrModifyRuleDto.Id;
                        valtoztatando.Name = createOrModifyRuleDto.Name;

                        context.Rules.Update(valtoztatando);
                        context.SaveChanges();
                        return Ok("Sikeres adatváltoztatás!");
                    }
                    else
                    {
                        return StatusCode(404, "A keresett jog nem létezik, vagy nincs eltárolva");
                    }
                }
                else
                {
                    return StatusCode(503, "A szerver jelenleg nem elérhető");
                }
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<RuleDto> Delete(int id)
        {
            using (var context = new KonyvtarDbContext())
            {
                var kerdezett = context.Rules.FirstOrDefault(x => x.Id == id);

                if (context != null)
                {
                    if (kerdezett != null)
                    {
                        context.Rules.Remove(kerdezett);
                        context.SaveChanges();
                        return Ok("A jog eltávolítása sikeresen megtörtént");
                    }
                    else
                    {
                        return StatusCode(404, "A keresett jog eddig sem létezett, vagy nem volt eltárolva");
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
