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
    /// Interaction logic for WindowRenameDeck.xaml
    /// </summary>
    public partial class WindowRenameDeck : Window
    {
        public WindowRenameDeck()
        {
            InitializeComponent();
            txtTitle.Text = "Rename deck: " + ((MainWindow)Application.Current.MainWindow).listboxDecks.SelectedItem.ToString();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void btnRename_Click(object sender, RoutedEventArgs e)
        {
            int index = ((MainWindow)Application.Current.MainWindow).listboxDecks.SelectedIndex;
            MessageBox.Show("Renamed deck " + ((MainWindow)Application.Current.MainWindow).listboxDecks.SelectedItem.ToString() + " to " + txtbNewName.Text);
            MainWindow.decks[index].ChangeName(txtbNewName.Text);
            this.Close();
        }
    }
}
