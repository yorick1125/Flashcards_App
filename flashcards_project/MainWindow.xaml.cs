using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using flashcards_app;

namespace project_interface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static List<Deck> decks = new List<Deck>();
        const string FILE_PATH = "./data.txt";

        public MainWindow()
        {
            InitializeComponent();
            WindowWelcome welcome = new WindowWelcome();
            welcome.ShowDialog();
            SetupDatabase();
            //ReadFile();
            DisplayDecks();
        }

        // Reads the data from the data file
        // Initializes the read data into the correct decks and cards
        //private void ReadFile()
        //{
        //    //Opens the file and reads the first three lines
        //    if (File.Exists(FILE_PATH))//opens file if it exists
        //    {
        //        try
        //        {
        //            string[] lines = File.ReadAllLines(FILE_PATH);//The file has the name of a deck on the even index of the line count, followed by all of its cards on a single line in the next one.
        //            //Example
        //            //line1-Deck_Name
        //            //line2-frontvalue/backvalue_frontvalue/backvalue_frontvalue/backvalue etc.
        //            //line3-Deck_Name
        //            //line4-frontvalue/backvalue_frontvalue/backvalue_frontvalue/backvalue etc.
        //            int deckIndexCounter = -1;
        //            for (int i = 0; i < lines.Length; i++)//for each line
        //            {
        //                if (i % 2 == 0)//if the line is an even number
        //                {
        //                    deckIndexCounter++;
        //                    decks.Add(new Deck(lines[i]));
        //                }
        //                else//if the line is an odd number
        //                {
        //                    string[] fullCards = lines[i].Split('_');//Splits the line by underscore for each seperate card Ex: card1/card1_card2/card2 --> "card1/card1" "card2/card2"
        //                    for (int j = 0; j < fullCards.Length; j++)//for each card on that line
        //                    {
        //                        string front = fullCards[j].Split('/')[0];
        //                        string back = fullCards[j].Split('/')[1];
        //                        decks[deckIndexCounter].CreateCard(front, back);

        //                    }
        //                }
        //            }
        //        }

        //        catch (Exception e)
        //        {
        //            Console.WriteLine(e.Message);
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("File does not exist. Creating blank file.");
        //        // Creates blank data file and closes the stream
        //        File.Create(FILE_PATH).Dispose();
        //    }

        //}


        private void SetupDatabase()
        {
            string databaseFileName = "data.db";
            // if database file doesn't exist yet, create it
            if (!File.Exists(databaseFileName))
            {
                Database.newDatabase(databaseFileName);
            }
            else
            {
                Database.openExistingDatabase(databaseFileName);
            }

        }
        private void DisplayDecks()
        {
            listboxDecks.Items.Clear();
            decks = Deck.GetDecks();

            for (int i = 0; i < decks.Count; i++)
            {
                listboxDecks.Items.Add(decks[i].Name);
            }
        }

        private void DisplayCards()
        {
            if (listboxDecks.SelectedIndex != -1)
            {
                decks[listboxDecks.SelectedIndex].GetCards();
                listboxCards.Items.Clear();
                for (int i = 0; i < decks[listboxDecks.SelectedIndex].Cards.Count; i++)
                {
                    listboxCards.Items.Add(decks[listboxDecks.SelectedIndex].Cards[i].Front);
                }
            }
        }

        private void btnRemoveCard_Click(object sender, RoutedEventArgs e)
        {
            if (listboxCards.SelectedItem == null)
            {
                MessageBox.Show("You must select a card to remove first", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (MessageBox.Show("Are you sure you want to remove the card: \n" + listboxCards.SelectedItem.ToString(), "Remove Card", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                
            }
            else
            {
                Card card = decks[listboxDecks.SelectedIndex].Cards[listboxCards.SelectedIndex];
                decks[listboxDecks.SelectedIndex].RemoveCard(card);
                DisplayCards();
            }
        }

        private void listboxDecks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DisplayCards();
        }

        private void btnAddCard_Click(object sender, RoutedEventArgs e)
        {
            if (listboxDecks.SelectedItem == null)
            {
                MessageBox.Show("You must select a deck to add a card to first", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                windowAddCard addCard = new windowAddCard();
                addCard.ShowDialog();
                DisplayCards();
            }
        }

        private void btnRenameDeck_Click(object sender, RoutedEventArgs e)
        {
            if (listboxDecks.SelectedItem == null)
            {
                MessageBox.Show("You must select a deck to rename first", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                WindowRenameDeck renameDeck = new WindowRenameDeck();
                renameDeck.ShowDialog();
                DisplayDecks();
            }
        }

        private void btnRemoveDeck_Click(object sender, RoutedEventArgs e)
        {
            if (listboxDecks.SelectedItem == null)
            {
                MessageBox.Show("You must select a deck to remove first", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (MessageBox.Show("Are you sure you want to remove the deck: \n" + listboxDecks.SelectedItem.ToString(), "Remove Deck", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                
            }
            else
            {
                Deck deck = decks[listboxDecks.SelectedIndex];
                deck.RemoveDeck();
                decks.Remove(deck);
                DisplayDecks();
                listboxCards.Items.Clear();
            }
        }

        private void btnModifyCard_Click(object sender, RoutedEventArgs e)
        {
            if (listboxCards.SelectedItem == null)
            {
                MessageBox.Show("You must select a card to modify first", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                WindowModifyCard modifyCard = new WindowModifyCard();
                modifyCard.ShowDialog();
                DisplayCards();
            }
        }

        private void btnStartDeck_Click(object sender, RoutedEventArgs e)
        {
            if (listboxDecks.SelectedItem == null)
            {
                MessageBox.Show("You must select a deck to start first", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (decks[listboxDecks.SelectedIndex].Cards.Count == 0)
            {
                MessageBox.Show("Deck must contain a card before you can start", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                WindowStartFlashcards startFlashcards = new WindowStartFlashcards();
                startFlashcards.ShowDialog();
            }
        }

        private void btnSaveExit_Click(object sender, RoutedEventArgs e)
        {
           this.Close();
        }

        private void btnAddDeck_Click(object sender, RoutedEventArgs e)
        {
            WindowAddDeck addDeck = new WindowAddDeck();
            addDeck.ShowDialog();
            DisplayDecks();
        }
    }  
}
