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
    /// Interaction logic for WindowStartFlashcards.xaml
    /// </summary>
    public partial class WindowStartFlashcards : Window
    {
        int deckIndex = ((MainWindow)Application.Current.MainWindow).listboxDecks.SelectedIndex;
        int cardsShown = 0;
        int rightAnswers = 0;
        int cardIndex;
        Random random = new Random();
        List<int> finishedCards = new List<int>();
        public WindowStartFlashcards()
        {
            InitializeComponent();
            FlashcardsGame();
        }

        public void FlashcardsGame()
        {
            txtTitle.Text = ((MainWindow)Application.Current.MainWindow).listboxDecks.SelectedItem.ToString() + ": Question " + (cardsShown + 1);
            
            cardIndex = random.Next(0, MainWindow.decks[deckIndex].Cards.Count);
            while(finishedCards.Contains(cardIndex))
            {
                cardIndex = random.Next(0, MainWindow.decks[deckIndex].Cards.Count);
            }
            
            finishedCards.Add(cardIndex);
            cardsShown++;
            
            UpdateQuestion(cardIndex);
        }

        public void UpdateQuestion(int cardIndex)
        {
            txtbFrontValue.Text = MainWindow.decks[deckIndex].Cards[cardIndex].Front;
            stackAnswer.Visibility = Visibility.Collapsed;
            stackAnswerButtons.Visibility = Visibility.Collapsed;
            btnShowAnswer.Visibility = Visibility.Visible;
        }

        private void btnShowAnswer_Click(object sender, RoutedEventArgs e)
        {
            txtbBackValue.Text = MainWindow.decks[deckIndex].Cards[cardIndex].Back;
            btnShowAnswer.Visibility = Visibility.Collapsed;
            stackAnswer.Visibility = Visibility.Visible;
            stackAnswerButtons.Visibility = Visibility.Visible;

        }

        private void btnEnd_Click(object sender, RoutedEventArgs e)
        {
            CloseGame();
        }

        private void btnWrong_Click(object sender, RoutedEventArgs e)
        {
            if (cardsShown < MainWindow.decks[deckIndex].Cards.Count)
            {
                FlashcardsGame();
            }
            else
            {
                CloseGame();
            }
        }

        private void btnRight_Click(object sender, RoutedEventArgs e)
        {
            rightAnswers++;
            if (cardsShown < MainWindow.decks[deckIndex].Cards.Count)
            {
                FlashcardsGame();
            }
            else
            {
                CloseGame();
            }
        }

        private void CloseGame()
        {
            double percentage = ((double)rightAnswers / (double)cardsShown) * 100;
            MessageBox.Show("Game Ended\nCards Shown: " + cardsShown + "\nRight Answers: " + rightAnswers + "\nScore: " + Math.Round(percentage) + "%");
            this.Close();
        }
    }
}
