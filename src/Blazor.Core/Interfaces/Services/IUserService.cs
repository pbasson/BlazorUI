namespace Blazor.Core.Interfaces.Services;

public interface IUserService
{
    Task<UserTransferGridDTO> GetAllAsync();
    Task<UserDTO> GetByIdAsync(int id);
    Task<bool> CreateAsync(UserDTO dto);
    Task<bool> UpdateAsync(UserDTO dto);
    Task<bool> DeleteAsync(int id);
}