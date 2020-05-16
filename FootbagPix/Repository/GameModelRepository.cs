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

    /// <summary>
    /// Represents a repository handling GameModel objects.
    /// </summary>
    public class GameModelRepository : IRepository<GameModel>
    {
        private readonly List<GameModel> savedGames;

        private readonly List<Type> types;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameModelRepository"/> class.
        /// If the file with the name given as parameter exsists, it reads the saved games from it.
        /// Else, it creates a file with the given name.
        /// </summary>
        /// <param name="filename">The name of the file that contains the saved GameModel objects.</param>
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

        /// <summary>
        /// Gets the name of the file containing the saved games.
        /// </summary>
        internal string FileName { get; private set; }

        /// <summary>
        /// Gets a GameModel object based on ID.
        /// </summary>
        /// <param name="gameID">The ID of the GameModel object we wish to get.</param>
        /// <returns>The GameModel object with the given ID.</returns>
        public GameModel GetById(Guid gameID)
        {
            return (from game in this.savedGames where game.GameID == gameID select game).Single();
        }

        /// <summary>
        /// Gets all GameModel objects.
        /// </summary>
        /// <returns>All GameModel objects.</returns>
        public IEnumerable<GameModel> GetAll()
        {
            return this.savedGames;
        }

        /// <summary>
        /// Adds a new GameModel object, and sets it's SavedAt property to the current date and time.
        /// </summary>
        /// <param name="entity">The GameModel we wish to add.</param>
        public void Add(GameModel entity)
        {
            this.savedGames.Add(entity);
            entity.SavedAt = DateTime.Now;
        }

        /// <summary>
        /// Removes a GameModel object.
        /// </summary>
        /// <param name="entity">The GameModel object we wish to remove.</param>
        public void Remove(GameModel entity)
        {
            this.savedGames.Remove(entity);
        }

        /// <summary>
        /// Saves the changes performed on the saved games.
        /// </summary>
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

        /// <summary>
        /// Reads in all saved games.
        /// </summary>
        /// <returns>The list of all games in string format.</returns>
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
