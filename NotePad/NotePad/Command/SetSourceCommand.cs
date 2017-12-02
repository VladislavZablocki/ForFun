namespace NotePad
{
    class SetSourceCommand : ICommand
    {
        private NoteBookProvider provider;
        private string source;
        public SetSourceCommand(NoteBookProvider provider,string source)
        {
            this.provider = provider;
            this.source = source;
        }

        public void Execute()
        {
            provider.SetSource(source);
        }
    }
}
