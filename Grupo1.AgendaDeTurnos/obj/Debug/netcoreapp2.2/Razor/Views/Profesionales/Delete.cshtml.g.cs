#pragma checksum "C:\Users\ak36594446\Desktop\TPNT\2020-1-BENT1C-1\Grupo1.AgendaDeTurnos\Views\Profesionales\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "43db190d71d24670847b2ef84b98ae5a9eadc842"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Profesionales_Delete), @"mvc.1.0.view", @"/Views/Profesionales/Delete.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Profesionales/Delete.cshtml", typeof(AspNetCore.Views_Profesionales_Delete))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"43db190d71d24670847b2ef84b98ae5a9eadc842", @"/Views/Profesionales/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4fe00df73e5f48b0ff460a680b0e5a2a113c921f", @"/Views/_ViewImports.cshtml")]
    public class Views_Profesionales_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Grupo1.AgendaDeTurnos.Models.Profesional>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(49, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\ak36594446\Desktop\TPNT\2020-1-BENT1C-1\Grupo1.AgendaDeTurnos\Views\Profesionales\Delete.cshtml"
  
    ViewData["Title"] = "Delete";

#line default
#line hidden
            BeginContext(93, 10, true);
            WriteLiteral("\r\n    <h1>");
            EndContext();
            BeginContext(105, 29, false);
#line 7 "C:\Users\ak36594446\Desktop\TPNT\2020-1-BENT1C-1\Grupo1.AgendaDeTurnos\Views\Profesionales\Delete.cshtml"
    Write($"{ this.ViewData["Title"] }");

#line default
#line hidden
            EndContext();
            BeginContext(135, 150, true);
            WriteLiteral(" </h1>\r\n\r\n<h3>¿Seguro qué desea eliminar el Registro?</h3>\r\n<hr />\r\n\r\n<div>\r\n    \r\n    <dl class=\"row\">\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(286, 46, false);
#line 16 "C:\Users\ak36594446\Desktop\TPNT\2020-1-BENT1C-1\Grupo1.AgendaDeTurnos\Views\Profesionales\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Prestacion));

#line default
#line hidden
            EndContext();
            BeginContext(332, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(396, 49, false);
#line 19 "C:\Users\ak36594446\Desktop\TPNT\2020-1-BENT1C-1\Grupo1.AgendaDeTurnos\Views\Profesionales\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Prestacion.Nombre));

#line default
#line hidden
            EndContext();
            BeginContext(445, 68, true);
            WriteLiteral("\r\n        </dd class>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(514, 42, false);
#line 22 "C:\Users\ak36594446\Desktop\TPNT\2020-1-BENT1C-1\Grupo1.AgendaDeTurnos\Views\Profesionales\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Centro));

#line default
#line hidden
            EndContext();
            BeginContext(556, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(620, 45, false);
#line 25 "C:\Users\ak36594446\Desktop\TPNT\2020-1-BENT1C-1\Grupo1.AgendaDeTurnos\Views\Profesionales\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Centro.Nombre));

#line default
#line hidden
            EndContext();
            BeginContext(665, 68, true);
            WriteLiteral("\r\n        </dd class>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(734, 42, false);
#line 28 "C:\Users\ak36594446\Desktop\TPNT\2020-1-BENT1C-1\Grupo1.AgendaDeTurnos\Views\Profesionales\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Nombre));

#line default
#line hidden
            EndContext();
            BeginContext(776, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(840, 38, false);
#line 31 "C:\Users\ak36594446\Desktop\TPNT\2020-1-BENT1C-1\Grupo1.AgendaDeTurnos\Views\Profesionales\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Nombre));

#line default
#line hidden
            EndContext();
            BeginContext(878, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(941, 44, false);
#line 34 "C:\Users\ak36594446\Desktop\TPNT\2020-1-BENT1C-1\Grupo1.AgendaDeTurnos\Views\Profesionales\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Apellido));

#line default
#line hidden
            EndContext();
            BeginContext(985, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1049, 40, false);
#line 37 "C:\Users\ak36594446\Desktop\TPNT\2020-1-BENT1C-1\Grupo1.AgendaDeTurnos\Views\Profesionales\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Apellido));

#line default
#line hidden
            EndContext();
            BeginContext(1089, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1152, 39, false);
#line 40 "C:\Users\ak36594446\Desktop\TPNT\2020-1-BENT1C-1\Grupo1.AgendaDeTurnos\Views\Profesionales\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Dni));

#line default
#line hidden
            EndContext();
            BeginContext(1191, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1255, 35, false);
#line 43 "C:\Users\ak36594446\Desktop\TPNT\2020-1-BENT1C-1\Grupo1.AgendaDeTurnos\Views\Profesionales\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Dni));

#line default
#line hidden
            EndContext();
            BeginContext(1290, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1353, 39, false);
#line 46 "C:\Users\ak36594446\Desktop\TPNT\2020-1-BENT1C-1\Grupo1.AgendaDeTurnos\Views\Profesionales\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Rol));

#line default
#line hidden
            EndContext();
            BeginContext(1392, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1456, 35, false);
#line 49 "C:\Users\ak36594446\Desktop\TPNT\2020-1-BENT1C-1\Grupo1.AgendaDeTurnos\Views\Profesionales\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Rol));

#line default
#line hidden
            EndContext();
            BeginContext(1491, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1554, 44, false);
#line 52 "C:\Users\ak36594446\Desktop\TPNT\2020-1-BENT1C-1\Grupo1.AgendaDeTurnos\Views\Profesionales\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Username));

#line default
#line hidden
            EndContext();
            BeginContext(1598, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1662, 40, false);
#line 55 "C:\Users\ak36594446\Desktop\TPNT\2020-1-BENT1C-1\Grupo1.AgendaDeTurnos\Views\Profesionales\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Username));

#line default
#line hidden
            EndContext();
            BeginContext(1702, 38, true);
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n    \r\n    ");
            EndContext();
            BeginContext(1740, 200, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "43db190d71d24670847b2ef84b98ae5a9eadc84211740", async() => {
                BeginContext(1766, 10, true);
                WriteLiteral("\r\n        ");
                EndContext();
                BeginContext(1776, 36, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "43db190d71d24670847b2ef84b98ae5a9eadc84212133", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#line 60 "C:\Users\ak36594446\Desktop\TPNT\2020-1-BENT1C-1\Grupo1.AgendaDeTurnos\Views\Profesionales\Delete.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Id);

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1812, 83, true);
                WriteLiteral("\r\n        <input type=\"submit\" value=\"Delete\" class=\"btn btn-danger\" /> |\r\n        ");
                EndContext();
                BeginContext(1895, 32, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "43db190d71d24670847b2ef84b98ae5a9eadc84214064", async() => {
                    BeginContext(1917, 6, true);
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
                BeginContext(1927, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1940, 10, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Grupo1.AgendaDeTurnos.Models.Profesional> Html { get; private set; }
    }
}
#pragma warning restore 1591
