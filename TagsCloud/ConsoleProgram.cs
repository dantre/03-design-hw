namespace WordsCloud
{
    public class ConsoleProgram
    {
        private const string Usage =
        @"Usage: my_program [-i FILE]

        -h --help    show this
        -i FILE      specify output file [default: ./test.txt]
        --quiet      print less text
        --verbose    print more text

        ";

        private string[] args;

        public ConsoleProgram(string[] args)
        {
         //   var arguments = new Docopt().Apply(Usage, args);
        }
    }
}