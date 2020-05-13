using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace FootbagPix.Models
{
    public interface IGameModel
    {
        Guid GameID { get; set; }
        CharacterModel Character { get; set; }
        BallModel Ball { get; set; }
        TimerModel Timer { get; set; }
        string PlayerName { get; set; }
        ScoreModel Score { get; set; }
    }
}