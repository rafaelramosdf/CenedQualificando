using CenedQualificando.Domain.Models.ViewModels;
using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Web.Admin.Services.RefitApiServices.Base;
using CenedQualificando.Domain.Models.Filters;

namespace CenedQualificando.Web.Admin.Services.RefitApiServices
{
    public interface IPenitenciariaApiService : ICRUDService<Penitenciaria, PenitenciariaFilter, PenitenciariaViewModel>
    {
    }
}
