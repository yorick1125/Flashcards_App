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
    /// Interaction logic for windowAddCard.xaml
    /// </summary>
    public partial class windowAddCard : Window
    {
        public windowAddCard()
        {
            InitializeComponent();
            txtTitle.Text = "Add card to deck: " + ((MainWindow)Application.Current.MainWindow).listboxDecks.SelectedItem.ToString();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            int index = ((MainWindow)Application.Current.MainWindow).listboxDecks.SelectedIndex;
            bool valid = true;
            if (txtbFrontValue.Text == "")
            {
                MessageBox.Show("You must enter a question", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                valid = false;
            }
            else if (txtbBackValue.Text == "")
            {
                MessageBox.Show("You must enter an answer", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                valid = false;
            }

            for (int i = 0; i < MainWindow.decks[index].Cards.Count; i++)
            {
                if (MainWindow.decks[index].Cards[i].Front == txtbFrontValue.Text)
                {
                    MessageBox.Show("Card cannot have the same front value as an existing card in the deck", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    valid = false;
                }
            }
            if (valid == true)
            {
                MainWindow.decks[index].CreateCard(txtbFrontValue.Text, txtbBackValue.Text);
                MessageBox.Show("Card added to deck " + ((MainWindow)Application.Current.MainWindow).listboxDecks.SelectedItem.ToString());
                this.Close();
            }
        }
    }
}
