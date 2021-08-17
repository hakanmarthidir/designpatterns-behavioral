using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interpreter_pattern
{

    public class QueryContext
    {
        public string Data { get; set; }
    }

    public interface IQueryExpression
    {
        bool Interpret(QueryContext context);
    }


    public class ContainsQueryExpression : IQueryExpression
    {
        private string _term;
        public ContainsQueryExpression(string searchValue)
        {
            this._term = searchValue;
        }

        public bool Interpret(QueryContext context)
        {
            return context.Data.Contains(this._term) ? true : false;
        }
    }


    public class AndQueryExpression : IQueryExpression
    {

        IQueryExpression _expression1;
        IQueryExpression _expression2;

        public AndQueryExpression(IQueryExpression queryExpression1, IQueryExpression queryExpression2)
        {
            this._expression1 = queryExpression1;
            this._expression2 = queryExpression2;
        }


        public bool Interpret(QueryContext context)
        {
            return this._expression1.Interpret(context) && this._expression2.Interpret(context);
        }
    }

    public class OrQueryExpression : IQueryExpression
    {

        IQueryExpression _expression1;
        IQueryExpression _expression2;

        public OrQueryExpression(IQueryExpression queryExpression1, IQueryExpression queryExpression2)
        {
            this._expression1 = queryExpression1;
            this._expression2 = queryExpression2;
        }


        public bool Interpret(QueryContext context)
        {
            return this._expression1.Interpret(context) || this._expression2.Interpret(context);
        }
    }




}
