#pragma checksum "D:\SUMMER 2022\PRN221\Assignment\ShinyTeeth\Pages\Messages\Receptionist.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "29e604ee6219966716952db747ed235d9e93e311"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ShinyTeeth.Pages.Messages.Pages_Messages_Receptionist), @"mvc.1.0.razor-page", @"/Pages/Messages/Receptionist.cshtml")]
namespace ShinyTeeth.Pages.Messages
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
#line 1 "D:\SUMMER 2022\PRN221\Assignment\ShinyTeeth\Pages\_ViewImports.cshtml"
using ShinyTeeth;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"29e604ee6219966716952db747ed235d9e93e311", @"/Pages/Messages/Receptionist.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b586d0190c7d21d984ecefa2ceb32205e69fb228", @"/Pages/_ViewImports.cshtml")]
    #nullable restore
    public class Pages_Messages_Receptionist : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/chat.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("input_msg_write"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("chat-form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<link rel=\"stylesheet\" href=\"https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css\">\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "29e604ee6219966716952db747ed235d9e93e3115105", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

<div class=""messaging"">
  <div class=""inbox_msg"">
	<div class=""inbox_people"">
	  <div class=""headind_srch"">
		<div class=""recent_heading"">
		  <h4>Recent</h4>
		</div>
		
	  </div>
	  <div class=""inbox_chat scroll"" id=""inbox_chat"">
		
		
		
	  </div>
	</div>
	<div class=""mesgs"">
	  <div class=""msg_history"" id=""msg_history"">
");
#nullable restore
#line 26 "D:\SUMMER 2022\PRN221\Assignment\ShinyTeeth\Pages\Messages\Receptionist.cshtml"
             foreach(var message in Model.ChatMessages)
				{
					if(message.Type == Models.ChatMessage.Types.Sender)
					{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t<div class=\"incoming_msg\">\r\n\t\t\t\t\t\t\t<div class=\"incoming_msg_img\"> <img");
            BeginWriteAttribute("src", " src=\"", 769, "\"", 797, 1);
#nullable restore
#line 31 "D:\SUMMER 2022\PRN221\Assignment\ShinyTeeth\Pages\Messages\Receptionist.cshtml"
WriteAttributeValue("", 775, message.User.ImageURL, 775, 22, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"admin\"> </div>\r\n\t\t\t\t\t\t\t<div class=\"received_msg\">\r\n\t\t\t\t\t\t\t<div class=\"received_withd_msg\">\r\n\t\t\t\t\t\t\t\t<p>");
#nullable restore
#line 34 "D:\SUMMER 2022\PRN221\Assignment\ShinyTeeth\Pages\Messages\Receptionist.cshtml"
                              Write(message.Content);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n\t\t\t\t\t\t\t\t<span class=\"time_date\">");
#nullable restore
#line 35 "D:\SUMMER 2022\PRN221\Assignment\ShinyTeeth\Pages\Messages\Receptionist.cshtml"
                                                   Write(message.Created.ToLocalTime());

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></div>\r\n\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t</div>\r\n");
#nullable restore
#line 38 "D:\SUMMER 2022\PRN221\Assignment\ShinyTeeth\Pages\Messages\Receptionist.cshtml"
					}
					else if(message.Type == Models.ChatMessage.Types.Receiver)
					{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t<div class=\"outgoing_msg\">\r\n\t\t\t\t\t\t\t<div class=\"sent_msg\">\r\n\t\t\t\t\t\t\t<p>");
#nullable restore
#line 43 "D:\SUMMER 2022\PRN221\Assignment\ShinyTeeth\Pages\Messages\Receptionist.cshtml"
                          Write(message.Content);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n\t\t\t\t\t\t\t<span class=\"time_date\">");
#nullable restore
#line 44 "D:\SUMMER 2022\PRN221\Assignment\ShinyTeeth\Pages\Messages\Receptionist.cshtml"
                                               Write(message.Created.ToLocalTime());

#line default
#line hidden
#nullable disable
            WriteLiteral("</span> </div>\r\n\t\t\t\t\t\t</div>\r\n");
#nullable restore
#line 46 "D:\SUMMER 2022\PRN221\Assignment\ShinyTeeth\Pages\Messages\Receptionist.cshtml"
					}
				}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\t  </div>\r\n");
