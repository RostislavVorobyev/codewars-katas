using System;
using System.Collections.Generic;
using System.Linq;

namespace Codewars
{
    public class SimpleAssemblerInterpreter
    {
        public static Dictionary<string, int> Interpret(string[] program)
        {
            var data = new Dictionary<string, int>();
            var operations = GetOperations(program, data);

            for (int i = 0; i < operations.Count;)
            {
                i += operations[i].Execute();
            }

            return data;
        }

        private static List<ISimpleAssemblerOperation> GetOperations(string[] program, Dictionary<string, int> data)
        {
            return program.Select(x => ParseOperation(x, data)).ToList();
        }

        private static ISimpleAssemblerOperation ParseOperation(string operation, Dictionary<string, int> data)
        {
            var args = operation.Split(' ');

            return args[0] switch
            {
                "mov" => new MovOperation(data, args[1], args[2]),
                "inc" => new MathOperation(data, args[1], "1"),
                "dec" => new MathOperation(data, args[1], "-1"),
                "jnz" => new BranchingOperation(data, args[1], args[2]),
                _ => throw new NotImplementedException(),
            };
        }

        public interface ISimpleAssemblerOperation
        {
            public int Execute();
        }

        public abstract class SimpleAssemblerOperation : ISimpleAssemblerOperation
        {
            protected readonly Dictionary<string, int> data = new Dictionary<string, int>() ;
            protected readonly string register;
            protected readonly string argument;
            public abstract int Execute();

            protected SimpleAssemblerOperation(Dictionary<string, int> data, string register, string argument)
            {
                this.data = data;
                this.register = register;
                this.argument = argument;

                if (data.ContainsKey("aaaa"))
                {
                    data[register] = 1000;
                }
            }

            protected int ArgumentValue
            {
                get
                {
                    var argumentIsConstant = int.TryParse(argument, out int argumentvalue);

                    if (!argumentIsConstant)
                    {
                        return data.ContainsKey(register) ? data[register] : data[argument];
                    }

                    return argumentvalue;
                }
            }
        }

        //mov x y - copies y(either a constant value or the content of a register) into register x
        public class MovOperation : SimpleAssemblerOperation
        {
            public MovOperation(Dictionary<string, int> data, string register, string argument) : base(data, register, argument)
            {
                //data.Add("MovOperation", 10);
            }

            public override int Execute()
            {
                if (data.ContainsKey(register))
                {
                    data[register] = ArgumentValue;
                }
                else
                {
                    data.Add(register, ArgumentValue);
                }

                return 1;
            }
        }

        //inc x - increases the content of the register x by one
        //dec x - decreases the content of the register x by one
        public class MathOperation : SimpleAssemblerOperation
        {
            public MathOperation(Dictionary<string, int> data, string register, string argument) : base(data, register, argument)
            {
            }

            public override int Execute()
            {
                data[register] += ArgumentValue;
                return 1;
            }
        }

        //jnz x y - jumps to an instruction y steps away(positive means forward, negative means backward, y can be a register or a constant), but only if x(a constant or a register) is not zero
        public class BranchingOperation : SimpleAssemblerOperation
        {
            public BranchingOperation(Dictionary<string, int> data, string register, string argument) : base(data, register, argument)
            {
            }

            public override int Execute()
            {
                var argumentIsConstant = int.TryParse(argument, out int argumentvalue);

                argumentvalue = argumentIsConstant ? argumentvalue : data[register];

                return (!data.ContainsKey(register)) || data[register] == 0 ? 1 : argumentvalue;
            }
        }
    }
}