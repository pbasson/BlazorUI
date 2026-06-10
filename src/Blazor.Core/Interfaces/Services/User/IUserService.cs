namespace Blazor.Core.Interfaces.Services.User;

public interface IUserService
{
    Task<UserTransferGridDTO> GetAllAsync();
    Task<UserTransferDTO> GetByIdAsync(int id);
    Task<UserTransferDTO> GetByNameAsync(string username);
    Task<TransferDTO> CreateAsync(UserDTO dto);
    Task<TransferDTO> UpdateAsync(UserDTO dto);
    Task<bool> DeleteAsync(int id);
}