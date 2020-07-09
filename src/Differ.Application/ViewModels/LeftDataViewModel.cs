using System.ComponentModel.DataAnnotations;

namespace Differ.Application.ViewModels
{
    public class LeftDataViewModel
    {
        [Required(ErrorMessage = "Left Data is Required")]
        public string LeftData { get; set; }
    }
}