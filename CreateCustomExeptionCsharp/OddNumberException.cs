using System;

namespace CreateCustomExeptionCsharp;

public class OddNumberException : Exception
{
    public override string Message
    {
        get
        {
            return "Divisor Cannot be Odd Number";
        }
    }

    public override string HelpLink {
        get
        {
            return "Get More Information from here: https://google.com";
        }
    }
}
