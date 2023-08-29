using System.Linq;
using HarmonyLib;
using SandBox.ViewModelCollection.Nameplate;
using TaleWorlds.CampaignSystem.Party;

namespace PowerDisplay
{
    [HarmonyPatch(typeof(PartyNameplateVM), "ExtraInfoText", MethodType.Getter)]
    public class HarmonyExtraInfoText
    {
        public static void Postfix(PartyNameplateVM __instance, ref string __result)
        {
            if (!string.IsNullOrEmpty(__result) && !__result.Contains('['))
            {
                MobileParty party = __instance.Party;
                string modified = $" [{(int)party.GetTotalStrengthWithFollowers(true)}] " + __result;
                __result = modified;
            }
        }
    }
}