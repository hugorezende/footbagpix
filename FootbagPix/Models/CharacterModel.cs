using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FootbagPix.Models
{
    public class CharacterModel
    {
        // to be implemented
        public Rect leftFoot, rigthFoot, body;

        public Rect LeftFoot { get { return leftFoot; } }
        public Rect RigthFoot { get { return rigthFoot; } }
        public Rect Body { get { return body; } }
        public int PositionX { get; set; }

        public CharacterModel()
        {
            leftFoot = new Rect(50, 300, 40, 20);
            rigthFoot = new Rect(100, 300, 40, 20);
            body = new Rect(50, 40, 100, 200);
            PositionX = 75;
        }
    }
}
