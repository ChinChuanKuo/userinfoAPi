using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace userinfoApi.Models
{
    public class userData
    {
        public string userid { get; set; }
    }

    public class userModels
    {
        [Required]
        public string newid { get; set; }
        [Required]
        public string status { get; set; }
    }

    public class loginData
    {
        public string userid { get; set; }
        public string password { get; set; }
        public string longitude { get; set; }
        public string latitude { get; set; }
        //public string browser { get; set; }
    }

    public class loginModels
    {
        [Required]
        public string newid { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string allname { get; set; }
        [Required]
        public string status { get; set; }
    }

    public class otherData
    {
        public string userid { get; set; }
        public string values { get; set; }
    }

    public class signupData
    {
        public string userid { get; set; }
        public string password { get; set; }
        public string username { get; set; }
        public string birthday { get; set; }
    }

    public class itemsModels
    {
        [Required]
        public bool showItem { get; set; }
        [Required]
        public List<Dictionary<string, object>> items { get; set; }
    }

    public class statusModels
    {
        [Required]
        public string status { get; set; }
    }

    public class permissModels
    {
        [Required]
        public bool insert { get; set; }
        [Required]
        public bool update { get; set; }
        [Required]
        public bool delete { get; set; }
        [Required]
        public bool export { get; set; }
    }
}