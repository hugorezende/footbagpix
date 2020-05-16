using FootbagPix.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace FootbagPix.Repository
{
    public class GameModelRepository : IRepository<GameModel>
    {
        private readonly List<GameModel> savedGames;
        internal string FileName { get; private set; }
        private readonly List<Type> types;

        public GameModelRepository(string filename)
        {
            FileName = filename;
            types = new List<Type>{ typeof(CharacterModel), typeof(BallModel), typeof(TimerModel), typeof(ScoreModel), typeof(Guid), typeof(MatrixTransform), typeof(SolidColorBrush)};
            savedGames = new List<GameModel>();

            if (File.Exists(FileName))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<GameModel>), null,
                types.ToArray(),
                new XmlRootAttribute("SavedGames"), "FootbagPix");
                using (StreamReader reader = new StreamReader(FileName))
                {
                    savedGames = (List<GameModel>)serializer.Deserialize(reader);
                    reader.Close();
                }
            }
            else
            {
                XDocument newFile = new XDocument();
                newFile.Add(new XElement("SavedGames"));
                newFile.Save(FileName);
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
            entity.SavedAt = DateTime.Now;
        }

        public void Remove(GameModel entity)
        {
            savedGames.Remove(entity);
        }
 
        public void SaveChanges()
        {
            XmlSerializer serializer = new XmlSerializer(savedGames.GetType(), null,
                types.ToArray(),
                new XmlRootAttribute("SavedGames"), "FootbagPix");
                using (StreamWriter writer = new StreamWriter(FileName))
                {
                    serializer.Serialize(writer, savedGames);
                    writer.Close();
                }           
        }

        public List<string> ReadSavedGames()
        {
            List<string> formattedSavedGames = new List<string>();
            for (int i = 0; i < savedGames.Count; i++)
            {
                formattedSavedGames.Add(savedGames[i].ToString());
            }
            return formattedSavedGames;
        }
    }
}
