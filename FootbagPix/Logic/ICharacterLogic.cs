using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootbagPix.Logic
{
    public interface ICharacterLogic
    {
        void MoveLeft();
        void MoveRight();
        ScoreType TryHitBall();
        void KickLeft();
        void KickRight();
        void Turn();
        void BlockControl(int miliseconds);
        void Reset();
    }
}
