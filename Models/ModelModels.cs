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

    public class sSiteModels
    {
        [Required]
        public bool images { get; set; }
        [Required]
        public bool videos { get; set; }
        [Required]
        public bool audios { get; set; }
        [Required]
        public string src { get; set; }
        [Required]
        public string imagePath { get; set; }
        [Required]
        public string original { get; set; }
        [Required]
        public string encryption { get; set; }
        [Required]
        public string extension { get; set; }
        [Required]
        public string date { get; set; }
        [Required]
        public string status { get; set; }
    }

    public class sRowsData
    {
        public string formId { get; set; }
        public string value { get; set; }
        public string newid { get; set; }
    }

    public class sFileData
    {
        public string imagePath { get; set; }
        public string original { get; set; }
        public string encryption { get; set; }
        public string extension { get; set; }
        public string newid { get; set; }
    }

    public class sDataModels
    {
        [Required]
        public string value { get; set; }
        [Required]
        public string status { get; set; }
    }

    public class iIconData
    {
        public List<Dictionary<string, object>> items { get; set; }
        public List<Dictionary<string, object>> qaitems { get; set; }
        public string newid { get; set; }
    }
}