using Bannerlord.UIExtenderEx.Attributes;
using Bannerlord.UIExtenderEx.Prefabs2;

namespace PowerDisplay.UIExtenderEx
{
    [PrefabExtension(
        movie: "PartyNameplateItem",
        xpath: "descendant::PartyNameplateWidget/Children/ListPanel[@Id='NameplateLayoutListPanel']/Children/ListPanel[@Id='LabelsList']/Children/TextWidget[@Id='NameplateExtraInfoTextWidget']")]
    internal class PartyNameplateExtraInfoPatch : PrefabExtensionInsertPatch
    {
        public override InsertType Type => InsertType.Replace;

        [PrefabExtensionText]
        public string GetReplacementPatch => $"<TextWidget Id=\"NameplateExtraInfoTextWidget\" DoNotAcceptEvents=\"true\" WidthSizePolicy=\"CoverChildren\" HeightSizePolicy=\"CoverChildren\" HorizontalAlignment=\"Center\" VerticalAlignment=\"Bottom\" Brush.FontColor=\"@FactionColor\" Brush.FontSize=\"28\" ClipContents=\"false\" Text=\"@PowerDisplayExtraInfo\" />";
    }
}
