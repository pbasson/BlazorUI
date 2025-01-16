using Blazor.Core.Models.Entities;

namespace Blazor.Core.Interfaces.InterfaceServices
{
    public interface ITransactionService
    {
        Task<List<CRUDTransactionDTO>> GetAllRecordsAsync();
        Task<CRUDTransactionDTO> GetRecordByIdAsync(int id);
        Task<bool> CreateRecordAsync(CRUDTransactionDTO dto);
        Task<bool> UpdateRecordAsync(CRUDTransactionDTO dto);
        Task<bool> DeleteRecordAsync(int id);
    }
}