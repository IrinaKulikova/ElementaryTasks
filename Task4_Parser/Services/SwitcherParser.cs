namespace Task4_Parser.Services
{
    public class SwitcherParser : ReaderParser
    {
        protected override void ReplaceHook(string newText, string oldText, string source, int index)
        {
            base.ReplaceHook(newText, oldText, source, index);
        }
    }
}
