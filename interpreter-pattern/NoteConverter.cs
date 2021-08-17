using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interpreter_pattern
{
    public class NoteContext
    {
        public byte Note { get; set; }
        public string NoteSignature { get; set; }
    }

    public abstract class Expression
    {
        public abstract void Interpret(NoteContext context);
    }

    public class DoNoteConverter : Expression
    {
        public override void Interpret(NoteContext context)
        {

            if (context.Note == 1)
            {
                context.NoteSignature = "DO";
            }
        }
    }

    public class ReNoteConverter : Expression
    {
        public override void Interpret(NoteContext context)
        {

            if (context.Note == 2)
            {
                context.NoteSignature = "RE";
            }
        }
    }

    public class MiNoteConverter : Expression
    {
        public override void Interpret(NoteContext context)
        {

            if (context.Note == 3)
            {
                context.NoteSignature = "MI";
            }
        }
    }
}
