using FootbagPix.Models;
using FootbagPix.Renderer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace FootbagPix.Logic
{
    class TimerLogic : ITimerLogic
    {
        TimerModel timer;

        public TimerLogic(TimerModel timer)
        {
            this.timer = timer;
        }

        public void DecrementTime()
        {
            if (!timer.GameOver)
            {
                if (timer.TimeLeft > 0)
                {
                    timer.TimeLeft--;
                }
                else
                {
                    timer.GameOver = true;
                    ShowGameOver();
                }
            }

        }

        public void ShowGameOver()
        {
            timer.gameOverBrush.Opacity = 1;
            timer.gameOverTextBrush = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
        }
    }
}
