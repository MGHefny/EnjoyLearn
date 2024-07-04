using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace learnApp.Models
{
    public class categoryModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Category Name is Required!")]
        [StringLength(200, MinimumLength = 5,ErrorMessage = "Category Name less than 200")]
        public string name { get; set; }
        public int? ParentId { set; get; }
        public string ParentName { set; get; }
        public int parentCategory { get; set; }
    }
}