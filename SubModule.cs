using System;
using System.Collections.Generic;
using System.IO;
using System.UIExtenderEx;
using System.Xml.Serialization;
using Bannerlord.UIExtenderEx;
using PowerDisplay.UIExtenderEx;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace PowerDisplay
{
    public class SubModule : MBSubModuleBase
    {
        private readonly string ConfigFile = Path.Combine(BasePath.Name, "Modules", "PowerDisplay", "Config.xml");

        protected override void OnSubModuleLoad()
        {
            UIExtender uiExtender = new UIExtender("PowerDisplay");
            List<Type> uiExtenderTypes = new List<Type>() { typeof(PartyNameplateMixin)};

            if (!File.Exists(ConfigFile))
                CreateXML();

            Config config = ReadXML(ConfigFile);
            if (config.DisplayOnInspect)
                uiExtenderTypes.Add(typeof(PartyNameplateExtraInfoPatch));
            else
                uiExtenderTypes.Add(typeof(PartyNameplateCountPatch));

            uiExtender.Register(uiExtenderTypes);
            uiExtender.Enable();
        }

        private Config ReadXML(string xml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Config));
            using FileStream fs = new FileStream(xml, FileMode.Open);
            return (Config)serializer.Deserialize(fs);
        }

        private void CreateXML()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Config));
            serializer.Serialize(File.Create(ConfigFile), new Config() { DisplayOnInspect = false });
        }
    }
}