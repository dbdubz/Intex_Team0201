#pragma checksum "C:\Users\sdcab\source\repos\Intex_Team0201\backend\Views\Shared\BurialSummary.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e1fea4a14085ca1481d0634ad1a31ee5523ab0f8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_BurialSummary), @"mvc.1.0.view", @"/Views/Shared/BurialSummary.cshtml")]
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
#line 1 "C:\Users\sdcab\source\repos\Intex_Team0201\backend\Views\_ViewImports.cshtml"
using backend;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\sdcab\source\repos\Intex_Team0201\backend\Views\_ViewImports.cshtml"
using backend.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\sdcab\source\repos\Intex_Team0201\backend\Views\_ViewImports.cshtml"
using backend.Infrastructure;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\sdcab\source\repos\Intex_Team0201\backend\Views\_ViewImports.cshtml"
using backend.Models.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\sdcab\source\repos\Intex_Team0201\backend\Views\_ViewImports.cshtml"
using backend.Components;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e1fea4a14085ca1481d0634ad1a31ee5523ab0f8", @"/Views/Shared/BurialSummary.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9d386dae4d5b5c9240c51794f067e9111f115723", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_BurialSummary : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Burialmain>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n\r\n<div class=\"card card-outline-primary m-1 p-1\">\r\n    <div class=\"bg-light p-1\">\r\n        <h4>ID: ");
#nullable restore
#line 9 "C:\Users\sdcab\source\repos\Intex_Team0201\backend\Views\Shared\BurialSummary.cshtml"
           Write(Model.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n    </div>\r\n\r\n    <ul>\r\n        <li>AgeAtDeath: ");
#nullable restore
#line 13 "C:\Users\sdcab\source\repos\Intex_Team0201\backend\Views\Shared\BurialSummary.cshtml"
                   Write(Model.Ageatdeath);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n        <li>Sex: ");
#nullable restore
#line 14 "C:\Users\sdcab\source\repos\Intex_Team0201\backend\Views\Shared\BurialSummary.cshtml"
            Write(Model.Sex);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n        <li>Text: ");
#nullable restore
#line 15 "C:\Users\sdcab\source\repos\Intex_Team0201\backend\Views\Shared\BurialSummary.cshtml"
             Write(Model.Text);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n        <li>Head Direction: ");
#nullable restore
#line 16 "C:\Users\sdcab\source\repos\Intex_Team0201\backend\Views\Shared\BurialSummary.cshtml"
                       Write(Model.Headdirection);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n        <li>Area: ");
#nullable restore
#line 17 "C:\Users\sdcab\source\repos\Intex_Team0201\backend\Views\Shared\BurialSummary.cshtml"
             Write(Model.Area);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n        <li>Burial Number: ");
#nullable restore
#line 18 "C:\Users\sdcab\source\repos\Intex_Team0201\backend\Views\Shared\BurialSummary.cshtml"
                      Write(Model.Burialnumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n        <li>Hair: ");
#nullable restore
#line 19 "C:\Users\sdcab\source\repos\Intex_Team0201\backend\Views\Shared\BurialSummary.cshtml"
             Write(Model.Hair);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n    </ul>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Burialmain> Html { get; private set; }
    }
}
#pragma warning restore 1591
