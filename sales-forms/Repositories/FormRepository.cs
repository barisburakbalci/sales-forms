using sales_forms.Data;
using sales_forms.Models;
using Microsoft.EntityFrameworkCore;

namespace sales_forms.Repositories
{
    class FormRepository : Repository<Form>
    {
        private readonly FormDbContext _dbContext;

        public FormRepository(FormDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Form> GetFormWithDetails(long id) {
            return _dbContext.Forms
                .Include(form => form.Questions)
                .ThenInclude(question => question.Options)
                .ToList();
        }
    }
}