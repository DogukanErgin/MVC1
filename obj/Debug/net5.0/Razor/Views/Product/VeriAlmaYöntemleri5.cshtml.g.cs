#pragma checksum "C:\Users\Ergin\Desktop\web\23 haziran web\23haziran-web\Views\Product\VeriAlmaYöntemleri5.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f66bdd6c8553e3fb69f0471b742b006265985a70"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Product_VeriAlmaYöntemleri5), @"mvc.1.0.view", @"/Views/Product/VeriAlmaYöntemleri5.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\Ergin\Desktop\web\23 haziran web\23haziran-web\Views\_ViewImports.cshtml"
using _23haziran_web.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Ergin\Desktop\web\23 haziran web\23haziran-web\Views\_ViewImports.cshtml"
using _23haziran_web;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f66bdd6c8553e3fb69f0471b742b006265985a70", @"/Views/Product/VeriAlmaYöntemleri5.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6b35309bba38129d4c16d0298b02031479fc8de4", @"/Views/_ViewImports.cshtml")]
    public class Views_Product_VeriAlmaYöntemleri5 : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<script src=""https://code.jquery.com/jquery-3.6.0.min.js""></script>
<button id=""btngonder"">gönder</button>

<script>
    $(""#btngonder"").click(() => {
        $.post(""https://localhost:5001/product/verialmayöntemleri5"", { a: "" a data"", b: ""b data"" });
    });  //nesne yakalamak için
</script>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
