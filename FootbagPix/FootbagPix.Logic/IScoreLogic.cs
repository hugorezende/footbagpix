using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootbagPix.Logic
{
    public interface IScoreLogic
    {
        void Increase(ScoreType scoreType);
        void CheckIfBallFell();
        void Reset();
    }
}
