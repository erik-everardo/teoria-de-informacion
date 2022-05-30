namespace Huffman;


public class Node
{
    // la clave es la concatenacion de los caracteres y el valor es el peso de todos juntos
    public Dictionary<string, int> Valor { get; set; }
    public Node? Padre { get; set; }
    public Node? HijoIzquierdo { get; set; }
    public Node? HijoDerecho { get; set; }

    public override string ToString()
    {
        return $" \n{Valor.First().Key}  {HijoIzquierdo?.Valor.First().Key ?? ""}  {HijoDerecho?.Valor.First().Key ?? ""}";
    }
    
    public int NodeWeight()
    {
        var peso = 0;
        foreach (var (k,v) in Valor)
        {
            peso += v;
        }

        return peso;
    }

    public void PrintRecursively()
    {
        Console.Write(ToString());
        HijoDerecho?.PrintRecursively();
        HijoIzquierdo?.PrintRecursively();
    }

    public void Encode(char character)
    {
        var accumulated = "";
        if (Padre != null)
        {
            Padre.Encode(character);
        }

        Console.Write(HijoDerecho?.Valor.First().Key.Contains(character) == true ? "1" : "0");
        

    }
}