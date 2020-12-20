using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_interface
{
    /// <summary>
    /// This class stores question and answer values for each flashcard
    /// </summary>
    public class Card
    {
        private string _front;
        private string _back;

        public string Front
        {
            get { return _front; }
            set { _front = value; }
        }

        public string Back
        {
            get { return _back; }
            set { _back = value; }
        }

        public Card(string front, string back)
        {
            _front = front;
            _back = back;
        }

        public string Format()
        {
            return (_front + "/" + _back);
        }

        public override string ToString()
        {
            return ("Q:" +_front + " A:" + _back);
        }
    }
}
