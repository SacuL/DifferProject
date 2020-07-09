using System;
using System.ComponentModel.DataAnnotations;

namespace Differ.Application.ViewModels
{
    public class RightDataViewModel
    {
        [Required(ErrorMessage = "Id is Required")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Right Data is Required")]
        public string RightData { get; set; }
    }
}