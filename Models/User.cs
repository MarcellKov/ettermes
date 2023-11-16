using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace webapp.Models
{
    public class User 
    {
        [BindProperty]
        [System.ComponentModel.DataAnnotations.Required]
        public string uname { get; set; } = "";

        [BindProperty]
        [System.ComponentModel.DataAnnotations.Required]
        public string email { get; set; } = "";

        [BindProperty]
        [System.ComponentModel.DataAnnotations.Required]
        public string password { get; set; } = "";
        
    
    }
   
}
