using back_end.Domain.Entities;
using back_end.DTO;
using CloudinaryDotNet.Actions;
using CloudinaryDotNet;

namespace back_end.ServiceContracts.Repository
{
    public interface INewConnectionFormRepository
    {
        Task<IEnumerable<NewConnectionForm>> GetAllNewConnectionFormsAsync();
        Task<NewConnectionFormDTO> GetNewConnectionFormByIdAsync(int id);
        Task<NewConnectionForm> AddNewConnectionFormAsync(NewConnectionFormDTO newConnectionForm);
        Task<bool> HasAppliedForConnection();
        Task<bool> DeleteNewConnectionFormAsync(int id);
    }
}
