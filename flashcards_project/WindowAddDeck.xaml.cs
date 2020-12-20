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
    /// Interaction logic for WindowAddDeck.xaml
    /// </summary>
    public partial class WindowAddDeck : Window
    {
        public WindowAddDeck()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            bool valid = true;
            if (txtbDeckName.Text == "")
            {
                MessageBox.Show("You must enter a deck name", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                valid = false;
            }
            for (int i = 0; i < MainWindow.decks.Count; i++)
            {
                if (MainWindow.decks[i].Name == txtbDeckName.Text)
                {
                    MessageBox.Show("Deck name cannot be the same as an existing deck's name", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    valid = false;
                }
            }
            if (valid == true)
            {
                MainWindow.decks.Add(new Deck(txtbDeckName.Text));
                MessageBox.Show("Deck " + txtbDeckName.Text + " has been created.");
                this.Close();
            }
        }
    }
}
