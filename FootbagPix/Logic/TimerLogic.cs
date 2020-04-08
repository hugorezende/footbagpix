using FootbagPix.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }
    }
}
