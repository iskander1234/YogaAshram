#pragma checksum "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Manager\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ceb3bc31ecbf2a4ae573ca3dff0bbb12d8cd900d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Manager_Index), @"mvc.1.0.view", @"/Views/Manager/Index.cshtml")]
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
#line 1 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\_ViewImports.cshtml"
using yogaAshram;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\_ViewImports.cshtml"
using yogaAshram.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\_ViewImports.cshtml"
using yogaAshram.Models.ModelViews;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Manager\Index.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ceb3bc31ecbf2a4ae573ca3dff0bbb12d8cd900d", @"/Views/Manager/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"62354149c70a3597a9f5423422692979c890428d", @"/Views/_ViewImports.cshtml")]
    public class Views_Manager_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ManagerIndexModelView>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 5 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Manager\Index.cshtml"
  
    ViewBag.Title = "Личный кабинет менеджера";
    Layout = "_Layout";

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"container\">\n\n   \n\n    <h2 class=\"ml-4 mb-3\">Старший менеджер</h2>\n\n    \n   \n</div>\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
            $('#showIndex').click(function() {
                $('#showIndex').css('display', 'none');
                $('#dataIndex').show();
                $('#hideIndex').show();
            });
                   
            $('#hideIndex').click(function() {
                $('#hideIndex').css('display', 'none');
                $('#dataIndex').hide();
                $('#showIndex').show();
            });
    </script>
");
            }
            );
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public UserManager<Employee> UserManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ManagerIndexModelView> Html { get; private set; }
    }
}
#pragma warning restore 1591
