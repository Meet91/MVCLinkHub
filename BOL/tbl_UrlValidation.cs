using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class tbl_UrlValidation
    {

        [Required]
        public string UrlTitle { get; set; }

        [Required]
        [Url]
        public string Url { get; set; }

        [Required]
        public string UrlDesc { get; set; }
    }

    [MetadataType(typeof(tbl_UrlValidation))]
    public partial class tbl_Url
    { }
}
