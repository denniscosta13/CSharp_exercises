namespace ExercicioUm;

class ex001_4
{
    public static void ContaLetras()
    {
        Console.WriteLine("Digita uma palavra ou frase para contar as letras: ");
        string frase = Console.ReadLine();
        Console.WriteLine(frase.Replace(" ", "").Length);
    }
        
}