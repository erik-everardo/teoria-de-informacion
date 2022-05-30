namespace LZ77Demo;

public class WindowSpecs
{
    public WindowSpecs(int inputLength)
    {
        HistoryLength = inputLength switch
        {
            <= 30 => 5,
            <= 60 => 8,
            <= 100 => 10,
            <= 200 => 13,
            _ => 15
        };
        LookaheadLength = inputLength switch
        {
            <= 30 => 3,
            <= 60 => 4,
            <= 100 => 5,
            <= 200 => 6,
            _ => 7
        };
    }
    
    public int HistoryLength { get; }
    public int LookaheadLength { get; }
}