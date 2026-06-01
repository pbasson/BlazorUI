namespace Blazor.Core.Interfaces.Services;

public interface IUserService
{
    Task<UserTransferGridDTO> GetAllAsync();
    Task<UserDTO> GetByIdAsync(int id);
    Task<TransferDTO> CreateAsync(UserDTO dto);
    Task<TransferDTO> UpdateAsync(UserDTO dto);
    Task<bool> DeleteAsync(int id);
}