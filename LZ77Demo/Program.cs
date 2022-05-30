using System;
using LZ77Demo;

/*
LZ77
abcddbaebcd
[-----][---]
history/lookahead
El historico debe ser mucho más grande que el lookahead
*/

Console.WriteLine("Input text");
var input = Console.ReadLine();

if (input == null)
{
    return;
}

var windowSpecs = new WindowSpecs(input.Length);
var tokens = new List<Token>();

// This value is the cursor
var i = 0;
while (i < input.Length)
{
    var history = Utilities.History(input, i, windowSpecs.HistoryLength);
    var lookahead = Utilities.LookAhead(input, i, windowSpecs.LookaheadLength);

    var token = Utilities.Token(history, lookahead);
    tokens.Add(token);

    i += token.Length + 1;
}

tokens.ForEach(token =>
{
    Console.WriteLine(token.ToString());
});
