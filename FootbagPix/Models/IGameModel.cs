using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootbagPix.Models
{
    public interface IGameModel
    {
        CharacterModel Character { get; set; }
        BallModel Ball { get; set; }
        string PlayerName { get; set; }
        ScoreModel Score { get; set; }
    }
}