#pragma checksum "C:\Users\Noelia\Documents\InmobiliariaAntonio\Inmobiliaria\Views\Pagos\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6f7a351ec74fe2c80d5672afa600d5f098128819"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Pagos_Index), @"mvc.1.0.view", @"/Views/Pagos/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6f7a351ec74fe2c80d5672afa600d5f098128819", @"/Views/Pagos/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"edf381669dde6995b9201d231bb8643b95e5b7cd", @"/Views/_ViewImports.cshtml")]
    public class Views_Pagos_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Inmobiliaria.Models.Pagos>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Noelia\Documents\InmobiliariaAntonio\Inmobiliaria\Views\Pagos\Index.cshtml"
  
    ViewData["Title"] = "Inicio Pagos";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h2>Listado de Pagos</h2>

<table class=""table"">
    <thead>
        <tr>
            <th bgcolor=""#4CAF50""<label>Codigo Pago</label>
            </th>
            <th bgcolor=""#4CAF50"" <label>N?? de Pago</label>
            </th>
            <th bgcolor=""#4CAF50"" <label>N?? Contrato</label>
            </th>
            <th bgcolor=""#4CAF50"" <label>Fecha de Pago</label>
            </th>
            <th bgcolor=""#4CAF50"">
                ");
#nullable restore
#line 21 "C:\Users\Noelia\Documents\InmobiliariaAntonio\Inmobiliaria\Views\Pagos\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Importe));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th bgcolor=\"#4CAF50\"></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 27 "C:\Users\Noelia\Documents\InmobiliariaAntonio\Inmobiliaria\Views\Pagos\Index.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 30 "C:\Users\Noelia\Documents\InmobiliariaAntonio\Inmobiliaria\Views\Pagos\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.IdPago));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 33 "C:\Users\Noelia\Documents\InmobiliariaAntonio\Inmobiliaria\Views\Pagos\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.NumPago));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 36 "C:\Users\Noelia\Documents\InmobiliariaAntonio\Inmobiliaria\Views\Pagos\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.IdContr));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 39 "C:\Users\Noelia\Documents\InmobiliariaAntonio\Inmobiliaria\Views\Pagos\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.FechaPago));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 42 "C:\Users\Noelia\Documents\InmobiliariaAntonio\Inmobiliaria\Views\Pagos\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Importe));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 45 "C:\Users\Noelia\Documents\InmobiliariaAntonio\Inmobiliaria\Views\Pagos\Index.cshtml"
           Write(Html.ActionLink("Editar", "Edit", new { id=item.IdPago}));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                \r\n                ");
#nullable restore
#line 47 "C:\Users\Noelia\Documents\InmobiliariaAntonio\Inmobiliaria\Views\Pagos\Index.cshtml"
           Write(Html.ActionLink("Eliminar", "Delete", new { id=item.IdPago }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 50 "C:\Users\Noelia\Documents\InmobiliariaAntonio\Inmobiliaria\Views\Pagos\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Inmobiliaria.Models.Pagos>> Html { get; private set; }
    }
}
#pragma warning restore 1591
