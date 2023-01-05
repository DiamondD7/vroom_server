using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vroom_server.Data;
using vroom_server.Model;

namespace vroom_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public FeedbackController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Feedback>>> GetAllFeedback()
        {
            return await _context.Feedbacks.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Feedback>> GetFeedbackById(int id)
        {
            var findId =  await _context.Feedbacks.FindAsync(id);
            if(findId == null)
            {
                return NotFound();
            }

            return findId;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Feedback>> UpdateFeedback(int id)
        {
            var findId = await _context.Feedbacks.FindAsync(id);
            if(findId == null)
            {
                return NotFound();
            }
            _context.Feedbacks.Update(findId);
            await _context.SaveChangesAsync();
            return Ok("Updated");
        }

        [HttpPost]
        public async Task<ActionResult<Feedback>> AddFeedback(Feedback feedback)
        {
            _context.Feedbacks.Add(feedback);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetAllFeedback", new { id = feedback.Id }, feedback);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Feedback>> DeleteById(int id)
        {
            var findId = await _context.Feedbacks.FindAsync(id);
            if(findId == null)
            {
                return NotFound();
            }
            _context.Feedbacks.Remove(findId);
            await _context.SaveChangesAsync();
            return Ok("Deleted");
        }
    }
}
