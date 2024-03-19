using KonyvtarBackEnd.Dto;
using KonyvtarBackEnd.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KonyvtarBackEnd.Controllers
{
    [ApiController]
    [Route("/Book")]
    public class BookController : ControllerBase
    {
        [HttpPost]
        public ActionResult<BookDto> Post(CreateOrModifyKonyvDto createOrModifyKonyvDto)
        {
            var UjKonyv = new Book
            {
                Id = createOrModifyKonyvDto.Id,
                WarehouseNum = createOrModifyKonyvDto.Warehouse_Num,
                PurchaseDate = createOrModifyKonyvDto.Purchase_Date,
                AuthorId = createOrModifyKonyvDto.Author_Id,
                Title = createOrModifyKonyvDto.Title,
                SeriesId = createOrModifyKonyvDto.Series_Id,
                IsbnNum = createOrModifyKonyvDto.Isbn_Num,
                Szakkjelzet = createOrModifyKonyvDto.Szakjelzet,
                CutterJelzet = createOrModifyKonyvDto.Cutter_Jelzet,
                PublisherId = createOrModifyKonyvDto.Publisher_Id,
                ReleaseDate = createOrModifyKonyvDto.Release_Date,
                Price = createOrModifyKonyvDto.Price,
                Comment = createOrModifyKonyvDto.Comment,
                UserId = createOrModifyKonyvDto.User_Id

            };
            using (var context = new KonyvtarDbContext())
            {
                if (context != null)
                {
                    try
                    {
                        context.Books.Add(UjKonyv);
                        context.SaveChanges();
                    }
                    catch (Exception e) { return BadRequest("Hiba lépett fel! : " + e.Message); }


                    return StatusCode(201, "Az adatok sikeresen eltárolva!");
                }
                else
                {
                    return StatusCode(406, "Nem megfeleő az adat formátuma!");
                }
            }
        }

        [HttpGet, Authorize(Roles = "Admin")]
        public ActionResult<BookDto> GetAll()
        {
            using (var context = new KonyvtarDbContext())
            {
                if (context != null)
                {
                    return Ok(context.Books.ToList());
                }
                else
                {
                    return StatusCode(503, "A szerver jelenleg nem elérhető");
                }
            }
        }

        [HttpGet("/GuestInformations")]
        public ActionResult<BookDto> GetSutentsAll()
        {
            using (var context = new KonyvtarDbContext())
            {
                if (context != null)
                {
                    return Ok(context.Books.Select(x => new {x.Id    ,x.Author, x.Title, x.ReleaseDate, x.BookImg }).ToList());
                }
                else
                {
                    return StatusCode(503, "A szerver jelenleg nem elérhető");
                }
            }
        }

        [HttpGet("/Search/{nae}")]
        public ActionResult<BookDto> Search(string nae)
        {
            using (var context = new KonyvtarDbContext())
            {
                if (context != null)
                {
                    return Ok(context.Books.Select(x => new { x.Id, x.Author, x.Title, x.ReleaseDate, x.BookImg }).Where(x=>x.Title.Contains(nae)).ToList());
                }
                else
                {
                    return StatusCode(404, "Nincs ilyen könyv!");
                }
            }
        }

        [HttpGet("/Konyvvalaszto")]
        public ActionResult<BookDto> GetSpecial(int elsoev, int masodikev, int iroId)
        {
            using (var context = new KonyvtarDbContext())
            {
                if (context != null)
                {
                    var response = context.Books.Where(x => x.ReleaseDate < masodikev && x.ReleaseDate > elsoev && x.AuthorId == iroId).Select(x => new { x.Author, x.Title, x.ReleaseDate, x.BookImg }).ToList();
                    if (response != null)
                    {
                        return Ok(response);
                    }
                    else
                    {
                        return NotFound();
                    }

                }
                else
                {
                    return StatusCode(503, "A szerver jelenleg nem elérhető");
                }
            }
        }

        [HttpGet("{id}")]
        public ActionResult<BookDto> Get(int id)
        {
            using (var context = new KonyvtarDbContext())
            {
                var kerdezett = context.Books.FirstOrDefault(x => x.Id == id);

                if (context != null)
                {
                    if (kerdezett != null)
                    {
                        return Ok(kerdezett);
                    }
                    else
                    {
                        return StatusCode(404, "A keresett könyv nem létezik, vagy nincs eltárolva");
                    }
                }
                else
                {
                    return StatusCode(503, "A szerver jelenleg nem elérhető");
                }


            }
        }

        [HttpPut("{id}")]
        public ActionResult<BookDto> Put(int id, CreateOrModifyKonyvDto createOrModifyKonyvDto)
        {
            using (var context = new KonyvtarDbContext())
            {
                if (context != null)
                {
                    var valtoztatando = context.Books.FirstOrDefault(x => x.Id == id);
                    if (valtoztatando != null)
                    {
                        valtoztatando.Id = createOrModifyKonyvDto.Id;
                        valtoztatando.WarehouseNum = createOrModifyKonyvDto.Warehouse_Num;
                        valtoztatando.PurchaseDate = createOrModifyKonyvDto.Purchase_Date;
                        valtoztatando.AuthorId = createOrModifyKonyvDto.Author_Id;
                        valtoztatando.Title = createOrModifyKonyvDto.Title;
                        valtoztatando.SeriesId = createOrModifyKonyvDto.Series_Id;
                        valtoztatando.IsbnNum = createOrModifyKonyvDto.Isbn_Num;
                        valtoztatando.Szakkjelzet = createOrModifyKonyvDto.Szakjelzet;
                        valtoztatando.CutterJelzet = createOrModifyKonyvDto.Cutter_Jelzet;
                        valtoztatando.PublisherId = createOrModifyKonyvDto.Publisher_Id;
                        valtoztatando.ReleaseDate = createOrModifyKonyvDto.Release_Date;
                        valtoztatando.Price = createOrModifyKonyvDto.Price;
                        valtoztatando.Comment = createOrModifyKonyvDto.Comment;
                        valtoztatando.UserId = createOrModifyKonyvDto.User_Id;

                        try
                        {
                            context.Books.Update(valtoztatando);
                            context.SaveChanges();
                        }
                        catch (Exception e )
                        {
                            return BadRequest("Hiba lépett fel : "+e.Message);
                        }
                        
                        return Ok("Sikeres adatváltoztatás!");
                    }
                    else
                    {
                        return StatusCode(404, "A keresett könyv nem létezik, vagy nincs eltárolva");
                    }
                }
                else
                {
                    return StatusCode(503, "A szerver jelenleg nem elérhető");
                }
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<BookDto> Delete(int id)
        {
            using (var context = new KonyvtarDbContext())
            {
                var kerdezett = context.Books.FirstOrDefault(x => x.Id == id);

                if (context != null)
                {
                    if (kerdezett != null)
                    {
                        context.Books.Remove(kerdezett);
                        context.SaveChanges();
                        return Ok("A sorozat eltávolítása sikeresen megtörtént");
                    }
                    else
                    {
                        return StatusCode(404, "A keresett könyv eddig sem létezett, vagy nem volt eltárolva");
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
