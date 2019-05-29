using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns
{
    // Общий интерфейс всех стратегий.
    interface IExecute
    {
        int execute(int a, int b);
    }

    // Каждая конкретная стратегия реализует общий интерфейс своим
    // способом.
    class ConcreteReduceAdd : IExecute
    {
        public int execute(int a, int b)
        {
            return a + b;
        }
    }

    class ConcreteReduceSubtract : IExecute
    {
        public int execute(int a, int b)
        {
            return a - b;
        }
    }

    class ConcreteReduceMultiply : IExecute
    {
        public int execute(int a, int b)
        {
            return a * b;
        }
    }

    class ConcreteReduceDivide : IExecute
    {
        public int execute(int a, int b)
        {
            return a / b;
        }
    }

    // Контекст всегда работает со стратегиями через общий
    // интерфейс. Он не знает, какая именно стратегия ему подана.


    class Context
    {
        private IExecute executor;

        public void SetExecutor(IExecute executor)
        {
            this.executor = executor;
        }


        public int ExecuteExecutor(int a, int b)
        {
            return executor.execute(a, b);
        }
    }


    //Decorator
    //Can't add this method without modifying Context using inheritance
    //(making executor protected will be necessary to make this work in child classes)
    //so decorator is a way to go
    class ContextDecorator
    {
        private Context context = new Context();
        private IExecute executor;

        public IExecute GetExecutor()
        {
            return executor;
        }

        public void SetExecutor(IExecute executor)
        {
            this.executor = executor;
            context.SetExecutor(executor);
        }


        public int ExecuteExecutor(int a, int b)
        {
            return context.ExecuteExecutor(a, b);
        }
    }


    class Program
    {
        static void Main(string[] args)
        {

            //Strategy
            var context = new ContextDecorator();

            var action = Console.ReadLine();
            var parameters = Array.ConvertAll(Console.ReadLine().Split(), s => int.Parse(s));
            var a = parameters[0];
            var b = parameters[1];

            if (action == "add")
            {
                context.SetExecutor(new ConcreteReduceAdd());
            }

            if (action == "sub")
            {
                context.SetExecutor(new ConcreteReduceSubtract());
            }

            if (action == "mult")
            {
                context.SetExecutor(new ConcreteReduceMultiply());
            }

            if (action == "div")
            {
                context.SetExecutor(new ConcreteReduceDivide());
            }

            // 6. Выполнить операцию с помощью стратегии:
            var result = context.ExecuteExecutor(a, b);

            Console.WriteLine(result);
            Console.WriteLine(context.GetExecutor().ToString());
            Console.ReadLine();


        }


    }

}
