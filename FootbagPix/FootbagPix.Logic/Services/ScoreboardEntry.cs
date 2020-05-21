// <copyright file="ScoreboardEntry.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FootbagPix.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Linq;

    public class ScoreboardEntry
    {
        public string Name { get; set; }

        public int Score { get; set; }

        public int MaxCombo { get; set; }

        public DateTime DateTime { get; set; }

        public static List<ScoreboardEntry> Load(string url)
        {
            XDocument xDocument = XDocument.Load(url);
            System.Globalization.CultureInfo cultureinfo = new System.Globalization.CultureInfo("en-US");
            return xDocument.Descendants("entry").Select(node => new ScoreboardEntry()
            {
                Name = node.Element("name")?.Value,
                Score = Convert.ToInt32(node.Element("score")?.Value),
                MaxCombo = Convert.ToInt32(node.Element("seconds")?.Value),
                DateTime = DateTime.Parse(node.Element("date")?.Value, cultureinfo),
            }).ToList();
        }

        public override string ToString()
        {
            return string.Format("{0,-12} {1,-8} {2,3} {3,12}", this.Name, this.Score.ToString(), this.MaxCombo.ToString() + "x", this.DateTime.ToShortDateString());
        }
    }
}
