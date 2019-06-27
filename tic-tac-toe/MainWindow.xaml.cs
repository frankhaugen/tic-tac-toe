using System;
using System.Collections;
using System.Windows;
using System.Windows.Controls;

namespace tic_tac_toe
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public bool Playing = true;
        private readonly GameGrid _gameGrid;
        private readonly Referee _referee;

		public string Player = "X";
		public string Computer = "O";

		public MainWindow()
		{
			InitializeComponent();
            _gameGrid = new GameGrid();
            _referee = new Referee();
			PopulateGameGrid();
			ChooseFirstPlayer();

		}

        private void Move()
        {
            
        }

		public void PopulateGameGrid()
		{
			Queue queue = new Queue(GameGridPanel.Children);

			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					_gameGrid.Grid[j, i] = queue.Dequeue() as Button;
				}
			}
		}

		private void ChooseFirstPlayer()
		{
			Random random = new Random();
			if (random.Next(0, 2) == 1)
			{
				FirstMove.Content = "Computer";
				ComputerMoves();
			}
			else
			{
				FirstMove.Content = "Player";

			}
		}
        
		private void PlayerMoves(Button input)
		{
			if (Playing)
			{
				input.Content = "X";
				input.IsEnabled = false;
			}

			if (_referee.CheckGrid(_gameGrid, Player, Computer))
			{
				MessageBox.Show("Player wins!");
				Playing = false;
				DisableGrid();
			}

			ComputerMoves();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			Button input = sender as Button;

			if (input.Content.ToString() == " " && Playing)
			{
				PlayerMoves(input);
			}
		}

		private void ResetButton_Click(object sender, RoutedEventArgs e)
		{
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					_gameGrid.Grid[j, i].IsEnabled = true;
					_gameGrid.Grid[j, i].Content = " ";
				}
			}
			Playing = true;
			PopulateGameGrid();
			ChooseFirstPlayer();
		}

		private void DisableGrid()
		{
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					_gameGrid.Grid[j, i].IsEnabled = false;
				}
			}
		}

		private void ComputerMoves()
		{
			if (Playing)
			{
				
			}
		}

		private void ClassicMode_Checked(object sender, RoutedEventArgs e)
		{

		}

		private void ModernMode_Checked(object sender, RoutedEventArgs e)
		{

		}
	}
}
