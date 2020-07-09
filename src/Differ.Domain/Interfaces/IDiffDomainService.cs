using Differ.Domain.Models;
using System;
using System.Threading.Tasks;

namespace Differ.Domain.Interfaces
{
    public interface IDiffDomainService
    {
        public Task<Diff> SaveLeftData(Diff leftDiffData);

        public Task<Diff> SaveRightData(Diff rightDiffData);
        public Task<DiffResult> CalculateDiff(Guid guid);
    }
}