using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Threading.Tasks;

namespace simo_cli
{
    class Program
    {
        static async Task<int> Main(string[] args)
        {
            var cmd = new RootCommand();
            cmd.AddCommand(Helloworld());
            cmd.AddCommand(SalutaConNome());
            return await cmd.InvokeAsync(args);
        }

        private static Command Helloworld()
        {
            var cmd = new Command("saluta", "Saluta l'interlocutore");
            cmd.Handler = CommandHandler.Create(() =>
            {
                Console.WriteLine("Ciao");
            });
            return cmd;
        }

        private static Command SalutaConNome()
        {
            var cmd = new Command("salutawname", "Saluta l'interlocutore chiamandolo per nome");
            cmd.AddOption(new Option(new[] { "--name", "n" }, "Salutare con il nome")
            {
                Argument = new Argument<String>
                {
                    Arity = ArgumentArity.ExactlyOne
                }
            });
            cmd.Handler = CommandHandler.Create<string>((name) =>
            {
                Console.WriteLine($"Ciao {name}");
            });
            return cmd;
        }
    }
}
