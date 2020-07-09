using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Differ.Domain.Models
{
    public class Diff
    {
        public Diff(Guid id, string leftDiffData, string rightDiffData)
        {
            Id = id;
            LeftDiffData = leftDiffData;
            RightDiffData = rightDiffData;
        }

        protected Diff()
        {
        }

        public string LeftDiffData { get; set; }

        public string RightDiffData { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
    }
}