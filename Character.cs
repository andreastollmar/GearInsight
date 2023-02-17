using ArgentPonyWarcraftClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testWoW.Interface;

namespace testWoW
{
    public class Character
    {
        public string CharacterName { get; set; }
        public string Realm { get; set; }
        public Guid Id { get; set; }
        public string PlayedClass { get; set; }
        public string ActiveSpec { get; set; }


        public Head Head { get; set; } = new Head();
        public Neck Neck { get; set; } = new Neck();
        public Shoulder Shoulder { get; set; } = new Shoulder();
        public Chest Chest { get; set; } = new Chest();
        public Waist Waist { get; set; } = new Waist();
        public Legs Legs { get; set; } = new Legs();
        public Feet Feet { get; set; } = new Feet();
        public Wrist Wrist { get; set; } = new Wrist();
        public Hands Hands { get; set; } = new Hands();
        public Ring1 Ring1 { get; set; } = new Ring1();
        public Ring2 Ring2 { get; set; } = new Ring2();
        public Trinket1 Trinket1 { get; set; } = new Trinket1();
        public Trinket2 Trinket2 { get; set; } = new Trinket2();
        public Back Back { get; set; } = new Back();
        public Mainhand Mainhand { get; set; } = new Mainhand();
        public Offhand Offhand { get; set; } = new Offhand();
        public Tabard Tabard { get; set; } = new Tabard();
        public Shirt Shirt { get; set; } = new Shirt();
        public Stats Stats { get; set; } = new Stats();


        public Character(string characterName, string realm)
        {
            CharacterName = characterName;
            Realm = realm;
            Id = new Guid();

        }

