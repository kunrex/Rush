using Rush.Interpreter;

Interpreter interpreter = new Interpreter();

while (true)
{
    var input = Console.ReadLine();
    if(input == null)
        continue;

    if (input == "exit")
        return;

    Console.WriteLine(interpreter.Input(input));
}