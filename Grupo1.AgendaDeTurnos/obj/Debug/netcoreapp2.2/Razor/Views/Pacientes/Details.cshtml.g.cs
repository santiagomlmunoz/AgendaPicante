#pragma checksum "C:\Users\ak36594446\Desktop\TPNT\2020-1-BENT1C-1\Grupo1.AgendaDeTurnos\Views\Pacientes\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "215afb43dfa24876d8e9e340b47ef9bc8f82feb7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Pacientes_Details), @"mvc.1.0.view", @"/Views/Pacientes/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Pacientes/Details.cshtml", typeof(AspNetCore.Views_Pacientes_Details))]
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
#line 1 "C:\Users\ak36594446\Desktop\TPNT\2020-1-BENT1C-1\Grupo1.AgendaDeTurnos\Views\_ViewImports.cshtml"
using Grupo1.AgendaDeTurnos;

#line default
#line hidden
#line 2 "C:\Users\ak36594446\Desktop\TPNT\2020-1-BENT1C-1\Grupo1.AgendaDeTurnos\Views\_ViewImports.cshtml"
using Grupo1.AgendaDeTurnos.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"215afb43dfa24876d8e9e340b47ef9bc8f82feb7", @"/Views/Pacientes/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4fe00df73e5f48b0ff460a680b0e5a2a113c921f", @"/Views/_ViewImports.cshtml")]
    public class Views_Pacientes_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Grupo1.AgendaDeTurnos.Models.Paciente>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
            BeginContext(46, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\ak36594446\Desktop\TPNT\2020-1-BENT1C-1\Grupo1.AgendaDeTurnos\Views\Pacientes\Details.cshtml"
  
    ViewData["Title"] = "Detalle de Paciente";

#line default
#line hidden
            BeginContext(103, 10, true);
            WriteLiteral("\r\n    <h1>");
            EndContext();
            BeginContext(115, 29, false);
#line 7 "C:\Users\ak36594446\Desktop\TPNT\2020-1-BENT1C-1\Grupo1.AgendaDeTurnos\Views\Pacientes\Details.cshtml"
    Write($"{ this.ViewData["Title"] }");

#line default
#line hidden
            EndContext();
            BeginContext(145, 90, true);
            WriteLiteral(" </h1>\r\n\r\n<div>\r\n    \r\n    <dl class=\"row\">\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(236, 42, false);
#line 13 "C:\Users\ak36594446\Desktop\TPNT\2020-1-BENT1C-1\Grupo1.AgendaDeTurnos\Views\Pacientes\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Nombre));

#line default
#line hidden
            EndContext();
            BeginContext(278, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(342, 38, false);
#line 16 "C:\Users\ak36594446\Desktop\TPNT\2020-1-BENT1C-1\Grupo1.AgendaDeTurnos\Views\Pacientes\Details.cshtml"
       Write(Html.DisplayFor(model => model.Nombre));

#line default
#line hidden
            EndContext();
            BeginContext(380, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(443, 44, false);
#line 19 "C:\Users\ak36594446\Desktop\TPNT\2020-1-BENT1C-1\Grupo1.AgendaDeTurnos\Views\Pacientes\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Apellido));

#line default
#line hidden
            EndContext();
            BeginContext(487, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(551, 40, false);
#line 22 "C:\Users\ak36594446\Desktop\TPNT\2020-1-BENT1C-1\Grupo1.AgendaDeTurnos\Views\Pacientes\Details.cshtml"
       Write(Html.DisplayFor(model => model.Apellido));

#line default
#line hidden
            EndContext();
            BeginContext(591, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(654, 39, false);
#line 25 "C:\Users\ak36594446\Desktop\TPNT\2020-1-BENT1C-1\Grupo1.AgendaDeTurnos\Views\Pacientes\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Dni));

#line default
#line hidden
            EndContext();
            BeginContext(693, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(757, 35, false);
#line 28 "C:\Users\ak36594446\Desktop\TPNT\2020-1-BENT1C-1\Grupo1.AgendaDeTurnos\Views\Pacientes\Details.cshtml"
       Write(Html.DisplayFor(model => model.Dni));

#line default
#line hidden
            EndContext();
            BeginContext(792, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(855, 39, false);
#line 31 "C:\Users\ak36594446\Desktop\TPNT\2020-1-BENT1C-1\Grupo1.AgendaDeTurnos\Views\Pacientes\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Rol));

#line default
#line hidden
            EndContext();
            BeginContext(894, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(958, 35, false);
#line 34 "C:\Users\ak36594446\Desktop\TPNT\2020-1-BENT1C-1\Grupo1.AgendaDeTurnos\Views\Pacientes\Details.cshtml"
       Write(Html.DisplayFor(model => model.Rol));

#line default
#line hidden
            EndContext();
            BeginContext(993, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1056, 44, false);
#line 37 "C:\Users\ak36594446\Desktop\TPNT\2020-1-BENT1C-1\Grupo1.AgendaDeTurnos\Views\Pacientes\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Username));

#line default
#line hidden
            EndContext();
            BeginContext(1100, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1164, 40, false);
#line 40 "C:\Users\ak36594446\Desktop\TPNT\2020-1-BENT1C-1\Grupo1.AgendaDeTurnos\Views\Pacientes\Details.cshtml"
       Write(Html.DisplayFor(model => model.Username));

#line default
#line hidden
            EndContext();
            BeginContext(1204, 47, true);
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
            EndContext();
            BeginContext(1251, 54, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "215afb43dfa24876d8e9e340b47ef9bc8f82feb79102", async() => {
                BeginContext(1297, 4, true);
                WriteLiteral("Edit");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 45 "C:\Users\ak36594446\Desktop\TPNT\2020-1-BENT1C-1\Grupo1.AgendaDeTurnos\Views\Pacientes\Details.cshtml"
                           WriteLiteral(Model.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1305, 8, true);
            WriteLiteral(" |\r\n    ");
            EndContext();
            BeginContext(1313, 32, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "215afb43dfa24876d8e9e340b47ef9bc8f82feb711445", async() => {
                BeginContext(1335, 6, true);
                WriteLiteral("Volver");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1345, 10, true);
            WriteLiteral("\r\n</div>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Grupo1.AgendaDeTurnos.Models.Paciente> Html { get; private set; }
    }
}
#pragma warning restore 1591
