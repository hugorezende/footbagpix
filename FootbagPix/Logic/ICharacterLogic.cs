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
        bool TryHitBall();
        void Turn();
        void BlockControl(int miliseconds);
        void Reset();
    }
}
