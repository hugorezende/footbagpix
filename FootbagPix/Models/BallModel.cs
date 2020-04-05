using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FootbagPix.Models
{
    public class BallModel
    {
        // to be implemented
        const int width = 20;
        const int heigth = 20;

        public Rect area;
        public Rect Area { get { return area; } }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public double SpeedX { get; set; }
        public double SpeedY { get; set; }

        public BallModel()
        {
            area = new Rect(30, 30, 20, 20);
            PositionX = Config.windowHeight-50;
            PositionX = Config.windowWidth/2;
            SpeedX = 0;
            SpeedY = 0;
        }
        
    }
}
