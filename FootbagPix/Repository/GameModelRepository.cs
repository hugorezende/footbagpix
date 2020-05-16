// <copyright file="GameModelRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FootbagPix.Repository
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Windows.Media;
    using System.Xml.Linq;
    using System.Xml.Serialization;
    using FootbagPix.Models;

    public class GameModelRepository : IRepository<GameModel>
    {
        private readonly List<GameModel> savedGames;

        private readonly List<Type> types;

        public GameModelRepository(string filename)
        {
            this.FileName = filename;
            this.types = new List<Type> { typeof(CharacterModel), typeof(BallModel), typeof(TimerModel), typeof(ScoreModel), typeof(Guid), typeof(MatrixTransform), typeof(SolidColorBrush) };
            this.savedGames = new List<GameModel>();

            if (File.Exists(this.FileName))
            {
                XmlSerializer serializer = new XmlSerializer(
                    typeof(List<GameModel>),
                    null,
                    this.types.ToArray(),
                    new XmlRootAttribute("SavedGames"),
                    "FootbagPix");
                using (StreamReader reader = new StreamReader(this.FileName))
                {
                    this.savedGames = (List<GameModel>)serializer.Deserialize(reader);
                    reader.Close();
                }
            }
            else
            {
                XDocument newFile = new XDocument();
                newFile.Add(new XElement("SavedGames"));
                newFile.Save(this.FileName);
            }
        }

        internal string FileName { get; private set; }

        public GameModel GetById(Guid gameID)
        {
            return (from game in this.savedGames where game.GameID == gameID select game).Single();
        }

        public IEnumerable<GameModel> GetAll()
        {
            return this.savedGames;
        }

        public void Add(GameModel entity)
        {
            this.savedGames.Add(entity);
            entity.SavedAt = DateTime.Now;
        }

        public void Remove(GameModel entity)
        {
            this.savedGames.Remove(entity);
        }

        public void SaveChanges()
        {
            XmlSerializer serializer = new XmlSerializer(
                this.savedGames.GetType(),
                null,
                this.types.ToArray(),
                new XmlRootAttribute("SavedGames"),
                "FootbagPix");
            using (StreamWriter writer = new StreamWriter(this.FileName))
            {
                serializer.Serialize(writer, this.savedGames);
                writer.Close();
            }
        }

        public List<string> ReadSavedGames()
        {
            List<string> formattedSavedGames = new List<string>();
            for (int i = 0; i < this.savedGames.Count; i++)
            {
                formattedSavedGames.Add(this.savedGames[i].ToString());
            }

            return formattedSavedGames;
        }
    }
}
