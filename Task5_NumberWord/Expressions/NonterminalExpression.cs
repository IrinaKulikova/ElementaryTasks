using Task5_NumberWord.Factories.Interfaces;

namespace Task5_NumberWord.Expressions
{
    public class NonterminalExpression : IExpression
    {
        private INumberPartsCollectionFactory numberPartsCollectionFactory;

        public NonterminalExpression(INumberPartsCollectionFactory numberPartsCollectionFactory)
        {
            this.numberPartsCollectionFactory = numberPartsCollectionFactory;
        }

        public void Interpret(Context context)
        {
            context.Source.AddRange(numberPartsCollectionFactory.Parse(context.Number));
            while (context.Position < context.Source.Count)
            {
                var terminalExcpression = new TerminalExpression();
                terminalExcpression.Interpret(context);
                context.Position++;
            }
        }
    }
}
