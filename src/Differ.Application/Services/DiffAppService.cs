using AutoMapper;
using Differ.Application.Interfaces;
using Differ.Application.ViewModels;
using Differ.Domain.Interfaces;
using Differ.Domain.Models;
using System;
using System.Threading.Tasks;

namespace Differ.Application.Services
{
    public class DiffAppService : IDiffAppService
    {
        private readonly IDiffRepository _diffRepository;
        private readonly IDiffDomainService _diffDomainService;
        private readonly IMapper _mapper;

        public DiffAppService(IMapper mapper, IDiffRepository diffRepository, IDiffDomainService diffDomainService)
        {
            _mapper = mapper;
            _diffRepository = diffRepository;
            _diffDomainService = diffDomainService;
        }

        public async Task<DiffViewModel> CalculateDiff(Guid guid)
        {
            return _mapper.Map<DiffViewModel>(await _diffDomainService.CalculateDiff(guid));
        }

        public async Task<DiffViewModel> GetById(Guid id)
        {
            return _mapper.Map<DiffViewModel>(await _diffRepository.GetById(id));
        }

        public async Task<Guid> SaveLeftData(LeftDataViewModel leftViewModel)
        {
            Diff diff = await _diffDomainService.SaveLeftData(_mapper.Map<Diff>(leftViewModel));

            return diff.Id;
        }

        public async Task SaveRightData(RightDataViewModel rightViewModel)
        {
            await _diffDomainService.SaveRightData(_mapper.Map<Diff>(rightViewModel));
        }
    }
}