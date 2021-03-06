#pragma checksum "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Employees\PartialViews\ChangePasswordPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "98aff5edbce83929a4166e098dd6353d351f2409"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Employees_PartialViews_ChangePasswordPartial), @"mvc.1.0.view", @"/Views/Employees/PartialViews/ChangePasswordPartial.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"98aff5edbce83929a4166e098dd6353d351f2409", @"/Views/Employees/PartialViews/ChangePasswordPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"62354149c70a3597a9f5423422692979c890428d", @"/Views/_ViewImports.cshtml")]
    public class Views_Employees_PartialViews_ChangePasswordPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ChangePasswordModelView>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
            WriteLiteral(@"<!-- Modal -->
<div class=""modal fade"" id=""changePasswordModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""exampleModalLabel"">Изменение пароля</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
                <div class=""modal-body"">
                    <div class=""form-group"">
                        <label>Введите текущий пароль<span class=""text-danger"">*</span></label>
                        <input type=""password"" class=""form-control"" id=""currentPassword"">
                        <span class=""text-danger"" id=""invalidCurPassword""></span>
                    </div>
                    <div class=""form-group"">
                        <label>Введите новый ");
            WriteLiteral(@"пароль<span class=""text-danger"">*</span></label>
                        <input type=""password"" class=""form-control"" id=""newPassword"">
                        <span class=""text-danger"" id=""invalidNewPassword""></span>
                    </div>
                    <div class=""form-group"">
                        <label>Подтвердите пароль<span class=""text-danger"">*</span></label>
                        <input type=""password"" class=""form-control"" id=""newPasswordConfirm"">
                        <span class=""text-danger"" id=""invalidNewPasswordConfirm""></span>
                    </div>
                </div>
                <div class=""modal-footer"">
                    <button type=""button"" class=""btn btn-dark"" data-dismiss=""modal"">Закрыть</button>
                    <button type=""button"" id=""changePasswordSubmit"" class=""btn btn-secondary"">Сохранить</button>
                </div>
        </div>
    </div>
</div>
<script>
    function checkLength(text, length = 6) {
        if (text.length < length) {
        ");
            WriteLiteral(@"    return false;
        }
        else {
            return true;
        }
    }
    $('#changePasswordSubmit').on('click', function () {
        var curPsw = $('#currentPassword').val();
        var truth = true;
        if (!checkRequired(curPsw)) {
            $('#invalidCurPassword').html('Введите текущий пароль');
        }
        else {
            $.get('");
#nullable restore
#line 53 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Employees\PartialViews\ChangePasswordPartial.cshtml"
              Write(Url.Action("CheckPassword", "Validation"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"/?currentPassword=' + curPsw, function (data) {
                if (data) {
                    $('#invalidCurPassword').html('');
                    var newPsw = $('#newPassword').val();
                    if (!checkRequired(newPsw)) {
                        $('#invalidNewPassword').html('Введите новый пароль');
                        truth = false
                    }
                    else if (!checkLength(newPsw)) {
                        $('#invalidNewPassword').html('Минимальная длина пароля - 6 символов');
                        truth = false;
                    }
                    else {
                        $('#invalidNewPassword').html('');
                    }
                    var newPswConfirm = $('#newPasswordConfirm').val();
                    if (!checkRequired(newPswConfirm)) {
                        $('#invalidNewPasswordConfirm').html('Подтвердите пароль');
                        truth = false
                    }
                    else if (newPswConfirm != newPsw) {");
            WriteLiteral(@"
                        $('#invalidNewPasswordConfirm').html('Пароли не совпадают');
                        truth = false;
                    }
                    else {
                        $('#invalidNewPasswordConfirm').html('');
                    }
                    if (truth) {
                        $('#changePasswordModal').modal('hide');
                        $.ajax({
                            url: '");
#nullable restore
#line 83 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Employees\PartialViews\ChangePasswordPartial.cshtml"
                             Write(Url.Action("ChangePasswordAjax", "Employees"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"',
                            type: 'POST',
                            datatype: 'json',
                            cache: false,
                            data: {
                                'CurrentPassword': curPsw,
                                'NewPassword': newPsw,
                                'PasswordConfirm': newPswConfirm
                            },
                            success: function (data) {
                                if (data) {
                                    document.location.reload();
                                }
                            }
                        })
                    }
                }
                else {
                    $('#invalidCurPassword').html('Неверный пароль');
                }
            })
        }
    })
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ChangePasswordModelView> Html { get; private set; }
    }
}
#pragma warning restore 1591
