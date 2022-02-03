using System.Threading.Tasks;

namespace Microsoft.UsedCarDealerWeb.ApplicationCore.Interfaces;

public interface ITokenClaimsService
{
    Task<string> GetTokenAsync(string userName);
}
