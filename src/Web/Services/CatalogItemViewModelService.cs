using System.Threading.Tasks;
using Microsoft.UsedCarDealerWeb.ApplicationCore.Entities;
using Microsoft.UsedCarDealerWeb.ApplicationCore.Interfaces;
using Microsoft.UsedCarDealerWeb.Web.Interfaces;
using Microsoft.UsedCarDealerWeb.Web.ViewModels;

namespace Microsoft.UsedCarDealerWeb.Web.Services;

public class CatalogItemViewModelService : ICatalogItemViewModelService
{
    private readonly IRepository<CatalogItem> _catalogItemRepository;

    public CatalogItemViewModelService(IRepository<CatalogItem> catalogItemRepository)
    {
        _catalogItemRepository = catalogItemRepository;
    }

    public async Task UpdateCatalogItem(CatalogItemViewModel viewModel)
    {
        var existingCatalogItem = await _catalogItemRepository.GetByIdAsync(viewModel.Id);
        existingCatalogItem.UpdateDetails(viewModel.Name, existingCatalogItem.Description, viewModel.Price);
        await _catalogItemRepository.UpdateAsync(existingCatalogItem);
    }
}
