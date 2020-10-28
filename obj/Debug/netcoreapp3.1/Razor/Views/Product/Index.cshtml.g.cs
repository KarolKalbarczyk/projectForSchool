#pragma checksum "C:\Users\Karol\source\repos\ASP-pl\ASP-pl\Views\Product\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "aad633561c20800dd3cf7eb896c1447c2107a84e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Product_Index), @"mvc.1.0.view", @"/Views/Product/Index.cshtml")]
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
#line 1 "C:\Users\Karol\source\repos\ASP-pl\ASP-pl\Views\_ViewImports.cshtml"
using ASP_pl;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Karol\source\repos\ASP-pl\ASP-pl\Views\_ViewImports.cshtml"
using ASP_pl.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\Karol\source\repos\ASP-pl\ASP-pl\Views\Product\Index.cshtml"
using ASP_pl.Product;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"aad633561c20800dd3cf7eb896c1447c2107a84e", @"/Views/Product/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4c68755b222ea4c49f1e1f2a417613bdd029fabf", @"/Views/_ViewImports.cshtml")]
    public class Views_Product_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 4 "C:\Users\Karol\source\repos\ASP-pl\ASP-pl\Views\Product\Index.cshtml"
  
    var products = (IEnumerable<ProductViewModel>)ViewBag.Products;
    var isAdmin = (bool)ViewBag.IsAdmin;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<button");
            BeginWriteAttribute("onclick", " onclick=\"", 155, "\"", 210, 3);
            WriteAttributeValue("", 165, "location.href=\'", 165, 15, true);
#nullable restore
#line 9 "C:\Users\Karol\source\repos\ASP-pl\ASP-pl\Views\Product\Index.cshtml"
WriteAttributeValue("", 180, Url.Action("New", "Product"), 180, 29, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 209, "\'", 209, 1, true);
            EndWriteAttribute();
            WriteLiteral(">Add New Product</button>\r\n<button");
            BeginWriteAttribute("onclick", " onclick=\"", 245, "\"", 307, 3);
            WriteAttributeValue("", 255, "location.href=\'", 255, 15, true);
#nullable restore
#line 10 "C:\Users\Karol\source\repos\ASP-pl\ASP-pl\Views\Product\Index.cshtml"
WriteAttributeValue("", 270, Url.Action("Invalidate", "Product"), 270, 36, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 306, "\'", 306, 1, true);
            EndWriteAttribute();
            WriteLiteral(">Invalidate</button>\r\n\r\n<div>\r\n    <table class=\"table table-bordered table-responsive table-hover\">\r\n");
#nullable restore
#line 14 "C:\Users\Karol\source\repos\ASP-pl\ASP-pl\Views\Product\Index.cshtml"
         foreach (var product in products)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 17 "C:\Users\Karol\source\repos\ASP-pl\ASP-pl\Views\Product\Index.cshtml"
               Write(product.Code);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 18 "C:\Users\Karol\source\repos\ASP-pl\ASP-pl\Views\Product\Index.cshtml"
               Write(product.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 19 "C:\Users\Karol\source\repos\ASP-pl\ASP-pl\Views\Product\Index.cshtml"
                 foreach (var (erp, price) in product.Prices)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td>");
#nullable restore
#line 21 "C:\Users\Karol\source\repos\ASP-pl\ASP-pl\Views\Product\Index.cshtml"
                    Write($"{erp}: {price}");

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 22 "C:\Users\Karol\source\repos\ASP-pl\ASP-pl\Views\Product\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 23 "C:\Users\Karol\source\repos\ASP-pl\ASP-pl\Views\Product\Index.cshtml"
                 if (isAdmin)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <td>\r\n                <button");
            BeginWriteAttribute("onclick", " onclick=\"", 813, "\"", 905, 3);
            WriteAttributeValue("", 823, "location.href=\'", 823, 15, true);
#nullable restore
#line 26 "C:\Users\Karol\source\repos\ASP-pl\ASP-pl\Views\Product\Index.cshtml"
WriteAttributeValue("", 838, Url.Action("Product", "Synchronization", new { id = product.Id }), 838, 66, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 904, "\'", 904, 1, true);
            EndWriteAttribute();
            WriteLiteral(">Synchronize</button>\r\n            </td>\r\n            <td>\r\n                <button");
            BeginWriteAttribute("onclick", " onclick=\"", 989, "\"", 1072, 3);
            WriteAttributeValue("", 999, "location.href=\'", 999, 15, true);
#nullable restore
#line 29 "C:\Users\Karol\source\repos\ASP-pl\ASP-pl\Views\Product\Index.cshtml"
WriteAttributeValue("", 1014, Url.Action("Modify", "Product", new { id = product.Id }), 1014, 57, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1071, "\'", 1071, 1, true);
            EndWriteAttribute();
            WriteLiteral(">Modify</button>\r\n            </td>\r\n");
#nullable restore
#line 31 "C:\Users\Karol\source\repos\ASP-pl\ASP-pl\Views\Product\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tr>\r\n");
#nullable restore
#line 33 "C:\Users\Karol\source\repos\ASP-pl\ASP-pl\Views\Product\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </table>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591