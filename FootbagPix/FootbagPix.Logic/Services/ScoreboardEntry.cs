using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FootbagPix.Services
{
    public class ScoreboardEntry
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public int MaxCombo { get; set; }
        public DateTime DateTime { get; set; }

        public static List<ScoreboardEntry> Load(string url)
        {
            XDocument xDocument = XDocument.Load(url);
            return xDocument.Descendants("entry").Select(node => new ScoreboardEntry()
            {
                Name = node.Element("name")?.Value,
                Score = Convert.ToInt32(node.Element("score")?.Value),
                MaxCombo = Convert.ToInt32(node.Element("seconds")?.Value),
                DateTime = Convert.ToDateTime(node.Element("date")?.Value),
            }).ToList();
        }

        public override string ToString()
        {
            return string.Format("{0,-12} {1,-8} {2,3} {3,12}", Name, Score.ToString(), MaxCombo.ToString()+"x", DateTime.ToShortDateString());
        }
    }
}
