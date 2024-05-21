namespace ExercicioUm;

class ex001_5
{
    public static void PlacaDeCarro()
    {
        Console.WriteLine("Digita a placa de carro. Sem espaços ou hífen.");
        string placa = Console.ReadLine();

        if (placa.Length != 7)
        {
            Console.WriteLine("Placa digitada não tem 7 dígitos.");
            return;
        }

        string placaLetras = placa.Substring(0, 3);
        string placaNum = placa.Substring(placa.Length - 4, 4);

        foreach (char numero in placaNum)
        {
            if (!Char.IsNumber(numero))
            {
                Console.WriteLine("Placa inválida. Os últimos 4 digitos não são só números.");
                return;
            }
        }

        foreach (char letra in placaLetras)
        {
            if(!Char.IsLetter(letra))
            {
                Console.WriteLine("Placa inválida. Os primeiros 3 digitos não são só letras.");
                return;
            }
        }
        Console.WriteLine("Placa válida!");

    }
        
}