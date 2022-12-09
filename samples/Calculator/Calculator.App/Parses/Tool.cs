﻿using Antlr4.Runtime;
using Calculator.Parse;

namespace Calculator.App.Parses
{
    public class Tool
    {
        /// <summary>
        /// 算式文本 计算求值
        /// </summary>
        /// <param name="text">算式文本</param>
        /// <returns>计算值</returns>
        public static string CalcValue(string text)
        {
            string reuslt = "";
            var calcu = new CalculatorVisitor();
            var l = GetAntlrLexer(text, typeof(CalculatorLexer));
            var p = GetAntlrParser(l, typeof(CalculatorParser)) as CalculatorParser;
            var ctx = p.expr();

            reuslt = calcu.Visit(ctx).ToString();
            return reuslt;
        }

        /// <summary>
        /// 获取 语法分析器
        /// </summary>
        /// <param name="lex">词法分析器实例</param>
        /// <param name="parserType">语法分析器 type</param>
        /// <returns>语法分析器实例</returns>
        public static Parser GetAntlrParser(Lexer lex, Type parserType)
        {
            var tokenstream = new CommonTokenStream(lex);
            var parser = Activator.CreateInstance(parserType, tokenstream) as Parser;
            return parser;
        }
        /// <summary>
        /// 获取 词法分析器
        /// </summary>
        /// <param name="text">输入的文本</param>
        /// <param name="lexerType">词法分析器 type</param>
        /// <returns>词法分析器实例</returns>
        public static Lexer GetAntlrLexer(string text, Type lexerType)
        {
            AntlrInputStream input = new AntlrInputStream(text);
            var lex = Activator.CreateInstance(lexerType, input) as Lexer;
            return lex;
        }
    }
}
