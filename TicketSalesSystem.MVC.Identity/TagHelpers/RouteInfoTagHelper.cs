using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TicketSalesSystem.MVC.Identity.TagHelpers
{
	[HtmlTargetElement("route-info")]
	public class RouteInfoTagHelper : TagHelper
	{
		public string DeparturePoint { get; set; }
		public string ArrivalPoint { get; set; }

		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			output.TagName = "div";
			output.Content.SetHtmlContent($@"
			<div class=""col-md-4"">
			   <div class=""card mb-4"">
                <h3 class=""card-text"">Откуда: {DeparturePoint}</h3>
                <h3 class=""card-text"">Куда: {ArrivalPoint}</h3>
			   </div>
		    </div>");
		}
	}
}
