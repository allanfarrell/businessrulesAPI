using System;
using System.Collections.Generic;
using System.Text;

namespace RuleEngine.LoxSharp
{
    public enum TokenType
    {
        // Single-character tokens
        LeftParenthesis,
        RightParenthesis,
        
        Plus,
        Minus,
        Slash,
        Star,
        Percent,

        Dot,
        Comma,
        Semicolon,

        // One or two character tokens
        Bang,
        BangEqual,

        Equal,
        EqualEqual,

        Greater,
        GreaterEqual,

        Less,
        LessEqual,

        // Literals
        Identifier,
        String,
        Number,

        // Keywords
        And,
        Or,
        Xor,
        True,
        False,
        Nil,
        Var,
        Rule,
        Evaluate,
        EOF
    }
}
