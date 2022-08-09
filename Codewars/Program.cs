using System;

namespace Codewars
{
    class Program
    {
        static void Main(string[] args)
        {
            SimpleAssemblerInterpreter.Interpret(new [] { "mov a 5", "inc a", "dec a", "dec a", "jnz a -1", "inc a" });
            SimpleAssemblerInterpreter.Interpret(new [] { "mov x 262", "mov t 1", "jnz t 5", "jnz x 2", "inc x", "inc x", "dec x", "dec x", "inc t", "inc t", "dec x" });
        }
    }
}
