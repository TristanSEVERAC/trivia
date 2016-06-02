using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trivia
{
    internal class Questions
    {

        private readonly Dictionary<String, LinkedList<string>> _questionsByCategory = new Dictionary<String, LinkedList<string>>();
        public Questions()
        {
            _questionsByCategory["Pop"] = new LinkedList<string>();
            _questionsByCategory["Sport"] = new LinkedList<string>();
            _questionsByCategory["Science"] = new LinkedList<string>();
            _questionsByCategory["Rock"] = new LinkedList<string>();
            for (int i = 0; i < 50; i++)
            {
                _questionsByCategory["Pop"].AddLast("Pop Question " + i);
                _questionsByCategory["Sport"].AddLast(("Science Question " + i));
                _questionsByCategory["Science"].AddLast(("Sports Question " + i));
                _questionsByCategory["Rock"].AddLast(CreateRockQuestion(i));
            }
        }

        public String CreateRockQuestion(int index)
        {
            return "Rock Question " + index;
        }

        public void AskQuestion( string category)
        {
            var questions = _questionsByCategory[category];
            Console.WriteLine(questions.First());
            questions.RemoveFirst();
        }
    }
}
