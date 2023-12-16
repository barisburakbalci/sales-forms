using System.ComponentModel.DataAnnotations.Schema;

namespace sales_forms.Models
{
    public class BaseEntity : IBaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
    }
}
