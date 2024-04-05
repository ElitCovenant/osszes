using KonyvtarBackEnd.Dto;
using KonyvtarBackEnd.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace KonyvtarBackEnd.Controllers
{
    [ApiController,Authorize(Roles = "Admin")]
    [Route("/LoanHistory")]
    public class LoanHistoryController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<LoanHistoryDto>> Post(CreateLoanHistoryDto createOrModifyLoanHistory)
        {
            try
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
                            return BadRequest("Hiba lépett fel : " + e.Message);
                        }

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
        public async Task<ActionResult<LoanHistoryDto>> GetAll()
        {
            try
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
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }

        }

        [HttpGet("/Notreturned")]
        public async Task<ActionResult> GetReturnt()
        {
            try
            {
                using (var context = new KonyvtarDbContext())
                {
                    if (context != null)
                    {
                        return Ok(context.LoanHistories.Include(x => x.User).Include(x => x.Book).Where(x => x.Returned == false).Select(x => new NewRecord(x.Book.Id, x.Book.Title, x.User.Id, x.User.Usarname)).ToList());
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
        public async Task<ActionResult<LoanHistoryDto>> Get(int id)
        {
            try
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
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<LoanHistoryDto>> Put(int id, ModifyLoanHistoryDto createOrModifyLoanHistoryDto)
        {
            try
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
                                return BadRequest("Hiba lépett fel : " + e.Message);
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
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<LoanHistoryDto>> Delete(int id)
        {
            try
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
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }

        }
    }

    internal record NewRecord(uint Id, string Title, uint UserId, string? Usarname);
}
