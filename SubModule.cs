using System;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;
using HarmonyLib;
using SandBox.ViewModelCollection.Nameplate;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace PowerDisplay
{
    public class SubModule : MBSubModuleBase
    {
        private readonly string ConfigFile = Path.Combine(BasePath.Name, "Modules", "PowerDisplay", "Config.xml");

        protected override void OnSubModuleLoad()
        {
   
            Harmony harmony = new Harmony("PowerDisplay");
            Config config = ReadXML(ConfigFile);
            if (config.DisplayOnInspect)
            {
                MethodInfo original2 = AccessTools.PropertyGetter(typeof(PartyNameplateVM), "ExtraInfoText");
                MethodInfo postfix2 = AccessTools.Method(typeof(HarmonyExtraInfoText), "Postfix", (Type[])null, (Type[])null);
                harmony.Patch((MethodBase)original2, (HarmonyMethod)null, new HarmonyMethod(postfix2), (HarmonyMethod)null, (HarmonyMethod)null);
            }
            else
            {
                MethodInfo original = AccessTools.PropertyGetter(typeof(PartyNameplateVM), "Count");
                MethodInfo postfix = AccessTools.Method(typeof(HarmonyCount), "Postfix", (Type[])null, (Type[])null);
                harmony.Patch((MethodBase)original, (HarmonyMethod)null, new HarmonyMethod(postfix), (HarmonyMethod)null, (HarmonyMethod)null);
            }
        }

        private Config ReadXML(string xml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Config));
            using FileStream fs = new FileStream(xml, FileMode.Open);
            return (Config)serializer.Deserialize(fs);
        }
    }
}