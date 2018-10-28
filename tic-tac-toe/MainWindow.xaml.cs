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
		

		public string Player = "X";
		public string Computer = "O";

		public MainWindow()
		{
			InitializeComponent();

			PopulateGameGrid();
			ChooseFirstPlayer();

		}

		public void PopulateGameGrid()
		{
			Queue queue = new Queue(GameGridPanel.Children);

			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					GameGrid.Grid[j, i] = queue.Dequeue() as Button;
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

		private bool CompareThree(Button btn1, Button btn2, Button btn3)
		{
			if (btn1.Content.ToString() == Player || btn1.Content.ToString() == Computer)
			{
				if (btn2.Content == btn1.Content && btn3.Content == btn2.Content)
				{
					return true;
				}
			}
			return false;
		}

		private bool CheckGrid(string input)
		{
			if (CompareThree(GameGrid.Grid[0, 0], GameGrid.Grid[0, 1], GameGrid.Grid[0, 2]))
			{
				return true;
			}
			else if (CompareThree(GameGrid.Grid[1, 0], GameGrid.Grid[1, 1], GameGrid.Grid[1, 2]))
			{
				return true;
			}
			else if (CompareThree(GameGrid.Grid[2, 0], GameGrid.Grid[2, 1], GameGrid.Grid[2, 2]))
			{
				return true;
			}
			else if (CompareThree(GameGrid.Grid[0, 0], GameGrid.Grid[1, 0], GameGrid.Grid[2, 0]))
			{
				return true;
			}
			else if (CompareThree(GameGrid.Grid[1, 0], GameGrid.Grid[1, 1], GameGrid.Grid[1, 2]))
			{
				return true;
			}
			else if (CompareThree(GameGrid.Grid[2, 0], GameGrid.Grid[2, 1], GameGrid.Grid[2, 2]))
			{
				return true;
			}
			else if (CompareThree(GameGrid.Grid[0, 0], GameGrid.Grid[1, 1], GameGrid.Grid[2, 2]))
			{
				return true;
			}
			else if (CompareThree(GameGrid.Grid[2, 0], GameGrid.Grid[1, 1], GameGrid.Grid[0, 2]))
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		

		private void PlayerMoves(Button input)
		{
			if (Playing)
			{
				input.Content = "X";
				input.IsEnabled = false;
			}

			if (CheckGrid(Player))
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
					GameGrid.Grid[j, i].IsEnabled = true;
					GameGrid.Grid[j, i].Content = " ";
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
					GameGrid.Grid[j, i].IsEnabled = false;
				}
			}
		}

		private void ComputerMoves()
		{
			if (Playing)
			{
				while (true)
				{
					Random randomSeed = new Random();
					Random random = new Random(randomSeed.Next());
					int rownumber = random.Next(0, 3);
					int columnnumber = random.Next(0, 3);

					if (GameGrid.Grid[columnnumber, rownumber].Content.ToString() == " ")
					{
						GameGrid.Grid[columnnumber, rownumber].Content = "O";
						GameGrid.Grid[columnnumber, rownumber].IsEnabled = false;
						if (CheckGrid(Computer))
						{
							MessageBox.Show("Computer wins!");
							Playing = false;
							DisableGrid();
						}
						break;
					}
				}
			}
		}

		private void ClassicMode_Checked(object sender, RoutedEventArgs e)
		{

		}

		private void ModernMode_Checked(object sender, RoutedEventArgs e)
		{

		}

		private void DebugDisplayGrid_Click(object sender, RoutedEventArgs e)
		{
			string output = "";

			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					output = output + GameGrid.Grid[j, i].Content + "\t";
				}
				output = output + "\n";
			}

			MessageBox.Show(output + "\n" + "\n" + GameGrid.Grid[1, 1].Name);
		}
	}
}
