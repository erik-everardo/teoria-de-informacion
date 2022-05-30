namespace LZ77Demo;

public class Token
{
    public int Offset { get; set; }
    public int Length { get; set; }
    public char? Character { get; set; }

    public override string ToString()
    {
        return $"({Offset}, {Length}, {Character})";
    }
}