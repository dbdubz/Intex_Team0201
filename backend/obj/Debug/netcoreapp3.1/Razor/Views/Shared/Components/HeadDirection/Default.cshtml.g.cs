#pragma checksum "C:\Users\sdcab\source\repos\Intex_Team0201\backend\Views\Shared\Components\HeadDirection\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0902b721c8637e611a5a520d574938c427af4bd7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_HeadDirection_Default), @"mvc.1.0.view", @"/Views/Shared/Components/HeadDirection/Default.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0902b721c8637e611a5a520d574938c427af4bd7", @"/Views/Shared/Components/HeadDirection/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9d386dae4d5b5c9240c51794f067e9111f115723", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared_Components_HeadDirection_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<string>>
    #nullable disable
    {
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("<div class=\"d-grid gap-2\">\r\n    <h6>Head Direction</h6>\r\n    <select>\r\n");
#nullable restore
#line 8 "C:\Users\sdcab\source\repos\Intex_Team0201\backend\Views\Shared\Components\HeadDirection\Default.cshtml"
         foreach (string t in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0902b721c8637e611a5a520d574938c427af4bd74198", async() => {
#nullable restore
#line 10 "C:\Users\sdcab\source\repos\Intex_Team0201\backend\Views\Shared\Components\HeadDirection\Default.cshtml"
                                            Write(t);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "asp-route-HeadDirection", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 10 "C:\Users\sdcab\source\repos\Intex_Team0201\backend\Views\Shared\Components\HeadDirection\Default.cshtml"
AddHtmlAttributeValue("", 202, t, 202, 2, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 11 "C:\Users\sdcab\source\repos\Intex_Team0201\backend\Views\Shared\Components\HeadDirection\Default.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </select>\r\n\r\n</div>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<string>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
