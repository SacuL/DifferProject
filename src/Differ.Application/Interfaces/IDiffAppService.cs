using Differ.Application.ViewModels;
using System;
using System.Threading.Tasks;

namespace Differ.Application.Interfaces
{
    public interface IDiffAppService
    {
        Task<Guid> SaveLeftData(LeftDataViewModel leftData);

        Task SaveRightData(RightDataViewModel rightData);

        Task<DiffViewModel> CalculateDiff(Guid id);

        Task<DiffViewModel> GetById(Guid id);
    }
}