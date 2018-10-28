using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace tic_tac_toe
{
	public class Row
	{
		public Button Cell1 { get; set; }
		public Button Cell2 { get; set; }
		public Button Cell3 { get; set; }
	}


	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public ObservableCollection<Row> rows = new ObservableCollection<Row>();
		public bool Playing = true;

		//public IDictionary<string, Button> Buttons = new Dictionary<string, Button>();

		public Button[] buttons;
		//public Button[] buttonsAvailable;
		//public Button[] buttons;

		public string Player = "X";
		public string Computer = "O";

		public MainWindow()
		{
			InitializeComponent();

			FillRows();

			Button[] buttonsTemp = { A1, A2, A3, B1, B2, B3, C1, C2, C3 };
			buttons = buttonsTemp;

			ChooseFirstPlayer();
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


		public void FillRows()
		{
			rows.Add(new Row() { Cell1 = A1, Cell2 = A2, Cell3 = A3 });
			rows.Add(new Row() { Cell1 = B1, Cell2 = B2, Cell3 = B3 });
			rows.Add(new Row() { Cell1 = C1, Cell2 = C2, Cell3 = C3 });

			rows.Add(new Row() { Cell1 = A1, Cell2 = B1, Cell3 = C1 });
			rows.Add(new Row() { Cell1 = A2, Cell2 = B2, Cell3 = C2 });
			rows.Add(new Row() { Cell1 = A3, Cell2 = B3, Cell3 = C3 });

			rows.Add(new Row() { Cell1 = A1, Cell2 = B2, Cell3 = C3 });
			rows.Add(new Row() { Cell1 = C1, Cell2 = B2, Cell3 = A3 });
		}



		private bool CheckGrid(string input)
		{
			foreach (Row row in rows)
			{
				if (IsSame(input, row.Cell1.Content.ToString(), row.Cell2.Content.ToString(), row.Cell3.Content.ToString()))
				{
					return true;
				}
			}
			return false;
		}

		private bool IsSame(string input, string val1, string val2, string val3)
		{
			if (val1 == input && val2 == input && val3 == input)
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
			foreach (Row row in rows)
			{
				row.Cell1.IsEnabled = true;
				row.Cell2.IsEnabled = true;
				row.Cell3.IsEnabled = true;

				row.Cell1.Content = " ";
				row.Cell2.Content = " ";
				row.Cell3.Content = " ";
			}

			Playing = true;

			ChooseFirstPlayer();
		}

		private void DisableGrid()
		{
			foreach (Button button in buttons)
			{
				button.IsEnabled = false;
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
					int indexnumber = random.Next(0, 9);

					if (buttons[indexnumber].Content.ToString() == " ")
					{
						buttons[indexnumber].Content = "O";
						buttons[indexnumber].IsEnabled = false;
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
	}
}
