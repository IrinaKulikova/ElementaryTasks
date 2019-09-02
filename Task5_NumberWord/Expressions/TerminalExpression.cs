namespace Task5_NumberWord.Expressions
{
    public class TerminalExpression: IExpression
    {
        public void Interpret(Context context)
        {
            var resultInterpret = context.DictionaryWords.GetValue(context.Source[context.Position]);
            if (!string.IsNullOrEmpty(resultInterpret))
            {
                context.Result.Add(resultInterpret);
            }
        }
    }
}
