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

            var characterName = await character1;
            Console.WriteLine("\nName: " + character1.Result.CharacterName + "\nRealm: " + character1.Result.Realm);
            Console.WriteLine("Spec: " + character1.Result.ActiveSpec + " Class: " + character1.Result.PlayedClass + " Haste: " + character1.Result.Stats.SpellHaste + " Crit:" + character1.Result.Stats.SpellCrit);
            //Console.WriteLine(character1.Result.Head.wowheadId + " " + character1.Result.Head.Icon);
            Task<List<OurItem>> list = Mongo.ItemList(await character1);
            foreach (OurItem item in await list)
            {
                Console.WriteLine(item.wowheadId + " - " + item.Icon);
            }

        }
    }
}