using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace tic_tac_toe
{
    public class Computer
    {
        private readonly Referee _referee;

        public Computer()
        {
            _referee = new Referee();
        }

        public bool Move(GameGrid _gameGrid)
        {
            while (true)
            {
                Random randomSeed = new Random();
                Random random = new Random(randomSeed.Next());
                int rownumber = random.Next(0, 3);
                int columnnumber = random.Next(0, 3);

                if (_gameGrid.Grid[columnnumber, rownumber].Content.ToString() == " ")
                {
                    _gameGrid.Grid[columnnumber, rownumber].Content = "O";
                    _gameGrid.Grid[columnnumber, rownumber].IsEnabled = false;
                    return _referee.CheckGrid(_gameGrid, "", Computer);
                }
            }
        }
    }
}
