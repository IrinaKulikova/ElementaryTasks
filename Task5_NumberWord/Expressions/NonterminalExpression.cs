namespace Task5_NumberWord.Expressions
{
    public class NonterminalExpression : IExpression
    {
        public void Interpret(Context context)
        {
            while (context.Position < context.Source.Length)
            {
                var terminalExcpression = new TerminalExpression();
                terminalExcpression.Interpret(context);
                context.Position++;
            }
        }
    }
}
