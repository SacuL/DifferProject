using Differ.Domain.Interfaces;
using Differ.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Differ.Domain.Services
{
    public class DiffDomainService : IDiffDomainService
    {
        private IDiffRepository _diffRepository;

        public DiffDomainService(IDiffRepository diffRepository)
        {
            _diffRepository = diffRepository;
        }

        private List<Difference> GetDifferences(Diff diff)
        {
            List<Difference> differences = new List<Difference>();
            int initialDiffPosition = -1;
            for (int i = 0; i < diff.LeftDiffData.Length; i++)
            {
                if (diff.LeftDiffData[i] != diff.RightDiffData[i])
                {
                    if (initialDiffPosition == -1)
                    {
                        initialDiffPosition = i;
                    }
                }
                else if (initialDiffPosition >= 0)
                {
                    differences.Add(new Difference(initialDiffPosition, i - initialDiffPosition));
                    initialDiffPosition = -1;
                }
            }

            if (initialDiffPosition >= 0)
            {
                differences.Add(new Difference(initialDiffPosition, diff.LeftDiffData.Length - initialDiffPosition));
            }

            return differences;
        }

         public async Task<DiffResult> CalculateDiff(Guid guid)
        {
            Diff diff = await _diffRepository.GetById(guid);

            DiffResult diffResult = new DiffResult();
            diffResult.Id = diff.Id;

            if (diff.LeftDiffData.Length != diff.RightDiffData.Length)
            {
                diffResult.Message = "Left size != Right size";
            }
            else
            {
                List<Difference> differences = GetDifferences(diff);

                if (differences.Count == 1)
                {
                    diffResult.Message = "There is 1 difference";
                    diffResult.Differences = differences;
                }
                else if (differences.Count > 1)
                {
                    diffResult.Message = $"There are {differences.Count} differences";
                    diffResult.Differences = differences;
                }
                else
                {
                    diffResult.Message = "There are no differences";
                }
            }
            return diffResult;
        }

        public async Task<Diff> SaveLeftData(Diff leftDiffData)
        {
            return await _diffRepository.Add(leftDiffData);
        }

        public async Task<Diff> SaveRightData(Diff rightDiffData)
        {
            Diff diffData = await _diffRepository.GetById(rightDiffData.Id);

            diffData.RightDiffData = rightDiffData.RightDiffData;

            return await _diffRepository.Update(diffData);
        }
    }
}