using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace webapp.Models
{
    public class User 
    {

        [BindProperty]
        [Required]
        public string uname { get; set; } = "";

        [BindProperty]
        [Required]
        public string email { get; set; } = "";
        
        
    
    }
   
}
