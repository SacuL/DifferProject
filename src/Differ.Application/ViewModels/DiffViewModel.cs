using System;
using System.Collections.Generic;

namespace Differ.Application.ViewModels
{
    public class DiffViewModel
    {
        public Guid Id { get; set; }
        public string Message { get; set; }

        public List<DifferenceViewModel> Differences { get; set; }
    }

    public class DifferenceViewModel
    {
        public int Offset { get; set; }
        public int Length { get; set; }
    }

    public class DiffRequestViewModel
    {
        public Guid Id { get; set; }
    }
}