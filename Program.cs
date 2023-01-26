using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using AspNet;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Text.Json.Serialization;
using ArgentPonyWarcraftClient;

namespace testWoW
{
    internal class Program
    {
        public static string _token { get; set; } = "EUOWo6xxfXnrvChuWcbTLz7u8OzdYbO7gN";
        public static string clientId = "c2409be1a9e2473890d079632a06a265";
        public static string clientSecret = "XDO1WbK2BJ36OfLyo90nYVnUyGj5yHNd";
        static async Task Main(string[] args)
        {

                       
            var warcraftClient = new WarcraftClient(clientId, clientSecret, Region.Europe, Locale.en_GB);

            string realm = Helpers.GetInputFromUser("Enter Realm: ");
            string character = Helpers.GetInputFromUser("Enter character Name: ");

            //RequestResult<CharacterProfileSummary> result = await warcraftClient.GetCharacterProfileSummaryAsync(realm, character, "profile-eu");
            //RequestResult<CharacterEquipmentSummary> armor = await warcraftClient.GetCharacterEquipmentSummaryAsync(realm, character, "profile-eu");
            RequestResult<ItemMedia> media = await warcraftClient.GetItemMediaAsync(200337, "static-eu");
            //if(result.Success)
            //{
            //    CharacterProfileSummary profile = result.Value;
            //    Console.WriteLine($"Level for {profile.Name}: {profile.Level} : {profile.Equipment}");
            //}
            //double avgIlvl = 0;
            //if(armor.Success)
            //{
            //    CharacterEquipmentSummary a = armor.Value;
            //    Console.WriteLine(a.Character.Name + " name" + a.EquippedItems + " items ");
            //    foreach(var item in a.EquippedItems)
            //    {
            //        Console.WriteLine(item.Name + " " + item.Description + " " + item.InventoryType.Name + " " + item.Quality.Name + item.Media.Key+" " + item.Item.Id + " level " + item.Level.Value );
            //        avgIlvl += item.Level.Value;
            //    }
            //    avgIlvl = avgIlvl - 40;
            //    Console.WriteLine("Avg ilvl = " + (avgIlvl/13));
            //}
            if(media.Success)
            {
                ItemMedia media1 = media.Value;
                Console.WriteLine(media1.Links + "" + media1.Assets);
                foreach(var d in media1.Assets)
                {
                    Console.WriteLine(d.FileDataId + " "+ d.Key + " " + d.Value.AbsolutePath + " " + d.Value.AbsoluteUri); //absolut uri ger länk till jpg bild
                }

            }

        }
        
       
    }
}