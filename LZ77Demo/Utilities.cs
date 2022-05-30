namespace LZ77Demo;

public class Utilities
{
    /// <summary>
    /// Method <c>History</c> returns the history
    /// <param name="text">The whole text to analyze</param>
    /// <param name="cursor">The point to start analyzing backwards</param>
    /// <param name="historyLength">The max-length the history buffer can be. If 0 index is reached then the return value will be shorter than this.</param>
    /// </summary>
    public static string History(string text, int cursor, int historyLength)
    {
        var startIndex = cursor - historyLength;
        if (startIndex < 1)
        {
            return text;
        }

        
        return text.Substring(startIndex, historyLength);
    }

    /// <summary>
    /// Method <c>LookAhead</c> returns the history
    /// <param name="text">The whole text to analyze</param>
    /// <param name="cursor">The point to start analyzing forwards</param>
    /// <param name="lookaheadLength">The max-length the lookahead can be. If the end of the text is reach then it will be shorter</param>
    /// </summary>
    public static string LookAhead(string text, int cursor, int lookaheadLength)
    {
        try
        {
            return text.Substring(cursor, lookaheadLength);
        }
        catch (ArgumentOutOfRangeException)
        {
            return text[cursor..];
        }
        
    }
    

    public static Token Token(string history, string lookahead)
    {
        if (!history.Contains(lookahead[0]))
        {
            return new Token()
            {
                Offset = 0,
                Length = 0,
                Character = lookahead[0]
            };
        }

        var firstCharOccurrences = new List<int>();

        for (var i = 0; i < history.Length; i++)
        {
            if (history[i] == lookahead[0])
            {
                firstCharOccurrences.Add(i);
            }
        }

        var matches = new List<Token>();
        
        firstCharOccurrences.ForEach(index =>
        {
            var missmatch = false;
            var i = 0;
            var substring = "";
            try
            {
                substring = history.Substring(index, lookahead.Length);
            }
            catch (ArgumentOutOfRangeException)
            {
                substring = history[index..];
            }

            while (!missmatch)
            {
                missmatch = lookahead[i] != substring[i];
                
                i++;
                if (i >= lookahead.Length)
                {
                    break;
                }
            }
            matches.Add(new Token()
            {
                Offset = history.Length - index,
                Length = i,
                Character = substring.Length == lookahead.Length ? null : lookahead[i]
            });
        });

        return matches.MaxBy(match => match.Length);
    }
}