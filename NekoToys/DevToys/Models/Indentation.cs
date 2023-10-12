namespace NekoToys.DevToys.Models;

public enum Indentation
{
    TwoSpaces,
    FourSpaces,
    OneTab,
    Minified,
}

public static class IndentationExtensions
{
    public static string ToIndentationString(this Indentation indentation)
    {
        return indentation switch
        {
            Indentation.TwoSpaces => "  ",
            Indentation.FourSpaces => "    ",
            Indentation.OneTab => "\t",
            Indentation.Minified => "",
            _ => throw new NotSupportedException()
        };
    }

    public static int ToSpaceCount(this Indentation indentation)
    {
        return indentation switch
        {
            Indentation.TwoSpaces => 2,
            Indentation.FourSpaces => 4,
            Indentation.OneTab => 1,
            Indentation.Minified => 0,
            _ => throw new NotSupportedException(),
        };
    }
}