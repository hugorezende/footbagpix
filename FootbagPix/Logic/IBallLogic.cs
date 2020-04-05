using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootbagPix.Logic
{
    public interface IBallLogic
    {
        void SetPosition(int x, int y);
        void SetSpeed();
        void DoGravity();
    }
}
