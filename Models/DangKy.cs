using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace appweb.Models
{
    public class DangKy
    {
        [Required(ErrorMessage = "nhập Gmail.")]
        [EmailAddress(ErrorMessage = "gmail k nhap dung")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]
        public string Gmail { get; set; }
        [Required(ErrorMessage ="nhap tai khoan")]
        public string tenDN { get; set; }
        [Required(ErrorMessage = "nhap mat khau")]
        public string Pass { get; set; }
        [Required(ErrorMessage = "nhap lai mat khau")]
        public string RefestPass { get; set; }
    }
}