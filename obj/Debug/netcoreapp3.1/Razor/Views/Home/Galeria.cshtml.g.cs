#pragma checksum "C:\Users\Noelia\Documents\InmobiliariaAntonio\Inmobiliaria\Views\Home\Galeria.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "91465544c504a46bb56847ca3e419e5f979d31fc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Galeria), @"mvc.1.0.view", @"/Views/Home/Galeria.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"91465544c504a46bb56847ca3e419e5f979d31fc", @"/Views/Home/Galeria.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"edf381669dde6995b9201d231bb8643b95e5b7cd", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Galeria : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Inmobiliaria.Models.Inmuebles>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Noelia\Documents\InmobiliariaAntonio\Inmobiliaria\Views\Home\Galeria.cshtml"
   ViewData["Title"] = "Galeria"; 

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Alquileres</h2>\r\n<h4><a class=\"nav-link\" href=\"../Inmuebles/Disponibles\">Ver solo Disponibles</a></h4>\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n\r\n            <th>\r\n                ");
#nullable restore
#line 13 "C:\Users\Noelia\Documents\InmobiliariaAntonio\Inmobiliaria\Views\Home\Galeria.cshtml"
           Write(Html.DisplayNameFor(model => model.Direccion));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 16 "C:\Users\Noelia\Documents\InmobiliariaAntonio\Inmobiliaria\Views\Home\Galeria.cshtml"
           Write(Html.DisplayNameFor(model => model.Tipo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 19 "C:\Users\Noelia\Documents\InmobiliariaAntonio\Inmobiliaria\Views\Home\Galeria.cshtml"
           Write(Html.DisplayNameFor(model => model.Uso));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 22 "C:\Users\Noelia\Documents\InmobiliariaAntonio\Inmobiliaria\Views\Home\Galeria.cshtml"
           Write(Html.DisplayNameFor(model => model.CantAmbientes));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 25 "C:\Users\Noelia\Documents\InmobiliariaAntonio\Inmobiliaria\Views\Home\Galeria.cshtml"
           Write(Html.DisplayNameFor(model => model.Costo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 32 "C:\Users\Noelia\Documents\InmobiliariaAntonio\Inmobiliaria\Views\Home\Galeria.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("<tr>\r\n\r\n    <td>\r\n        ");
#nullable restore
#line 37 "C:\Users\Noelia\Documents\InmobiliariaAntonio\Inmobiliaria\Views\Home\Galeria.cshtml"
   Write(Html.DisplayFor(modelItem => item.Direccion));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </td>\r\n    <td>\r\n        ");
#nullable restore
#line 40 "C:\Users\Noelia\Documents\InmobiliariaAntonio\Inmobiliaria\Views\Home\Galeria.cshtml"
   Write(Html.DisplayFor(modelItem => item.Tipo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </td>\r\n    <td>\r\n        ");
#nullable restore
#line 43 "C:\Users\Noelia\Documents\InmobiliariaAntonio\Inmobiliaria\Views\Home\Galeria.cshtml"
   Write(Html.DisplayFor(modelItem => item.Uso));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </td>\r\n    <td>\r\n        ");
#nullable restore
#line 46 "C:\Users\Noelia\Documents\InmobiliariaAntonio\Inmobiliaria\Views\Home\Galeria.cshtml"
   Write(Html.DisplayFor(modelItem => item.CantAmbientes));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </td>\r\n    <td>\r\n        ");
#nullable restore
#line 49 "C:\Users\Noelia\Documents\InmobiliariaAntonio\Inmobiliaria\Views\Home\Galeria.cshtml"
   Write(Html.DisplayFor(modelItem => item.Costo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </td>\r\n\r\n</tr>");
#nullable restore
#line 52 "C:\Users\Noelia\Documents\InmobiliariaAntonio\Inmobiliaria\Views\Home\Galeria.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Inmobiliaria.Models.Inmuebles>> Html { get; private set; }
    }
}
#pragma warning restore 1591
