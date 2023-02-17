using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using System.Text.Json;
using SharpCompress.Readers;
using ArgentPonyWarcraftClient;
using testWoW.Interface;
using SharpCompress.Writers;

namespace testWoW.Database
{
    internal class Mongo
    {
        private static async Task<IMongoCollection<Character>> FetchDatabase()
        {

            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://Jesper:hejjesper@cluster0.wbk5q6r.mongodb.net/?retryWrites=true&w=majority");
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings);
            var database = client.GetDatabase("GearInsight");
            var myCollection = database.GetCollection<Character>("Characters");

            return myCollection;
        }

        private static async Task<Guid> CheckIfCharacterExist(string name, string realm, IMongoCollection<Character> allCharacters)
        {
            bool characterFound = false;
            Guid guid = Guid.Empty;
            string guidToString = "";
                        
            var allCharacters1 = allCharacters.AsQueryable().ToList();  // döpa om saker

            foreach (Character c in allCharacters1)
            {
                if (c.CharacterName == name.ToLower() && c.Realm == realm.ToLower())
                {
                    characterFound = true;  
                    guidToString = c.Id.ToString();
                    guid = c.Id;
                    break;
                }
            }
            return guid;
        }

        public static async Task<Character> CreateCharacter(string name, string realm)
        {
            IMongoCollection<Character> fetchCharacterList = await FetchDatabase();
            var checkIfCharacterExist = CheckIfCharacterExist(name, realm, fetchCharacterList);
            Character character = null;
            if (await checkIfCharacterExist != Guid.Empty)
            {

                var filter = Builders<Character>.Filter.Eq(x => x.Id, await CheckIfCharacterExist(name, realm, fetchCharacterList));
                character = await fetchCharacterList.Find(filter).FirstOrDefaultAsync();
                Console.WriteLine("Character fetched from database");
            }
            else
            {
                character = await Character.FetchCharacterAsync(name, realm);                                
                await fetchCharacterList.InsertOneAsync(character);
                Console.WriteLine("Character fetched and saved");
            }
            return character;
        }
        public static async Task<List<OurItem>> PutItemsInList(Character character)
        {
            List<OurItem> items = new List<OurItem>();

            items.AddRange(character))

        }
    }
}
