#pragma checksum "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Clients\CheckAttendanceTrial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c8970d946a117fc3221e8de16242240fdfe8cc79"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Clients_CheckAttendanceTrial), @"mvc.1.0.view", @"/Views/Clients/CheckAttendanceTrial.cshtml")]
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
#line 2 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Clients\CheckAttendanceTrial.cshtml"
using Microsoft.EntityFrameworkCore.Metadata.Internal;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c8970d946a117fc3221e8de16242240fdfe8cc79", @"/Views/Clients/CheckAttendanceTrial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"62354149c70a3597a9f5423422692979c890428d", @"/Views/_ViewImports.cshtml")]
    public class Views_Clients_CheckAttendanceTrial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<TrialUsers>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "2", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "3", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 4 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Clients\CheckAttendanceTrial.cshtml"
  
    ViewBag.Title = "title";
    Layout = "_Layout";

#line default
#line hidden
#nullable disable
            WriteLiteral("<h2>Посещаемость</h2>\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c8970d946a117fc3221e8de16242240fdfe8cc794937", async() => {
                WriteLiteral("\n    <input name=\"HbranchId\"");
                BeginWriteAttribute("value", " value=\"", 215, "\"", 246, 1);
#nullable restore
#line 10 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Clients\CheckAttendanceTrial.cshtml"
WriteAttributeValue("", 223, ViewBag.BranchIdHidden, 223, 23, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" type=\"hidden\"/>\n    <table class=\"table\">\n        <th>Id</th>\n        <th>Клиент</th>\n        <th>Группа</th>\n        <th>Дата урока</th>\n        <th>Состояние</th>\n\n");
#nullable restore
#line 18 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Clients\CheckAttendanceTrial.cshtml"
         foreach (var client in @Model)
        {


#line default
#line hidden
#nullable disable
                WriteLiteral("            <tr>\n                <td>");
#nullable restore
#line 22 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Clients\CheckAttendanceTrial.cshtml"
               Write(client.Id);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\n                <td>");
#nullable restore
#line 23 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Clients\CheckAttendanceTrial.cshtml"
               Write(client.Client.NameSurname);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\n                <td>");
#nullable restore
#line 24 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Clients\CheckAttendanceTrial.cshtml"
               Write(client.Group.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\n                <td>");
#nullable restore
#line 25 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Clients\CheckAttendanceTrial.cshtml"
               Write(client.LessonTime.ToShortDateString());

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\n\n                <td>\n                    <input name=\"arrayOfCustomerID\"");
                BeginWriteAttribute("value", " value=\"", 751, "\"", 769, 1);
#nullable restore
#line 28 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Clients\CheckAttendanceTrial.cshtml"
WriteAttributeValue("", 759, client.Id, 759, 10, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" type=\"hidden\">\n                    <select name=\"arrayOfState\">\n\n                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c8970d946a117fc3221e8de16242240fdfe8cc797668", async() => {
                    WriteLiteral("Пришел");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c8970d946a117fc3221e8de16242240fdfe8cc798913", async() => {
                    WriteLiteral("Непришел");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n                    </select>\n                </td>\n            </tr>");
#nullable restore
#line 35 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Clients\CheckAttendanceTrial.cshtml"
                 }

#line default
#line hidden
#nullable disable
                WriteLiteral("\n    </table>\n    <input class=\"btn btn btn-outline-secondary btn-block my-4\" id=\"SendForm\" type=\"submit\" value=\"Сохранить\"/>\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n\n   \n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\n    \n    <script>\n   $( \"#SendForm\" ).onsubmit(function()\n   {\n     \n       const arrayOfCustomerID = [];\n       const arrayOfState = [];\n       var HbranchId;\n           $.ajax({\n               url: ");
#nullable restore
#line 53 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Clients\CheckAttendanceTrial.cshtml"
               Write(Url.Action("CheckAttendanceTrial","Clients"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@",
               type: ""POST"",
               datatype: ""json"",
               traditional: true,
               data: {
                   
                  arrayOfCustomerID : arrayOfCustomerID,
                  arrayOfState : arrayOfState,
                  HbranchId:HbranchId
               },
               success: function (data) {
                  console.log(""Успешно"");
               }
           });
   });
   
    </script>
");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<TrialUsers>> Html { get; private set; }
    }
}
#pragma warning restore 1591
