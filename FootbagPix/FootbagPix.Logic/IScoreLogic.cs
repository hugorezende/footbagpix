using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootbagPix.Logic
{
    public interface IScoreLogic
    {
        void Increase();
        void CheckIfBallFell();
        void Reset();
    }
}
