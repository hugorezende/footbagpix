using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootbagPix.Models
{
    public interface IGameModel
    {
        int Gravity { get; set; }
        CharacterModel Character { get; set; }
        BallModel Ball { get; set; }
        string PlayerName { get; set; }
        ScoreModel Score { get; set; }
        TimeSpan ElapsedTime { get; set; }
    }
}