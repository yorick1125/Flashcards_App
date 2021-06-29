using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using project_interface;

namespace flashcards_app
{
    public class Deck
    {
        private int id;
        private string _name;
        public List<Card> cards = new List<Card>();

        public Deck(int id, string name)
        {
            this.id = id;
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
            set { cards = value; } 
        }

        #region Static Methods
        public static List<Deck> GetDecks()
        {
            try
            {
                List<Deck> retrievedDecks = new List<Deck>();

                string stm = @"SELECT Id, Name FROM decks ORDER BY Id asc";
                var cmd = new SQLiteCommand(stm, Database.dbConnection);

                SQLiteDataReader rdr = cmd.ExecuteReader();

                // For each deck
                while (rdr.Read())
                {
                    // Add deck to list of decks
                    int Id = rdr.GetInt32(0);
                    string Name = rdr.GetString(1);
                    Deck deck = new Deck(Id, Name);

                    // query a list of all cards within that deck
                    stm = @"SELECT Id, Front, Back FROM cards WHERE DeckId = @id";
                    cmd = new SQLiteCommand(stm, Database.dbConnection);
                    cmd.Parameters.AddWithValue("@id", Id);
                    SQLiteDataReader cardsReader = cmd.ExecuteReader();

                    // For each card
                    while (cardsReader.Read())
                    {
                        // Add card to the list of cards in this deck
                        int cardId = cardsReader.GetInt32(0);
                        string cardFront = cardsReader.GetString(1) ?? "";
                        string cardBack = cardsReader.GetString(2) ?? "";
                        Card card = new Card(cardId, cardFront, cardBack);
                        deck.cards.Add(card);

                    }
                    // Add this deck to list of decks
                    retrievedDecks.Add(deck);

                }
                rdr.Close();
                return retrievedDecks;
            }
            catch (Exception e)
            {
                throw e;
            }
        }



        public static Deck AddDeck(string name)
        {
            try
            {
                var cmd = new SQLiteCommand(Database.dbConnection);

                // add deck to the database
                cmd.CommandText = @"INSERT INTO decks(Name) VALUES(@name)";
                cmd.Parameters.AddWithValue("@name", name);
                cmd.ExecuteNonQuery();

                // read the decks id
                string stm = @"SELECT Id FROM decks WHERE Name = @name";
                cmd = new SQLiteCommand(stm, Database.dbConnection);
                cmd.Parameters.AddWithValue("@name", name);

                SQLiteDataReader rdr = cmd.ExecuteReader();
                rdr.Read();
                Deck deck = new Deck(rdr.GetInt32(0), name);
                return deck;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        #endregion
        public List<Card> GetCards()
        {
            try
            {
                List<Card> cardlist = new List<Card>();
                // query a list of all cards within that deck
                string stm = @"SELECT Id, Front, Back FROM cards WHERE DeckId = @id";
                var cmd = new SQLiteCommand(stm, Database.dbConnection);
                cmd.Parameters.AddWithValue("@id", id);
                SQLiteDataReader cardsReader = cmd.ExecuteReader();
                // For each card
                while (cardsReader.Read())
                {
                    // Add card to the list of cards in this deck
                    int cardId = cardsReader.GetInt32(0);
                    string cardFront = cardsReader.GetString(1);
                    string cardBack = cardsReader.GetString(2);
                    Card card = new Card(cardId, cardFront, cardBack);
                    cardlist.Add(card);
                }
                cards = cardlist;
                return cardlist;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void CreateCard(string front, string back)
        {
            try
            {
                var cmd = new SQLiteCommand(Database.dbConnection);

                cmd.CommandText = @"INSERT INTO cards(Front, Back, DeckID) VALUES(@front, @back, @deckId)";

                cmd.Parameters.AddWithValue("@front", front);
                cmd.Parameters.AddWithValue("@back", back);
                cmd.Parameters.AddWithValue("@deckId", id);

                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }

        }


        public void RemoveCard(Card card)
        {
            try
            {
                var cmd = new SQLiteCommand(Database.dbConnection);

                cmd.CommandText = @"DELETE FROM cards WHERE DeckId = @id AND Front = @front AND Back = @Back";

                cmd.Parameters.AddWithValue("@id", this.id);
                cmd.Parameters.AddWithValue("@front", card.Front);
                cmd.Parameters.AddWithValue("@back", card.Back);

                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }

            cards.Remove(card);
        }


        public void RemoveDeck()
        {
            try
            {
                var cmd = new SQLiteCommand(Database.dbConnection);

                cmd.CommandText = @"DELETE FROM decks WHERE Id = @id";

                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void ChangeName(string newName)
        {
            try
            {
                var cmd = new SQLiteCommand(Database.dbConnection);

                cmd.CommandText = @"UPDATE decks SET Name = @name WHERE Id = @id";

                cmd.Parameters.AddWithValue("@name", _name);
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public Card[] ShuffledDeck()
        {
            //Swaps each card in the array with a random other card that is indexed above the current card but not anymore than the maximum cards[] length
            Card[] cardList = new Card[cards.Count];
            cards.CopyTo(cardList);
            Random rand = new Random();
            for (int i = 0; i < cards.Count; i++)
            {
                Swap(ref cardList, i, i + rand.Next(cards.Count - i));
            }
            return cardList;
        }

        private void Swap(ref Card[] cardList, int a, int b)
        {
            //Creates a temporary object to simply swap both cards.
            Card temp = new Card();
            temp = cardList[a];
            cardList[a] = cardList[b];
            cardList[b] = temp;
        }

        public override string ToString()
        {
            string s = "";
            foreach (Card card in cards)
            {
                s += card.ToString() + "\n";
            }
            return s;
        }
    }
}
