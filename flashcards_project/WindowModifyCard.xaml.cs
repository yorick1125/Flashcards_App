using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace project_interface
{
    /// <summary>
    /// Interaction logic for WindowModifyCard.xaml
    /// </summary>
    public partial class WindowModifyCard : Window
    {
        int cardIndex = ((MainWindow)Application.Current.MainWindow).listboxCards.SelectedIndex;
        int deckIndex = ((MainWindow)Application.Current.MainWindow).listboxDecks.SelectedIndex;
        public WindowModifyCard()
        {
            InitializeComponent();
            txtTitle.Text = "Modify card: " + ((MainWindow)Application.Current.MainWindow).listboxCards.SelectedItem.ToString();
            txtbFrontValue.Text = MainWindow.decks[deckIndex].Cards[cardIndex].Front;
            txtbBackValue.Text = MainWindow.decks[deckIndex].Cards[cardIndex].Back;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (txtbFrontValue.Text == "")
            {
                MessageBox.Show("You must enter a question", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (txtbBackValue.Text == "")
            {
                MessageBox.Show("You must enter an answer", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MainWindow.decks[deckIndex].Cards[cardIndex].Front = txtbFrontValue.Text;
                MainWindow.decks[deckIndex].Cards[cardIndex].Back = txtbBackValue.Text;
                MessageBox.Show("Card modified");
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
