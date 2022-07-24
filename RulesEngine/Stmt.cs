using System.Collections.Generic;

namespace RuleEngine.LoxSharp
{
    public abstract class Stmt
    {
        public abstract T Accept<T>(IStmtVisitor<T> visitor);

        public class Expression : Stmt
        {
            public Expression(Expr @expr)
            {
                Expr = @expr;
            }

            public Expr Expr { get; }

            public override T Accept<T>(IStmtVisitor<T> visitor)
            {
                return visitor.VisitExpressionStmt(this);
            }
        }

        public class Var : Stmt
        {
            public Var(Token @name, Expr @initializer)
            {
                Name = @name;
                Initializer = @initializer;
            }

            public Token Name { get; }
            public Expr Initializer { get; }

            public override T Accept<T>(IStmtVisitor<T> visitor)
            {
                return visitor.VisitVarStmt(this);
            }
        }

    }

    public interface IStmtVisitor<T>
    {
        T VisitExpressionStmt(Stmt.Expression stmt);
        T VisitVarStmt(Stmt.Var stmt);
    }
}
