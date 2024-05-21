namespace ExercicioUm;

class ex001_2
{
    public static void Nome()
    {
        Console.WriteLine("Digite o seu nome: ");
        string nome = Console.ReadLine();
        Console.WriteLine("Digite o seu sobrenome: ");
        string sobrenome = Console.ReadLine();

        Console.WriteLine($"{nome} {sobrenome}");

    }
}