#nullable restore
#line 51 "D:\SUMMER 2022\PRN221\Assignment\ShinyTeeth\Pages\Messages\Receptionist.cshtml"
       if(Model.validatedUserId != null) 
	  {

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t  <div class=\"type_msg\">\r\n\t\t\t");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "29e604ee6219966716952db747ed235d9e93e3119638", async() => {
                WriteLiteral("\r\n\t\t\t  <input type=\"text\" class=\"write_msg\" placeholder=\"Type a message\" />\r\n\t\t\t  <button class=\"msg_send_btn\" type=\"button\"><i class=\"fa fa-paper-plane\" aria-hidden=\"true\"></i></button>\r\n\t\t\t");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\t\t  </div>\r\n");
#nullable restore
#line 59 "D:\SUMMER 2022\PRN221\Assignment\ShinyTeeth\Pages\Messages\Receptionist.cshtml"
	  }

#line default
#line hidden
#nullable disable
            WriteLiteral("\t</div>\r\n  </div>\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
<script>

	function ChatPeople(img, username, userId) 
	{
        return `
		<a href=""/Messages/Receptionist?userId=${userId}"" class=""d-block"">
			<div class=""chat_list active_chat"">
			  <div class=""chat_people"">
				<div class=""chat_img""> <img src=""${img}"" alt=""sunil"" style=""width: 40px; height: 40px;""> </div>
				<div class=""chat_ib"">
				  <h5>${username}</h5>
				</div>
			  </div>
			</div>
		</a>
		`;
	}

	var listOfUsers = [];

	function LoadPeople() 
	{
        $.get(""/api/Chat/LoadUsers"").then(function(data) {

            $.each(data, function(index, value) {
                listOfUsers.push(value.userId);
                var html = ChatPeople(value.img, value.username, value.userId);
                $(""#inbox_chat"").append(html);
			})

        });
	}

	LoadPeople();

	chatConnection.on(""newUserComming"", function(user) {
        console.log(user);
        if (!listOfUsers.includes(user.userId)) {
			var html = ChatPeople(user.img, user.username, user.userId)");
                WriteLiteral(@";
            $(""#inbox_chat"").prepend(html);
		}
	});

	function scrollToEnd() 
	{
		let box = document.getElementById(""msg_history"");
		box.scrollTop = box.scrollHeight;
	}

	var InComingMessage = (img, content, time) =>
	{
        return `
			<div class=""incoming_msg"">
				<div class=""incoming_msg_img""> <img src=""${img}"" alt=""sunil""> </div>
				<div class=""received_msg"">
				<div class=""received_withd_msg"">
					<p>${content}</p>
					<span class=""time_date"">${time}</span></div>
				</div>
			</div>
		`;
	}

	var OutGoingMessage = (content, time) => 
	{
        return `
			<div class=""outgoing_msg"">
				<div class=""sent_msg"">
				<p>${content}</p>
				<span class=""time_date"">${time}</span> </div>
			</div>
		`;
	}

	function SendMessage(content) 
	{
        fetch("""", {
			method: ""POST"",
            headers: { 
				""Content-Type"": ""application/json"",
				""RequestVerificationToken"": $('input:hidden[name=""__RequestVerificationToken""]').val(),
			},
            body");
                WriteLiteral(": JSON.stringify(content),\r\n\t\t});\r\n\t}\r\n\r\n\tchatConnection.on(\"administratorListenMessages-");
#nullable restore
#line 152 "D:\SUMMER 2022\PRN221\Assignment\ShinyTeeth\Pages\Messages\Receptionist.cshtml"
                                              Write(Model.validatedUserId);

#line default
#line hidden
#nullable disable
                WriteLiteral(@""", function(message) 
	{
        console.log(message);
        if (message.type == 1) {

            let html = OutGoingMessage(message.content, message.time);
            console.log(html);
            $(""#msg_history"").append(html);
        }
        else if (message.type == 0) {
			$(""#msg_history"").append(InComingMessage(message.img, message.content, message.time));
		}

        scrollToEnd();
	});

	$(""#chat-form"").submit(function(e) {
		e.preventDefault();

		let content = $("".write_msg"").val();
		if (content.trim()) {
			SendMessage(content);
		}

        $("".write_msg"").val("""");
	});

	scrollToEnd();

</script>
");
            }
            );
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ShinyTeeth.Pages.Messages.ReceptionistModel> Html { get; private set; } = default!;
        #nullable disable
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ShinyTeeth.Pages.Messages.ReceptionistModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ShinyTeeth.Pages.Messages.ReceptionistModel>)PageContext?.ViewData;
        public ShinyTeeth.Pages.Messages.ReceptionistModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591