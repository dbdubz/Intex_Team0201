#pragma checksum "C:\Users\sdcab\source\repos\Intex_Team0201\backend\Views\Home\ViewRoles.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f896c02bb3c41ea953f1c05ed61a82d0887da03b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_ViewRoles), @"mvc.1.0.view", @"/Views/Home/ViewRoles.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f896c02bb3c41ea953f1c05ed61a82d0887da03b", @"/Views/Home/ViewRoles.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9d386dae4d5b5c9240c51794f067e9111f115723", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_ViewRoles : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Microsoft.AspNetCore.Identity.IdentityRole>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<h1>Roles</h1>\r\n\r\n<table class=\"table-stribed table-bordered\">\r\n    <thead>\r\n        <tr>\r\n            <td>Id</td>\r\n            <td>Name</td>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 18 "C:\Users\sdcab\source\repos\Intex_Team0201\backend\Views\Home\ViewRoles.cshtml"
         foreach (var role in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 21 "C:\Users\sdcab\source\repos\Intex_Team0201\backend\Views\Home\ViewRoles.cshtml"
               Write(role.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 22 "C:\Users\sdcab\source\repos\Intex_Team0201\backend\Views\Home\ViewRoles.cshtml"
               Write(role.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n");
#nullable restore
#line 24 "C:\Users\sdcab\source\repos\Intex_Team0201\backend\Views\Home\ViewRoles.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Microsoft.AspNetCore.Identity.IdentityRole>> Html { get; private set; }
    }
}
#pragma warning restore 1591
