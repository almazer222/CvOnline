﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvOnline.Domain.Models.CV_Items
{
    [Table("Social")]
    public class Social
    {
        [Key]
        public int  Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
