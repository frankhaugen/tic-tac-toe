using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace tic_tac_toe
{
    public class Referee
    {
        private string _player;
        private string _computer;

        public bool CheckGrid(GameGrid gameGrid, string player, string computer)
        {
            _player = player;
            _computer = computer;

            if (CompareThree(gameGrid.Grid[0, 0], gameGrid.Grid[0, 1], gameGrid.Grid[0, 2]))
            {
                return true;
            }
            else if (CompareThree(gameGrid.Grid[0, 1], gameGrid.Grid[1, 1], gameGrid.Grid[2, 1]))
            {
                return true;
            }
            else if (CompareThree(gameGrid.Grid[0, 2], gameGrid.Grid[1, 2], gameGrid.Grid[2, 2]))
            {
                return true;
            }
            else if (CompareThree(gameGrid.Grid[0, 0], gameGrid.Grid[1, 0], gameGrid.Grid[2, 0]))
            {
                return true;
            }
            else if (CompareThree(gameGrid.Grid[1, 0], gameGrid.Grid[1, 1], gameGrid.Grid[1, 2]))
            {
                return true;
            }
            else if (CompareThree(gameGrid.Grid[2, 0], gameGrid.Grid[2, 1], gameGrid.Grid[2, 2]))
            {
                return true;
            }
            else if (CompareThree(gameGrid.Grid[0, 0], gameGrid.Grid[1, 1], gameGrid.Grid[2, 2]))
            {
                return true;
            }
            else if (CompareThree(gameGrid.Grid[2, 0], gameGrid.Grid[1, 1], gameGrid.Grid[0, 2]))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool CompareThree(Button btn1, Button btn2, Button btn3)
        {
            if (btn1.Content.ToString() == _player || btn1.Content.ToString() == _computer)
            {
                if (btn2.Content == btn1.Content && btn3.Content == btn2.Content)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
