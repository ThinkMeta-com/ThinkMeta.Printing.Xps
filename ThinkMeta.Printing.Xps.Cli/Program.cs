namespace ThinkMeta.Printing.Xps.Cli;

internal static class Program
{
    [STAThread]
    private static void Main(string[] args)
    {
        XpsPrinter.Print(args[0], args[1]);
    }
}