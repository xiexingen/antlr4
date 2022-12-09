## 说明
这是一个使用 Antlr4 实现支持四则运算的计算器应用案例

## 环境

- 语言 ：C#
- IDE 工具：Visual Studio 2022
- .net6.0

## 项目

- Calculator.Parse : 该项目引入依赖了 Antlr4 、 Antlr4.Runtime , 是存放 .g4 文件的位置，通过“生成” 操作，可获得 词法、语法 分析器
- Calculator.App : 该项目依赖 Calculator.Parse ,通过 Calculator.g4 生成的分析器，构成了一个控制台式的“计算器”程序。


## 启动

1. 先编译 Calculator.Parse
2. 启动 Calculator.App