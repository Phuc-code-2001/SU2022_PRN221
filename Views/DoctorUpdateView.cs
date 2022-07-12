using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ShinyTeeth.Views
{
    public class DoctorUpdateView
    {
        [DataType(DataType.Upload)]
        [Display(Name = "Qualification Image (Update)")]
        public IFormFile QualificationImage { get; set; }

        public string Major { get; set; }

    }
}
