using Busineess.Abstract;
using KPSPublicServiceReference;

namespace Busineess.Concrete
{
    public class PersonValidationService : IPersonValidationService
    {
        public async Task<bool> ValidateIdentityNumber(long identityNumber, string name, string surname, int birthDate)
        {
            using (var client = new KPSPublicSoapClient(KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap))
            {
                var result = await client.TCKimlikNoDogrulaAsync(identityNumber, name, surname, birthDate);
                return result.Body.TCKimlikNoDogrulaResult;
            }
        }
    }
}
