﻿using System.ComponentModel.DataAnnotations;

namespace Learning_Razor_EF.Models
{
    public class Article
    {
        public int ID { get; set; }
        public string Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; }

        public string Content { set; get; }
    }
}
