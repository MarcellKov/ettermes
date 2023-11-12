using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace webapp.DataModels
{
    public class UserDataModel
    {
        [Key]
        public Guid id { get; set; }
        
        public string uname { get; set; } = "";

        
        public string email { get; set; } = "";
    }
}
