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

        private static async Task<bool> CheckIfCharacterExist(string name, string realm, IMongoCollection<Character> allCharacters)
        {
            bool characterFound = false;
                        
            var allCharacters1 = allCharacters.AsQueryable().ToList();  // döpa om saker

            foreach (Character c in allCharacters1)
            {
                if (c.CharacterName == name.ToLower() && c.Realm == realm.ToLower())
                {
                    characterFound = true;
                    break;
                }
            }
            return characterFound;
        }

        public static async Task<Character> CreateCharacter(string name, string realm)
        {
            IMongoCollection<Character> fetchCharacterList = await FetchDatabase();
            var checkIfCharacterExist = CheckIfCharacterExist(name, realm, fetchCharacterList);
            Character character = null;
            if (await checkIfCharacterExist == true)
            {
                character = JsonSerializer.Deserialize<Character>(fetchCharacterList.AsQueryable().Where(x => x.CharacterName == name && x.Realm == realm).SingleOrDefault().ToString());
            }
            else
            {
                character = await Character.FetchCharacterAsync(name, realm);
                //string insertMsg = JsonSerializer.Serialize(character).ToString();                
                await fetchCharacterList.InsertOneAsync(character);
            }
            return character;
        }
    }
}
