namespace Busineess.Abstract
{
    public interface IPersonValidationService
    {
        Task<bool> ValidateIdentityNumber(long identityNumber, string name, string surname, int birthDate);
    }
}
