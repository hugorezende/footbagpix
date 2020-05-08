using FootbagPix.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Xml.Serialization;

namespace FootbagPix.Repository
{
    public class GameModelRepository : IRepository<GameModel>
    {
        private readonly List<GameModel> savedGames;
        internal string FileName { get; private set; }

        public GameModelRepository(string filename)
        {
            FileName = filename;

            XmlSerializer serializer = new XmlSerializer(typeof(List<GameModel>), null,
                new Type[] { typeof(CharacterModel), typeof(BallModel), typeof(TimerModel), typeof(ScoreModel), typeof(ImageBrush) },
                new XmlRootAttribute("SavedGames"), "FootbagPix");
            using (StreamReader reader = new StreamReader(FileName))
            {
                savedGames = (List<GameModel>)serializer.Deserialize(reader);
                reader.Close();
            }
        }

        public GameModel GetById(Guid gameID)
        {
            return (from game in savedGames where game.GameID == gameID select game).Single();
        }

        public IEnumerable<GameModel> GetAll()
        {
            return savedGames;
        }

        public void Add(GameModel entity)
        {
            savedGames.Add(entity);
        }

        public void Remove(GameModel entity)
        {
            savedGames.Remove(entity);
        }
 
        public void SaveChanges()
        {
            XmlSerializer serializer = new XmlSerializer(savedGames.GetType(), null,
                new Type[] { typeof(CharacterModel), typeof(BallModel), typeof(TimerModel), typeof(ScoreModel), typeof(ImageBrush) },
                new XmlRootAttribute("SavedGames"), "FootbagPix");
            using (StreamWriter writer = new StreamWriter(FileName))
            {
                serializer.Serialize(writer, savedGames);
                writer.Close();
            }
        }
    }
}
