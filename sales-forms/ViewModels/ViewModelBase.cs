using System.Reflection;

namespace sales_forms.ViewModels
{
    public class ViewModelBase
    {
        public IDictionary<string, object?> AsDictionary()
        {
            return (
                from property in this.GetType().GetProperties()
                where property.GetValue(this) != null
                select property
            ).ToDictionary(
                propInfo => propInfo.Name,
                propInfo => propInfo.GetValue(this)
            );

        }
    }
}
