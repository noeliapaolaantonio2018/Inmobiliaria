#pragma checksum "C:\Users\Noelia\Documents\InmobiliariaAntonio\Inmobiliaria\Views\Usuarios\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3fc6c2f22c6ab13967ecc5cb1053fc617c4c5be9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Usuarios_Index), @"mvc.1.0.view", @"/Views/Usuarios/Index.cshtml")]
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
#line 1 "C:\Users\Noelia\Documents\InmobiliariaAntonio\Inmobiliaria\Views\_ViewImports.cshtml"
using Inmobiliaria;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Noelia\Documents\InmobiliariaAntonio\Inmobiliaria\Views\_ViewImports.cshtml"
using Inmobiliaria.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3fc6c2f22c6ab13967ecc5cb1053fc617c4c5be9", @"/Views/Usuarios/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"edf381669dde6995b9201d231bb8643b95e5b7cd", @"/Views/_ViewImports.cshtml")]
    public class Views_Usuarios_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Inmobiliaria.Models.Usuarios>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Noelia\Documents\InmobiliariaAntonio\Inmobiliaria\Views\Usuarios\Index.cshtml"
   ViewData["Title"] = "Inicio"; 

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Listado de Usuarios</h2>\r\n\r\n<p>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3fc6c2f22c6ab13967ecc5cb1053fc617c4c5be94074", async() => {
                WriteLiteral("Agregar Usuario");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
</p>
<table height=""100"" width=""100"" background=""../imagenes/inmo.png"" class=""table"">
    <thead>
        <tr>
            <th bgcolor=""#4CAF50"">
                <label>Nombre</label>
            </th>
            <th bgcolor=""#4CAF50"">
                <label>Apellido</label>
            </th>
            <th bgcolor=""#4CAF50"">
                <label>Email</label>
            </th>
            <th bgcolor=""#4CAF50"">
                <label>Clave</label>
            </th>
            <th bgcolor=""#4CAF50"">
                <label>Rol</label>
            </th>
            <th bgcolor=""#4CAF50"">
                <label>Avatar</label>
            </th>
            <th bgcolor=""#4CAF50""></th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 35 "C:\Users\Noelia\Documents\InmobiliariaAntonio\Inmobiliaria\Views\Usuarios\Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("<tr>\r\n    <td>\r\n        ");
#nullable restore
#line 39 "C:\Users\Noelia\Documents\InmobiliariaAntonio\Inmobiliaria\Views\Usuarios\Index.cshtml"
   Write(Html.DisplayFor(modelItem => item.Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </td>\r\n    <td>\r\n        ");
#nullable restore
#line 42 "C:\Users\Noelia\Documents\InmobiliariaAntonio\Inmobiliaria\Views\Usuarios\Index.cshtml"
   Write(Html.DisplayFor(modelItem => item.Apellido));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </td>\r\n    <td>\r\n        ");
#nullable restore
#line 45 "C:\Users\Noelia\Documents\InmobiliariaAntonio\Inmobiliaria\Views\Usuarios\Index.cshtml"
   Write(Html.DisplayFor(modelItem => item.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </td>\r\n    <td>\r\n        ");
#nullable restore
#line 48 "C:\Users\Noelia\Documents\InmobiliariaAntonio\Inmobiliaria\Views\Usuarios\Index.cshtml"
   Write(Html.DisplayFor(modelItem => item.Clave));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </td>\r\n    <td>\r\n        ");
#nullable restore
#line 51 "C:\Users\Noelia\Documents\InmobiliariaAntonio\Inmobiliaria\Views\Usuarios\Index.cshtml"
   Write(Html.DisplayFor(modelItem => item.Rol));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </td>\r\n    <td>\r\n        <img width=\"32\"");
            BeginWriteAttribute("src", " src=\"", 1408, "\"", 1426, 1);
#nullable restore
#line 54 "C:\Users\Noelia\Documents\InmobiliariaAntonio\Inmobiliaria\Views\Usuarios\Index.cshtml"
WriteAttributeValue("", 1414, item.Avatar, 1414, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n    </td>\r\n    <td>\r\n        ");
#nullable restore
#line 57 "C:\Users\Noelia\Documents\InmobiliariaAntonio\Inmobiliaria\Views\Usuarios\Index.cshtml"
   Write(Html.ActionLink("Editar", "Edit", new { id = item.IdUs }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n");
#nullable restore
#line 58 "C:\Users\Noelia\Documents\InmobiliariaAntonio\Inmobiliaria\Views\Usuarios\Index.cshtml"
         if (User.IsInRole("Administrador"))
        {
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 60 "C:\Users\Noelia\Documents\InmobiliariaAntonio\Inmobiliaria\Views\Usuarios\Index.cshtml"
   Write(Html.ActionLink("Eliminar", "Delete", new { id = item.IdUs }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 60 "C:\Users\Noelia\Documents\InmobiliariaAntonio\Inmobiliaria\Views\Usuarios\Index.cshtml"
                                                                      }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </td>\r\n    </tr>\r\n");
#nullable restore
#line 63 "C:\Users\Noelia\Documents\InmobiliariaAntonio\Inmobiliaria\Views\Usuarios\Index.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Inmobiliaria.Models.Usuarios>> Html { get; private set; }
    }
}
#pragma warning restore 1591
