using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_interface
{
    /// <summary>
    /// This class updates and stores different collections of flashcards in a list to organize them
    /// </summary>
    public class Deck
    {
        private List<Card> cards = new List<Card>();
        private string _name;

        public Deck(string name)
        {
            _name = name;
        }

        public string Name
        {
            get { return _name; }
            private set { _name = value; }
        }

        public List<Card> Cards
        {
            get { return cards; }
        }

        // Adds a new card to the deck
        // Receives the front and back values of the card to create
        public void CreateCard(string front, string back)
        {
            cards.Add(new Card(front, back));
        }

        // Removes a card from the deck's lsit of cards
        // Receives the card to remove
        public void RemoveCard(Card card)
        {
            cards.Remove(card);
        }

        // Changes the name of the current deck
        // Receives the new name as a string
        public void ChangeName(string newName)
        {
            _name = newName;
        }

        // Formats all of the cards in the deck into the readable format we use to save the data
        // Returns the formatted string of all the cards in the deck
        public string FormatCards()
        {
            string allCardsInThisDeck = "";

            for (int i = 0; i < cards.Count; i++)// searches through all the cards in this deck
            {
                allCardsInThisDeck += cards[i].Format();//adds the current card 
                if (i != (cards.Count - 1))// if this is the last index
                {
                    allCardsInThisDeck += "_";// Will not add it if this is the last card in the array
                }

            }
            return (allCardsInThisDeck);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
