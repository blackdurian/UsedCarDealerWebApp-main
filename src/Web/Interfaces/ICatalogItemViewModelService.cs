using System.Threading.Tasks;
using Microsoft.UsedCarDealerWeb.Web.ViewModels;

namespace Microsoft.UsedCarDealerWeb.Web.Interfaces;

public interface ICatalogItemViewModelService
{
    Task UpdateCatalogItem(CatalogItemViewModel viewModel);
}
