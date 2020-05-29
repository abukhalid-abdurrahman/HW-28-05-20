using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace Solution
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuotesController : ControllerBase
    {
        QuotesContext dbContext;
        public QuotesController(QuotesContext context)
        {
            dbContext = context;
            if (!dbContext.Quotes.Any())
            {
                dbContext.Quotes.Add(new Quote { Text = "Сильный человек — это тот, кто может управлять своим гневом.", Author = "Мухаммед (С.В.С)", InsertDate = System.DateTime.Now });
                dbContext.Quotes.Add(new Quote { Text = "Почитает женщину только благородный, а унижает её — только подлец!", Author = "Мухаммед (С.В.С)", InsertDate = System.DateTime.Now });
                dbContext.Quotes.Add(new Quote { Text = "Не войдет в рай тот, кто оставит родителей в старости.", Author = "Мухаммед (С.В.С)", InsertDate = System.DateTime.Now });
                dbContext.Quotes.Add(new Quote { Text = "Каждый человек ошибается, но достоин похвалы тот из вас, кто, осознав свою ошибку, пытается её исправить.", Author = "Мухаммед (С.В.С)",InsertDate =  System.DateTime.Now });
                dbContext.Quotes.Add(new Quote { Text = "Самая совершенная вера у того, кто самый благонравный и самый добрый к свой семье.", Author = "Мухаммед (С.В.С)",InsertDate =  System.DateTime.Now });
                dbContext.Quotes.Add(new Quote { Text = "Истинно верующий подобен пчеле: он не потребляет ничего, кроме благого, и не отдаёт ничего, кроме благого.", Author = "Мухаммед (С.В.С)",InsertDate = System.DateTime.Now });
                dbContext.Quotes.Add(new Quote { Text = "Чернила ученого более святы, чем кровь мученика. Так учитесь же грамоте, а научившись, учите других.", Author = "Мухаммед (С.В.С)", InsertDate = System.DateTime.Now });
                dbContext.Quotes.Add(new Quote { Text = "Аллах помогает Своему рабу до тех пор, пока этот раб будет помогать своему брату.", Author = "Мухаммед (С.В.С)", InsertDate = System.DateTime.Now });
                dbContext.Quotes.Add(new Quote { Text = "Не будет помилован тот, кто сам не проявляет милосердия (к другим)!", Author = "Мухаммед (С.В.С)", InsertDate = System.DateTime.Now });
                dbContext.Quotes.Add(new Quote { Text = "Будьте целомудренны в отношении чужих женщин и целомудренными будут ваши женщины!", Author = "Мухаммед (С.В.С)", InsertDate = System.DateTime.Now });
                dbContext.Quotes.Add(new Quote { Text = "Воистину, Аллах, Его ангелы, обитатели небес и земель, даже муравей в своей норке и даже рыбы благословляют того, кто обучает людей добру.", Author = "Мухаммед (С.В.С)", InsertDate = System.DateTime.Now });

                dbContext.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Quote>>> Get()
        {
            return await dbContext.Quotes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Quote>> Get(int id)
        {
            Quote quote = await dbContext.Quotes.FirstOrDefaultAsync(x => x.Id == id);
            if (quote == null)
                return NotFound();
            return new ObjectResult(quote);
        }

        [HttpPost]
        public async Task<ActionResult<Quote>> Post(Quote quote)
        {
            if (quote == null)
            {
                return BadRequest();
            }
            dbContext.Quotes.Add(quote);
            await dbContext.SaveChangesAsync();
            return Ok(quote);
        }

        [HttpPut]
        public async Task<ActionResult<Quote>> Put(Quote quote)
        {
            if (String.IsNullOrEmpty(quote.Text))
                ModelState.AddModelError("Text", "Заполните текст цитаты! Текст не должен быть пустым!");
            if (!Validator.IsDate(quote.InsertDate.ToShortDateString()))
                ModelState.AddModelError("InsertDate", "Заполните дату, учитывая формат: dd/MM/yyyy, yyyy-MM-dd, dd.MM.yyyy");
            
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            dbContext.Quotes.Add(quote);
            await dbContext.SaveChangesAsync();
            return Ok(quote);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Quote>> Delete(int id)
        {
            Quote quote = dbContext.Quotes.FirstOrDefault(x => x.Id == id);
            if (quote == null)
                return NotFound();

            dbContext.Quotes.Remove(quote);
            await dbContext.SaveChangesAsync();
            return Ok(quote);
        }
    }
}