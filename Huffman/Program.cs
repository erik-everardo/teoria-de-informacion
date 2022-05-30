using System.Text;
using Huffman;

Dictionary<string,int> SymbolsOccurrence(string text, bool spaces)
{
    var characters = new Dictionary<string, int>();

    foreach (var character in text)
    {
        if (characters.ContainsKey(character.ToString()))
        {
            characters[character.ToString()] += 1;
        }
        else
        {
            characters.Add(character.ToString(),1);
        }
    }

    if (spaces) return characters;
    
    if (characters.ContainsKey(" "))
    {
        characters.Remove(" ");
    }

    return characters;
}

Dictionary<char, double> Frequencies(Dictionary<char, int> occurrences, int numberOfCharacters)
{
    var frequencies = new Dictionary<char, double>();
    foreach (var (character, times) in occurrences)
    {
        frequencies.Add(character, times/(numberOfCharacters * 1.0D));
    }

    return frequencies;
}


Console.WriteLine("Contar espacios? s=si");
var spaces = Console.ReadKey().Key == ConsoleKey.S;
Console.WriteLine("\nIngrese el texto");
var text = Console.ReadLine();
if (text == null || string.IsNullOrWhiteSpace(text))
{
    Console.WriteLine("El texto no puede ser nulo o vacío");
    return;
}

var symbolsOccurrence = SymbolsOccurrence(text.ToLower().Trim(), spaces);


// Initial nodes are the leafs
var nodes = symbolsOccurrence
    .Select(symbolOccurrence => new Node() { 
        Valor = new Dictionary<string, int>()
        {
            { symbolOccurrence.Key, symbolOccurrence.Value }
        } 
    }).OrderBy(node => node.NodeWeight()).ToList();

Console.WriteLine(nodes.Count);


var i = 0;
while (true)
{
    if (nodes.Last().NodeWeight() == (spaces ? text.Length : text.Replace(" ", string.Empty).Length))
    {
        Console.WriteLine($"Peso total: {nodes.Last().NodeWeight()}");
        break;
    }
    var nodeToAdd = new Node()
    {
        HijoIzquierdo = nodes[i],
        HijoDerecho = nodes[i + 1]
    };
    nodes[i].Padre = nodeToAdd;
    nodes[i + 1].Padre = nodeToAdd;
    nodeToAdd.Valor = new Dictionary<string, int>()
    {
        {
            nodes[i].Valor.First().Key + nodes[i + 1].Valor.First().Key,
            nodes[i].Valor.First().Value + nodes[i + 1].Valor.First().Value
        }
    };
    nodes.Add(nodeToAdd);
        
    i += 2;
    
    nodes = nodes.OrderBy(node => node.NodeWeight()).ToList();
}


nodes.Last().PrintRecursively();