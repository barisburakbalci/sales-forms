using Microsoft.AspNetCore.Mvc;
using sales_forms.Models;
using sales_forms.Data;
using sales_forms.ViewModels;

namespace sales_forms.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantController : ControllerBase
    {
        public FormDbContext _dbContext;

        public ParticipantController(FormDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IEnumerable<Participant> Get()
        {
            return _dbContext.Participants.ToList();
        }

        [HttpGet("{id}")]
        public Participant? Get(long id)
        {
            return _dbContext.Participants.SingleOrDefault(q => q.Id == id);
        }

        [HttpPost]
        public Participant? Post([FromBody] CreateParticipantVM participantData)
        {
            Participant participant = (Participant)participantData;
            _dbContext.Participants.Add(participant);
            _dbContext.SaveChanges();

            return participant;
        }

        [HttpPut("{id}")]
        public Participant? Put(long id, [FromBody] UpdateParticipantVM participant)
        {
            var existingParticipant = _dbContext.Participants.SingleOrDefault(q => q.Id == id);

            if (existingParticipant != null)
            {
                _dbContext.Participants.Entry(existingParticipant).CurrentValues.SetValues(participant.AsDictionary());
                _dbContext.SaveChanges();
            }

            return existingParticipant;
        }

        [HttpDelete("{id}")]
        public Participant? Delete(long id)
        {
            var existingParticipant = _dbContext.Participants.SingleOrDefault(q => q.Id == id);

            if (existingParticipant != null)
            {
                _dbContext.Participants.Remove(existingParticipant);
                _dbContext.SaveChanges();
            }

            return existingParticipant;
        }
    }
}
