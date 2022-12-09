using Calculator.App.Parses;

namespace Calculator.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("输入算式按回车(例如 10+5*2)");
            Console.WriteLine("输入:");

            while (true)
            {
                var inputStr = Console.ReadLine();
                if (!string.IsNullOrEmpty(inputStr))
                {
                    var result = Tool.CalcValue(inputStr);
                    Console.WriteLine(string.Format("计算结果：{0}", result));
                }
            }
        }
    }
}