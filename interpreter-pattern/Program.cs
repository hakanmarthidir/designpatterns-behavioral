using System;
using System.Collections.Generic;

namespace interpreter_pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            //Note Sample
            List<Expression> noteConverter = new List<Expression>()
            {
                new DoNoteConverter(),
                new ReNoteConverter(),
                new MiNoteConverter()
            };

            NoteContext note = new NoteContext();
            note.Note = 1;

            foreach (var item in noteConverter)
            {
                item.Interpret(note);
            }

            Console.WriteLine(note.NoteSignature); //DO

            //Query Sample

            QueryContext query = new QueryContext() {  Data= "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum." };

            ContainsQueryExpression containsQueryExpression = new ContainsQueryExpression("Lorem");
            Console.WriteLine(containsQueryExpression.Interpret(query)); //True

            AndQueryExpression andQueryExpression = new AndQueryExpression(new ContainsQueryExpression("Lorem"), new ContainsQueryExpression("Efgh"));
            Console.WriteLine(andQueryExpression.Interpret(query)); //False

            OrQueryExpression orQueryExpression = new OrQueryExpression(new ContainsQueryExpression("Lorem"), new ContainsQueryExpression("Efgh"));
            Console.WriteLine(orQueryExpression.Interpret(query)); //True

        }
    }

  

}
