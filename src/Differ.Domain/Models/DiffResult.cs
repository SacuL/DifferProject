using System;
using System.Collections.Generic;

namespace Differ.Domain.Models
{
    public class DiffResult
    {
        public Guid Id { get; set; }

        public string Message { get; set; }

        public List<Difference> Differences { get; set; }
    }

    public class Difference
    {
        public Difference(int offset, int length)
        {
            Offset = offset;
            Length = length;
        }

        public int Offset { get; set; }
        public int Length { get; set; }
    }
}