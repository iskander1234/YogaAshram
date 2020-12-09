#pragma checksum "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Membership\_ViewAll.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8dc59ce48039db783ad01b0e617270ea0b303b4e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Membership__ViewAll), @"mvc.1.0.view", @"/Views/Membership/_ViewAll.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8dc59ce48039db783ad01b0e617270ea0b303b4e", @"/Views/Membership/_ViewAll.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"62354149c70a3597a9f5423422692979c890428d", @"/Views/_ViewImports.cshtml")]
    public class Views_Membership__ViewAll : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Membership>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n\n");
            WriteLiteral(@"
<h1 class=""text-center""> Список абонементов</h1>


<table class=""table"">
    <thead class=""thead-light"">
        <tr>
            <th>
              Название
            </th>
            <th>
               Количество дней
            </th>
            <th>
               Цена
            </th>
            <th>
               Категория
            </th>
            <th>
");
#nullable restore
#line 24 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Membership\_ViewAll.cshtml"
                 if (User.IsInRole("chief"))
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("<a");
            BeginWriteAttribute("onclick", " onclick=\"", 472, "\"", 594, 4);
            WriteAttributeValue("", 482, "showInPopup(\'", 482, 13, true);
#nullable restore
#line 25 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Membership\_ViewAll.cshtml"
WriteAttributeValue("", 495, Url.Action("AddOrEdit", "Membership", new {id = 0}, Context.Request.Scheme), 495, 76, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 571, "\',\'Добавить", 571, 11, true);
            WriteAttributeValue(" ", 582, "абонемент\')", 583, 12, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-success text-white\"> Добавить</a>");
#nullable restore
#line 25 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Membership\_ViewAll.cshtml"
                                                                                                                                                                                               }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </th>\n        </tr>\n    </thead>\n    <tbody>\n");
#nullable restore
#line 30 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Membership\_ViewAll.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\n                <td>\n                    ");
#nullable restore
#line 34 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Membership\_ViewAll.cshtml"
               Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </td>\n                <td>\n                    ");
#nullable restore
#line 37 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Membership\_ViewAll.cshtml"
               Write(Html.DisplayFor(modelItem => item.AttendanceDays));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </td>\n                <td>\n                    ");
#nullable restore
#line 40 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Membership\_ViewAll.cshtml"
               Write(Html.DisplayFor(modelItem => item.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </td>\n                <td>\n                    ");
#nullable restore
#line 43 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Membership\_ViewAll.cshtml"
               Write(Html.DisplayFor(modelItem => item.Category.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </td>\n                <td>\n                    <div>\n");
#nullable restore
#line 47 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Membership\_ViewAll.cshtml"
                         if (User.IsInRole("chief"))
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("<a");
            BeginWriteAttribute("onclick", " onclick=\"", 1330, "\"", 1454, 4);
            WriteAttributeValue("", 1340, "showInPopup(\'", 1340, 13, true);
#nullable restore
#line 48 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Membership\_ViewAll.cshtml"
WriteAttributeValue("", 1353, Url.Action("AddOrEdit", "Membership", new {id = item.Id}, Context.Request.Scheme), 1353, 82, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1435, "\',\'Редактировать", 1435, 16, true);
            WriteAttributeValue(" ", 1451, "\')", 1452, 3, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-info text-white\"> Редактировать</a>");
#nullable restore
#line 48 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Membership\_ViewAll.cshtml"
                                                                                                                                                                                                           }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </div>\n                </td>\n            </tr>\n");
#nullable restore
#line 52 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Membership\_ViewAll.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\n</table>\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Membership>> Html { get; private set; }
    }
}
#pragma warning restore 1591