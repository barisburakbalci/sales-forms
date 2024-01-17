using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sales_forms.Data;
using sales_forms.Models;
using sales_forms.ViewModels;

namespace sales_forms.Controllers
{
    [Route("api/[controller]")]
    public class ParticipantController : GenericControllerBase<Participant, CreateParticipantVM, UpdateParticipantVM>
    {
        public ParticipantController(FormDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        [HttpGet("{id}/withForms")]
        public List<Form> Get(long id)
        {
            return (from participant in _dbContext.Participants
                    join answer in _dbContext.Answers on participant.Id equals answer.ParticipantId
                    join question in _dbContext.Questions on answer.QuestionId equals question.Id
                    join option in _dbContext.Options on answer.OptionId equals option.Id
                    join form in _dbContext.Forms on question.FormId equals form.Id
                    where participant.Id == id
                    select form).Distinct().ToList();
        }

        [HttpGet("{id}/withFormDetails")]
        public List<Form> GetDetailed(long id)
        {
            return (from participant in _dbContext.Participants
                   join answer in _dbContext.Answers on participant.Id equals answer.ParticipantId
                   join question in _dbContext.Questions on answer.QuestionId equals question.Id
                   join option in _dbContext.Options on answer.OptionId equals option.Id
                   join form in _dbContext.Forms on question.FormId equals form.Id
                   where participant.Id == id
                   select form
            )
            .Distinct()
            .Include(form => form.Questions)
            .ThenInclude(question => question.Options)
            .Include(form => form.Questions)
            .ThenInclude(question => question.Answers)
            .ToList();
        }
    }
}