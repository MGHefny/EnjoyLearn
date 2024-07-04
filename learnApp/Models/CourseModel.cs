using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace learnApp.Models
{
    public class CourseModel
    {
        public int id { get; set; }
        [Required]
        public string course_name { get; set; }
        public System.DateTime creation_date { get; set; }
        [Required]
        [Display(Name = "Category")]
        public int category_id { get; set; }
        public string category_Name { get; set; }
        [Required]
        [Display(Name = "Trainer")]
        public Nullable<int> instructor_id { get; set; }
        public string trainerName { get; set; }
        public string description { get; set; }
        public categoryModel category { get; set; }
        public SelectList Trainers { get; set; }
        public SelectList Categories { get; set; }
    }
}