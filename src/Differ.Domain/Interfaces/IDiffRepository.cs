using Differ.Domain.Models;
using System;
using System.Threading.Tasks;

namespace Differ.Domain.Interfaces
{
    public interface IDiffRepository
    {
        Task<Diff> GetById(Guid id);

        Task<Diff> Add(Diff diff);

        Task<Diff> Update(Diff diff);
    }
}