using KonyvtarBackEnd.Dto;
using KonyvtarBackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace KonyvtarBackEnd.Controllers
{
    [ApiController]
    [Route("/LoanHistory")]
    public class LoanHistoryController : ControllerBase
    {
        [HttpPost]
        public ActionResult<LoanHistoryDto> Post(CreateLoanHistoryDto createOrModifyLoanHistory)
        {
            var UjKolcsonzesTortenet = new LoanHistory
            {
                Id = createOrModifyLoanHistory.Id,
                BookId = createOrModifyLoanHistory.Book_Id,
                UserId = createOrModifyLoanHistory.User_Id,
                Date = DateTime.Now,
                DateEnd = DateTime.Now.AddDays(createOrModifyLoanHistory.Deadline),
                Returned = false,
                Comment = createOrModifyLoanHistory.Comment

                
            };
            using (var context = new KonyvtarDbContext())
            {
                if (context != null)
                {
                    try
                    {
                        context.LoanHistories.Add(UjKolcsonzesTortenet);
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
        public ActionResult<LoanHistoryDto> GetAll()
        {
            using (var context = new KonyvtarDbContext())
            {
                if (context != null)
                {
                    return Ok(context.LoanHistories.ToList());
                }
                else
                {
                    return StatusCode(503, "A szerver jelenleg nem elérhető");
                }
            }
        }

        [HttpGet("{id}")]
        public ActionResult<LoanHistoryDto> Get(int id)
        {
            using (var context = new KonyvtarDbContext())
            {
                var kerdezett = context.LoanHistories.FirstOrDefault(x => x.Id == id);

                if (context != null)
                {
                    if (kerdezett != null)
                    {
                        return Ok(kerdezett);
                    }
                    else
                    {
                        return StatusCode(404, "A keresett Kölcsönzéstörténet nem létezik, vagy nincs eltárolva");
                    }
                }
                else
                {
                    return StatusCode(503, "A szerver jelenleg nem elérhető");
                }


            }
        }

        [HttpPut("{id}")]
        public ActionResult<LoanHistoryDto> Put(int id, ModifyLoanHistoryDto createOrModifyLoanHistoryDto)
        {
            using (var context = new KonyvtarDbContext())
            {
                if (context != null)
                {
                    var valtoztatando = context.LoanHistories.FirstOrDefault(x => x.Id == id);
                    if (valtoztatando != null)
                    {
                        valtoztatando.Id = createOrModifyLoanHistoryDto.Id;
                        valtoztatando.BookId = createOrModifyLoanHistoryDto.Book_Id;
                        valtoztatando.UserId = createOrModifyLoanHistoryDto.User_Id;
                        valtoztatando.Date = createOrModifyLoanHistoryDto.Date;
                        valtoztatando.DateEnd = createOrModifyLoanHistoryDto.Date_End;
                        valtoztatando.Returned = createOrModifyLoanHistoryDto.Returned;
                        valtoztatando.Comment = createOrModifyLoanHistoryDto.Comment;

                        try
                        {
                            context.LoanHistories.Update(valtoztatando);
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
                        return StatusCode(404, "A keresett kölcsönzéstörténet nem létezik, vagy nincs eltárolva");
                    }
                }
                else
                {
                    return StatusCode(503, "A szerver jelenleg nem elérhető");
                }
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<LoanHistoryDto> Delete(int id)
        {
            using (var context = new KonyvtarDbContext())
            {
                var kerdezett = context.LoanHistories.FirstOrDefault(x => x.Id == id);

                if (context != null)
                {
                    if (kerdezett != null)
                    {
                        context.LoanHistories.Remove(kerdezett);
                        context.SaveChanges();
                        return Ok("A kölcsönzéstörténet eltávolítása sikeresen megtörtént");
                    }
                    else
                    {
                        return StatusCode(404, "A keresett kölcsönzéstörténet eddig sem létezett, vagy nem volt eltárolva");
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
