using Bannerlord.UIExtenderEx.Attributes;
using Bannerlord.UIExtenderEx.Prefabs2;

namespace PowerDisplay.UIExtenderEx
{
    [PrefabExtension(
        movie: "PartyNameplateItem",
        xpath: "descendant::PartyNameplateWidget/Children/ListPanel[@Id='NameplateLayoutListPanel']/Children/ListPanel[@Id='LabelsList']/Children/TextWidget[@Id='NameplateTextWidget']")]
    internal class PartyNameplateCountPatch : PrefabExtensionInsertPatch
    {
        public override InsertType Type => InsertType.Replace;

        [PrefabExtensionText]
        public string GetReplacementPatch => $"<TextWidget Id=\"NameplateTextWidget\" DoNotAcceptEvents=\"true\" WidthSizePolicy=\"CoverChildren\" HeightSizePolicy=\"CoverChildren\" HorizontalAlignment=\"Center\" VerticalAlignment=\"Center\" MarginLeft=\"10\" Brush.FontColor=\"@FactionColor\" Brush.FontSize=\"35\" ClipContents=\"false\" Text=\"@PowerDisplay\" />";
    }
}
