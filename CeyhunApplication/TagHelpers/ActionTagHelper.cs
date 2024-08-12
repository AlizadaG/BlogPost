using Microsoft.AspNetCore.Razor.TagHelpers;

namespace CeyhunApplication.TagHelpers;


[HtmlTargetElement("button", Attributes = "btn-action")]
public class ActionTagHelper : TagHelper
{
    public string? BtnAction { get; set; }
    override public void Process(TagHelperContext context, TagHelperOutput output)
    {
        #region old
        //string btn = this.BtnAction switch
        //{
        //    "delete" => "danger",   // trash
        //    "edit" => "warning",    // pencil
        //    "create" => "dark",     // save - plus
        //    _ => "primary"
        //};

        //string icon = this.BtnAction switch
        //{
        //    "delete" => "trash",   // trash
        //    "edit" => "pen",    // pencil
        //    "create" => "save",     // save - plus
        //    _ => "plus"
        //}; 
        #endregion

        (string color, string icon) btn = this.BtnAction switch
        {
            "delete" => (color: "danger", icon: "trash"),
            "edit" => (color: "warning", icon: "pen"),
            "create" => (color: "dark", icon: "save"),
            "list" => (color: "info", icon: "list"),
            _ => (color: "primary", icon: "plus"),
        };


        output.TagName = "button";
        output.Attributes.SetAttribute("class", $"btn btn-outline-{btn.color}");
        output.Attributes.SetAttribute("type", "submit");
        output.Content.SetHtmlContent($" <i class='fas fa-{btn.icon}'></i> &nbsp;{System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(this.BtnAction)}");
    }
}


[HtmlTargetElement("td", Attributes = "td-select")]
public class DropDownActionTagHelper : TagHelper
{

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.Content.SetHtmlContent(@"
            <div class=""dropdown"">
              <button class=""btn btn-light btn-sm dropdown-toggle"" type=""button"" id=""dropdownMenuButton1"" data-bs-toggle=""dropdown"" aria-expanded=""false"">
               <i class='fas fa-plus'> </i>
              </button>
              <ul class=""dropdown-menu"" aria-labelledby=""dropdownMenuButton1"">
                <li><a class=""dropdown-item"" href=""#"">Action</a></li>
                <li><a class=""dropdown-item"" href=""#"">Another action</a></li>
                <li><a class=""dropdown-item"" href=""#"">Something else here</a></li>
              </ul>
            </div> 
");
    }

}
/*
        <button btn-type="delete"></button>
        <button btn-type="save"></button>
        <button btn-type="edit"></button>

        <action btn-action="delete"> </action>
        <action btn-action="edit"> </action>
        <action btn-action="create"> </action>
 */