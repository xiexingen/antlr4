using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using Calculator.Parse;

namespace Calculator.App.Parses
{
    /// <summary>
    /// 访问模式 ICalculatorVisitor 接口的实现类
    /// </summary>
    /// <typeparam name="result">返回类型定义</typeparam>
    public class CalculatorVisitor : CalculatorBaseVisitor<double>
    {
        //访问 prog 节点
        public override double VisitProg(CalculatorParser.ProgContext context)
        {
            //prog 不需要处理,往下一层
            return base.Visit(context.GetChild(0));
        }

        //访问 expr 节点
        public override double VisitExpr(CalculatorParser.ExprContext context)
        {

            if (context.ChildCount == 3)
            {
                if (context.GetChild(0).GetText() == "(")
                {
                    //圆括号 往下一层
                    return base.Visit(context.GetChild(1));
                }

                var op = context.GetChild(1).ToString();
                var left = base.Visit(context.GetChild(0));
                var right = base.Visit(context.GetChild(2));
                if (op == "+")
                    return left + right;
                else if (op == "-")
                    return left - right;
                else if (op == "*")
                    return left * right;
                else if (op == "/")
                    return left / right;
            }
            else if (context.ChildCount == 1)
            {
                //往下一层(INT or FLOAT)
                return base.Visit(context.GetChild(0));
            }

            throw new NotSupportedException();
        }

        //访问 末尾 节点 （INT 、 FLOAT）
        public override double VisitTerminal(ITerminalNode node)
        {
            var lexer = node.Symbol.TokenSource as Lexer;
            var type = lexer?.Vocabulary.GetSymbolicName(node.Symbol.Type);
            var text = node.GetText();
            if (type == "INT")
                return int.Parse(text);
            else if (type == "FLOAT")
                return double.Parse(text);
            throw new Exception("unkown value:" + type + "=" + text);
        }

        public override double VisitErrorNode(IErrorNode node)
        {
            return base.VisitErrorNode(node);
        }
    }
}
