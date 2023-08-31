using Bannerlord.UIExtenderEx.Attributes;
using Bannerlord.UIExtenderEx.ViewModels;
using SandBox.ViewModelCollection.Nameplate;
using System;
using System.Collections.Generic;
using TaleWorlds.Library;

namespace System.UIExtenderEx
{
    [ViewModelMixin]
    internal class PartyNameplateMixin : BaseViewModelMixin<PartyNameplateVM>
    {
        [DataSourceProperty]
        public string PowerDisplay { get; set; }

        [DataSourceProperty]
        public string PowerDisplayExtraInfo { get; set; }

        public PartyNameplateMixin(PartyNameplateVM vm) : base(vm)
        {
            var count = vm.Party.MemberRoster.Count;
            var strength = vm.Party.Party.MobileParty.GetTotalStrengthWithFollowers();
            PowerDisplay = $"{count} [{strength}]";
            PowerDisplayExtraInfo = $"[{strength}] {vm.ExtraInfoText}";
        }
    }
}
