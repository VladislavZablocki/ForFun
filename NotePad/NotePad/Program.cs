using System;

namespace NotePad
{
    class Program
    {
        static void Main(string[] args)
        {
            CommandCreator commandForNoteBook = new CreateCommandNewNoteBook(
                new CreateCommandOpenNoteBook(
                    new CreateCommandSaveNoteBook(
                        new CreateCommandSetSource())));
            NoteBookProvider nbp = new NoteBookProvider(commandForNoteBook);
            Invoker invoker = new Invoker(commandForNoteBook);
            try
            {
                nbp.SetCommand(Console.ReadLine());
                nbp.Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}