        public static async Task<Character> FetchCharacterAsync(string character, string realm)
        {

            string token = "EUOWo6xxfXnrvChuWcbTLz7u8OzdYbO7gN";
            string clientId = "c2409be1a9e2473890d079632a06a265";
            string clientSecret = "XDO1WbK2BJ36OfLyo90nYVnUyGj5yHNd";



            var warcraftClient = new WarcraftClient(clientId, clientSecret, Region.Europe, Locale.en_GB);
            RequestResult<CharacterEquipmentSummary> armor = await warcraftClient.GetCharacterEquipmentSummaryAsync(realm, character, "profile-eu");
            Character c = new Character(character, realm);
            RequestResult<CharacterStatisticsSummary> stats = await warcraftClient.GetCharacterStatisticsSummaryAsync(realm, character, "profile-eu");
            RequestResult<CharacterProfileSummary> profile = await warcraftClient.GetCharacterProfileSummaryAsync(realm, character, "profile-eu");

            
            c.ActiveSpec = profile.Value.ActiveSpec.Name;
            c.PlayedClass = profile.Value.CharacterClass.Name;
            Console.WriteLine(c.PlayedClass + " " + c.ActiveSpec);
            if (c.PlayedClass == "Warrior" || c.PlayedClass == "Death Knight" || c.ActiveSpec == "Retribution" || c.ActiveSpec == "Protection")
            {
                c.Stats.Strength = stats.Value.Strength.ToString();
                c.Stats.MeleeHaste = stats.Value.MeleeHaste.ToString();
                c.Stats.MeleeCrit = stats.Value.MeleeCrit.ToString();

            }
            else if (c.PlayedClass == "Rogue" || c.PlayedClass == "Demon Hunter" || (c.PlayedClass == "Hunter" && c.ActiveSpec == "Survival") || c.ActiveSpec == "Windwalker" || c.ActiveSpec == "Brewmaster" || c.ActiveSpec == "Enhancement" || c.ActiveSpec == "Feral" || c.ActiveSpec == "Guardian")
            {
                c.Stats.Agility = stats.Value.Agility.ToString();
                c.Stats.MeleeHaste = stats.Value.MeleeHaste.ToString();
                c.Stats.MeleeCrit = stats.Value.MeleeCrit.ToString();
            }
            else if (c.PlayedClass == "Hunter")
            {
                c.Stats.Agility = stats.Value.Agility.ToString();
                c.Stats.RangeHaste = stats.Value.RangedHaste.ToString();
                c.Stats.RangeCrit = stats.Value.RangedCrit.ToString();
            }
            else if (c.PlayedClass == "Mage" || c.PlayedClass == "Warlock" || c.PlayedClass == "Priest" || c.PlayedClass == "Evoker" || c.ActiveSpec == "Mistweaver" || c.PlayedClass == "Shaman" || c.ActiveSpec == "Balance" || c.ActiveSpec == "Restoration" || c.ActiveSpec == "Holy")
            {

                c.Stats.Intellect = stats.Value.Intellect.ToString();
                c.Stats.SpellHaste = stats.Value.SpellHaste.ToString();
                c.Stats.SpellCrit = stats.Value.SpellCrit.ToString();
            }
                 
            c.Stats.Mastery = stats.Value.Mastery.ToString();
            c.Stats.Versatility = stats.Value.Versatility.ToString();
            c.Stats.Leech = stats.Value.Lifesteal.ToString();    
            c.Stats.Speed = stats.Value.Speed.ToString();
            c.Stats.Avoidance = stats.Value.Avoidance.ToString();
            c.Stats.Health = stats.Value.Health.ToString();
            


            if (armor.Success)
            {
                CharacterEquipmentSummary a = armor.Value;


                for (int i = 0; i < a.EquippedItems.Length; i++)
                {
                    if (a.EquippedItems[i].Slot.Name == "Head")
                    {
                        c.Head.wowheadId = a.EquippedItems[i].Media.Id;
                        

                        RequestResult<ItemMedia> headMedia = await warcraftClient.GetItemMediaAsync(c.Head.wowheadId, "static-eu");
                        ItemMedia headIcon = headMedia.Value;
                        foreach (var headUri in headIcon.Assets)
                        {

                            c.Head.Icon = headUri.Value.AbsoluteUri;
                        }
                    }
                    if (a.EquippedItems[i].Slot.Name == "Neck")
                    {
                        c.Neck.wowheadId = a.EquippedItems[i].Media.Id;

                        RequestResult<ItemMedia> neckMedia = await warcraftClient.GetItemMediaAsync(c.Neck.wowheadId, "static-eu");
                        ItemMedia neckIcon = neckMedia.Value;
                        foreach (var neckUri in neckIcon.Assets)
                        {

                            c.Neck.Icon = neckUri.Value.AbsoluteUri;
                        }
                    }
                    if (a.EquippedItems[i].Slot.Name == "Shoulders")
                    {
                        c.Shoulder.wowheadId = a.EquippedItems[i].Media.Id;

                        RequestResult<ItemMedia> shouldersMedia = await warcraftClient.GetItemMediaAsync(c.Shoulder.wowheadId, "static-eu");
                        ItemMedia shouldersIcon = shouldersMedia.Value;
                        foreach (var shouldersUri in shouldersIcon.Assets)
                        {

                            c.Shoulder.Icon = shouldersUri.Value.AbsoluteUri;
                        }
                    }

                    if (a.EquippedItems[i].Slot.Name == "Shirt")
                    {
                        c.Shirt.wowheadId = a.EquippedItems[i].Media.Id;

                        RequestResult<ItemMedia> shirtMedia = await warcraftClient.GetItemMediaAsync(c.Shirt.wowheadId, "static-eu");
                        ItemMedia shirtIcon = shirtMedia.Value;
                        foreach (var shirtUri in shirtIcon.Assets)
                        {

                            c.Shirt.Icon = shirtUri.Value.AbsoluteUri;
                        }
                    }
                    if (a.EquippedItems[i].Slot.Name == "Chest")
                    {
                        c.Chest.wowheadId = a.EquippedItems[i].Media.Id;

                        RequestResult<ItemMedia> chestMedia = await warcraftClient.GetItemMediaAsync(c.Chest.wowheadId, "static-eu");
                        ItemMedia chestIcon = chestMedia.Value;
                        foreach (var chestUri in chestIcon.Assets)
                        {

                            c.Chest.Icon = chestUri.Value.AbsoluteUri;
                        }
                    }

                    if (a.EquippedItems[i].Slot.Name == "Waist")
                    {
                        c.Waist.wowheadId = a.EquippedItems[i].Media.Id;

                        RequestResult<ItemMedia> waistMedia = await warcraftClient.GetItemMediaAsync(c.Waist.wowheadId, "static-eu");
                        ItemMedia waistIcon = waistMedia.Value;
                        foreach (var waistUri in waistIcon.Assets)
                        {

                            c.Waist.Icon = waistUri.Value.AbsoluteUri;
                        }
                    }

                    if (a.EquippedItems[i].Slot.Name == "Legs")
                    {
                        c.Legs.wowheadId = a.EquippedItems[i].Media.Id;

                        RequestResult<ItemMedia> legsMedia = await warcraftClient.GetItemMediaAsync(c.Legs.wowheadId, "static-eu");
                        ItemMedia legsIcon = legsMedia.Value;
                        foreach (var legsUri in legsIcon.Assets)
                        {

                            c.Legs.Icon = legsUri.Value.AbsoluteUri;
                        }
                    }

                    if (a.EquippedItems[i].Slot.Name == "Feet")
                    {
                        c.Feet.wowheadId = a.EquippedItems[i].Media.Id;

                        RequestResult<ItemMedia> feetMedia = await warcraftClient.GetItemMediaAsync(c.Feet.wowheadId, "static-eu");
                        ItemMedia feetIcon = feetMedia.Value;
                        foreach (var feetUri in feetIcon.Assets)
                        {

                            c.Feet.Icon = feetUri.Value.AbsoluteUri;
                        }
                    }
                    if (a.EquippedItems[i].Slot.Name == "Wrist")
                    {
                        c.Wrist.wowheadId = a.EquippedItems[i].Media.Id;

                        RequestResult<ItemMedia> wristMedia = await warcraftClient.GetItemMediaAsync(c.Wrist.wowheadId, "static-eu");
                        ItemMedia wristIcon = wristMedia.Value;
                        foreach (var wristUri in wristIcon.Assets)
                        {

                            c.Wrist.Icon = wristUri.Value.AbsoluteUri;
                        }
                    }
                    if (a.EquippedItems[i].Slot.Name == "Hands")
                    {
                        c.Hands.wowheadId = a.EquippedItems[i].Media.Id;

                        RequestResult<ItemMedia> handsMedia = await warcraftClient.GetItemMediaAsync(c.Hands.wowheadId, "static-eu");
                        ItemMedia handsIcon = handsMedia.Value;
                        foreach (var handsUri in handsIcon.Assets)
                        {

                            c.Hands.Icon = handsUri.Value.AbsoluteUri;
                        }
                    }
                    if (a.EquippedItems[i].Slot.Name == "Ring 1")
                    {
                        c.Ring1.wowheadId = a.EquippedItems[i].Media.Id;

                        RequestResult<ItemMedia> ring1Media = await warcraftClient.GetItemMediaAsync(c.Ring1.wowheadId, "static-eu");
                        ItemMedia ring1Icon = ring1Media.Value;
                        foreach (var ring1Uri in ring1Icon.Assets)
                        {

                            c.Ring1.Icon = ring1Uri.Value.AbsoluteUri;
                        }
                    }
                    if (a.EquippedItems[i].Slot.Name == "Ring 2")
                    {
                        c.Ring2.wowheadId = a.EquippedItems[i].Media.Id;

                        RequestResult<ItemMedia> ring2Media = await warcraftClient.GetItemMediaAsync(c.Ring2.wowheadId, "static-eu");
                        ItemMedia ring2Icon = ring2Media.Value;
                        foreach (var ring2Uri in ring2Icon.Assets)
                        {

                            c.Ring2.Icon = ring2Uri.Value.AbsoluteUri;
                        }
                    }
                    if (a.EquippedItems[i].Slot.Name == "Trinket 1")
                    {
                        c.Trinket1.wowheadId = a.EquippedItems[i].Media.Id;

                        RequestResult<ItemMedia> trinket1Media = await warcraftClient.GetItemMediaAsync(c.Trinket1.wowheadId, "static-eu");
                        ItemMedia trinket1Icon = trinket1Media.Value;
                        foreach (var trinket1Uri in trinket1Icon.Assets)
                        {

                            c.Trinket1.Icon = trinket1Uri.Value.AbsoluteUri;
                        }
                    }
                    if (a.EquippedItems[i].Slot.Name == "Trinket 2")
                    {
                        c.Trinket2.wowheadId = a.EquippedItems[i].Media.Id;

                        RequestResult<ItemMedia> trinket2Media = await warcraftClient.GetItemMediaAsync(c.Trinket2.wowheadId, "static-eu");
                        ItemMedia trinket2Icon = trinket2Media.Value;
                        foreach (var trinket2Uri in trinket2Icon.Assets)
                        {

                            c.Trinket2.Icon = trinket2Uri.Value.AbsoluteUri;
                        }
                    }
                    if (a.EquippedItems[i].Slot.Name == "Back")
                    {
                        c.Back.wowheadId = a.EquippedItems[i].Media.Id;

                        RequestResult<ItemMedia> backMedia = await warcraftClient.GetItemMediaAsync(c.Back.wowheadId, "static-eu");
                        ItemMedia backIcon = backMedia.Value;
                        foreach (var backUri in backIcon.Assets)
                        {

                            c.Back.Icon = backUri.Value.AbsoluteUri;
                        }
                    }
                    if (a.EquippedItems[i].Slot.Name == "Main Hand")
                    {
                        c.Mainhand.wowheadId = a.EquippedItems[i].Media.Id;

                        RequestResult<ItemMedia> mainhandMedia = await warcraftClient.GetItemMediaAsync(c.Mainhand.wowheadId, "static-eu");
                        ItemMedia mainhandIcon = mainhandMedia.Value;
                        foreach (var mainhandUri in mainhandIcon.Assets)
                        {

                            c.Mainhand.Icon = mainhandUri.Value.AbsoluteUri;
                        }
                    }
                    if (a.EquippedItems[i].Slot.Name == "Off Hand")
                    {
                        c.Offhand.wowheadId = a.EquippedItems[i].Media.Id;

                        RequestResult<ItemMedia> offhandMedia = await warcraftClient.GetItemMediaAsync(c.Offhand.wowheadId, "static-eu");
                        ItemMedia offhandIcon = offhandMedia.Value;
                        foreach (var offhandUri in offhandIcon.Assets)
                        {
                            c.Offhand.Icon = offhandUri.Value.AbsoluteUri;
                        }

                    }
                    if (a.EquippedItems[i].Slot.Name == "Tabard")
                    {
                        c.Tabard.wowheadId = a.EquippedItems[i].Media.Id;

                        RequestResult<ItemMedia> tabardMedia = await warcraftClient.GetItemMediaAsync(c.Tabard.wowheadId, "static-eu");
                        ItemMedia tabardIcon = tabardMedia.Value;
                        foreach (var tabardUri in tabardIcon.Assets)
                        {
                            c.Tabard.Icon = tabardUri.Value.AbsoluteUri;
                        }
                    }
                }
            }
            return c;
        }
    }
}



