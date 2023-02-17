using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Text.Json.Serialization;
using ArgentPonyWarcraftClient;
using testWoW.Interface;
using testWoW.Database;
using System.Text;

namespace testWoW
{
    public class Program
    {
        public static string _token { get; set; } = "EUOWo6xxfXnrvChuWcbTLz7u8OzdYbO7gN";
        public static string clientId = "c2409be1a9e2473890d079632a06a265";
        public static string clientSecret = "XDO1WbK2BJ36OfLyo90nYVnUyGj5yHNd";
        static async Task Main(string[] args)
        {
            string realm = Helpers.GetInputFromUser("Enter Realm: ");
            string character = Helpers.GetInputFromUser("Enter character Name: ");

            Task<Character> character1 = Mongo.CreateCharacter(character, realm);

            //Task<Character> character1 = Character.FetchCharacterAsync(character, realm);
            Console.ReadKey();
            Console.WriteLine(await character1);
            Console.WriteLine("Name: " + character1.Result.CharacterName + "\nRealm: " + character1.Result.Realm);
            Console.WriteLine(character1.Result.Head.wowheadId + " " + character1.Result.Head.Icon);


            //foreach (OurItem d in character1.Result)
            //{
            //    Console.WriteLine($"{d.wowheadId}\n\n{d.Icon}");
            //}


            //var warcraftClient = new WarcraftClient(clientId, clientSecret, Region.Europe, Locale.en_GB);
            //RequestResult<CharacterEquipmentSummary> armor = await warcraftClient.GetCharacterEquipmentSummaryAsync(realm, character, "profile-eu");
            //Character c = new Character(character, realm);

            //if (armor.Success)
            //{
            //    c.equipment = new List<IEquipment>();
            //    CharacterEquipmentSummary a = armor.Value;


            //    for (int i = 0; i < a.EquippedItems.Length; i++)
            //    {
            //        if (i == 0) //head
            //        {
            //            c.Head.wowheadId = a.EquippedItems[i].Media.Id;

            //            RequestResult<ItemMedia> headMedia = await warcraftClient.GetItemMediaAsync(c.Head.wowheadId, "static-eu");
            //            ItemMedia headIcon = headMedia.Value;
            //            foreach (var headUri in headIcon.Assets)
            //            {

            //                c.Head.Icon = headUri.Value.AbsoluteUri;
            //            }
            //            c.equipment.Add(c.Head);
            //        }
            //        if (i == 1) //neck
            //        {
            //            c.Neck.wowheadId = a.EquippedItems[i].Media.Id;

            //            RequestResult<ItemMedia> neckMedia = await warcraftClient.GetItemMediaAsync(c.Neck.wowheadId, "static-eu");
            //            ItemMedia neckIcon = neckMedia.Value;
            //            foreach (var neckUri in neckIcon.Assets)
            //            {

            //                c.Neck.Icon = neckUri.Value.AbsoluteUri;
            //            }
            //            c.equipment.Add(c.Neck);
            //        }
            //        if (i == 2) //shoulder
            //        {
            //            c.Shoulder.wowheadId = a.EquippedItems[i].Media.Id;

            //            RequestResult<ItemMedia> shouldersMedia = await warcraftClient.GetItemMediaAsync(c.Shoulder.wowheadId, "static-eu");
            //            ItemMedia shouldersIcon = shouldersMedia.Value;
            //            foreach (var shouldersUri in shouldersIcon.Assets)
            //            {

            //                c.Shoulder.Icon = shouldersUri.Value.AbsoluteUri;
            //            }
            //            c.equipment.Add(c.Shoulder);
            //        }

            //        if (i == 3) // chest
            //        {
            //            c.Chest.wowheadId = a.EquippedItems[i].Media.Id;

            //            RequestResult<ItemMedia> chestMedia = await warcraftClient.GetItemMediaAsync(c.Chest.wowheadId, "static-eu");
            //            ItemMedia chestIcon = chestMedia.Value;
            //            foreach (var chestUri in chestIcon.Assets)
            //            {

            //                c.Chest.Icon = chestUri.Value.AbsoluteUri;
            //            }
            //            c.equipment.Add(c.Chest);
            //        }

            //        if (i == 4) //waist
            //        {
            //            c.Waist.wowheadId = a.EquippedItems[i].Media.Id;

            //            RequestResult<ItemMedia> waistMedia = await warcraftClient.GetItemMediaAsync(c.Waist.wowheadId, "static-eu");
            //            ItemMedia waistIcon = waistMedia.Value;
            //            foreach (var waistUri in waistIcon.Assets)
            //            {

            //                c.Waist.Icon = waistUri.Value.AbsoluteUri;
            //            }
            //            c.equipment.Add(c.Waist);
            //        }

            //        if (i == 5) //legs
            //        {
            //            c.Legs.wowheadId = a.EquippedItems[i].Media.Id;

            //            RequestResult<ItemMedia> legsMedia = await warcraftClient.GetItemMediaAsync(c.Legs.wowheadId, "static-eu");
            //            ItemMedia legsIcon = legsMedia.Value;
            //            foreach (var legsUri in legsIcon.Assets)
            //            {

            //                c.Legs.Icon = legsUri.Value.AbsoluteUri;
            //            }
            //            c.equipment.Add(c.Legs);
            //        }

            //        if (i == 6) //feet
            //        {
            //            c.Feet.wowheadId = a.EquippedItems[i].Media.Id;

            //            RequestResult<ItemMedia> feetMedia = await warcraftClient.GetItemMediaAsync(c.Feet.wowheadId, "static-eu");
            //            ItemMedia feetIcon = feetMedia.Value;
            //            foreach (var feetUri in feetIcon.Assets)
            //            {

            //                c.Feet.Icon = feetUri.Value.AbsoluteUri;
            //            }
            //            c.equipment.Add(c.Feet);
            //        }
            //        if (i == 7) //wrist
            //        {
            //            c.Wrist.wowheadId = a.EquippedItems[i].Media.Id;

            //            RequestResult<ItemMedia> wristMedia = await warcraftClient.GetItemMediaAsync(c.Wrist.wowheadId, "static-eu");
            //            ItemMedia wristIcon = wristMedia.Value;
            //            foreach (var wristUri in wristIcon.Assets)
            //            {

            //                c.Wrist.Icon = wristUri.Value.AbsoluteUri;
            //            }
            //            c.equipment.Add(c.Wrist);
            //        }
            //        if (i == 8) //gloves
            //        {
            //            c.Gloves.wowheadId = a.EquippedItems[i].Media.Id;

            //            RequestResult<ItemMedia> glovesMedia = await warcraftClient.GetItemMediaAsync(c.Gloves.wowheadId, "static-eu");
            //            ItemMedia glovesIcon = glovesMedia.Value;
            //            foreach (var glovesUri in glovesIcon.Assets)
            //            {

            //                c.Gloves.Icon = glovesUri.Value.AbsoluteUri;
            //            }
            //            c.equipment.Add(c.Gloves);
            //        }
            //        if (i == 9) //ring 1
            //        {
            //            c.Ring1.wowheadId = a.EquippedItems[i].Media.Id;

            //            RequestResult<ItemMedia> ring1Media = await warcraftClient.GetItemMediaAsync(c.Ring1.wowheadId, "static-eu");
            //            ItemMedia ring1Icon = ring1Media.Value;
            //            foreach (var ring1Uri in ring1Icon.Assets)
            //            {

            //                c.Ring1.Icon = ring1Uri.Value.AbsoluteUri;
            //            }
            //            c.equipment.Add(c.Ring1);
            //        }
            //        if (i == 10) //ring 2
            //        {
            //            c.Ring2.wowheadId = a.EquippedItems[i].Media.Id;

            //            RequestResult<ItemMedia> ring2Media = await warcraftClient.GetItemMediaAsync(c.Ring2.wowheadId, "static-eu");
            //            ItemMedia ring2Icon = ring2Media.Value;
            //            foreach (var ring2Uri in ring2Icon.Assets)
            //            {

            //                c.Ring2.Icon = ring2Uri.Value.AbsoluteUri;
            //            }
            //            c.equipment.Add(c.Ring2);
            //        }
            //        if (i == 11) //trinket 1
            //        {
            //            c.Trinket1.wowheadId = a.EquippedItems[i].Media.Id;

            //            RequestResult<ItemMedia> trinket1Media = await warcraftClient.GetItemMediaAsync(c.Trinket1.wowheadId, "static-eu");
            //            ItemMedia trinket1Icon = trinket1Media.Value;
            //            foreach (var trinket1Uri in trinket1Icon.Assets)
            //            {

            //                c.Trinket1.Icon = trinket1Uri.Value.AbsoluteUri;
            //            }
            //            c.equipment.Add(c.Trinket1);
            //        }
            //        if (i == 12) //trinket 2
            //        {
            //            c.Trinket2.wowheadId = a.EquippedItems[i].Media.Id;

            //            RequestResult<ItemMedia> trinket2Media = await warcraftClient.GetItemMediaAsync(c.Trinket2.wowheadId, "static-eu");
            //            ItemMedia trinket2Icon = trinket2Media.Value;
            //            foreach (var trinket2Uri in trinket2Icon.Assets)
            //            {

            //                c.Trinket2.Icon = trinket2Uri.Value.AbsoluteUri;
            //            }
            //            c.equipment.Add(c.Trinket2);
            //        }
            //        if (i == 13) //cloak
            //        {
            //            c.Cloak.wowheadId = a.EquippedItems[i].Media.Id;

            //            RequestResult<ItemMedia> cloakMedia = await warcraftClient.GetItemMediaAsync(c.Cloak.wowheadId, "static-eu");
            //            ItemMedia cloakIcon = cloakMedia.Value;
            //            foreach (var cloakUri in cloakIcon.Assets)
            //            {

            //                c.Cloak.Icon = cloakUri.Value.AbsoluteUri;
            //            }
            //            c.equipment.Add(c.Cloak);
            //        }
            //        if (i == 14) //2hand or mainhand
            //        {
            //            c.Mainhand.wowheadId = a.EquippedItems[i].Media.Id;

            //            RequestResult<ItemMedia> mainhandMedia = await warcraftClient.GetItemMediaAsync(c.Mainhand.wowheadId, "static-eu");
            //            ItemMedia mainhandIcon = mainhandMedia.Value;
            //            foreach (var mainhandUri in mainhandIcon.Assets)
            //            {

            //                c.Mainhand.Icon = mainhandUri.Value.AbsoluteUri;
            //            }
            //            c.equipment.Add(c.Mainhand);
            //        }
            //        if (i == 15) //offhand
            //        {
            //            c.Offhand.wowheadId = a.EquippedItems[i].Media.Id;

            //            RequestResult<ItemMedia> offhandMedia = await warcraftClient.GetItemMediaAsync(c.Offhand.wowheadId, "static-eu");
            //            ItemMedia offhandIcon = offhandMedia.Value;
            //            foreach (var offhandUri in offhandIcon.Assets)
            //            {

            //                c.Offhand.Icon = offhandUri.Value.AbsoluteUri;
            //            }
            //            c.equipment.Add(c.Offhand);
            //        }
            //        if (i == 16) //tabard
            //        {
            //            c.Tabard.wowheadId = a.EquippedItems[i].Media.Id;

            //            RequestResult<ItemMedia> tabardMedia = await warcraftClient.GetItemMediaAsync(c.Tabard.wowheadId, "static-eu");
            //            ItemMedia tabardIcon = tabardMedia.Value;
            //            foreach (var tabardUri in tabardIcon.Assets)
            //            {

            //                c.Tabard.Icon = tabardUri.Value.AbsoluteUri;
            //            }
            //            c.equipment.Add(c.Tabard);
            //        }

            //    }
            //    foreach (var d in c.equipment)
            //    {
            //        Console.WriteLine($"{d.wowheadId}\n\n{d.Icon}");
            //    }

            //}
            //string extra = head.wowheadId.ToString();
            //string url = "www.wowhead.com/item=" + extra;
            //Console.WriteLine(url);

        }
    }
}