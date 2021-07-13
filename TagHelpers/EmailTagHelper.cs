using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace _23haziran_web.TagHelpers
{
    public class EmailTagHelper : TagHelper // bunu eklediğinde projeyi build solition yap tekrar derle ctrl shift b
    {

    }
    [HtmlTargetElement("mail")]
    public class EmailGonderFormTagHelper : TagHelper
    {
        public String mail { get; set; }
        public String Display { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            output.Attributes.Add("href", $"mailto:{mail}");
            output.Content.Append(Display);    
          //  base.Process(context, output);
        }
    }
}
