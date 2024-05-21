namespace ExercicioUm;

class ex001_3
{
    public static void Operacoes(double val1, double val2)
    {
        double valor1, valor2;
        valor1 = val1;
        valor2 = val2;

        double soma = Somar(valor1, valor2);
        double subtracao = Subtrair(valor1, valor2);
        double multiplicacao = Multiplicar(valor1, valor2);
        double divisao = Dividir(valor1, valor2);
        double media = Media(valor1, valor2);

        Console.WriteLine($"Soma = {soma}\nSubtração = {subtracao}\nMultiplicação = {multiplicacao}\nDivisão = {divisao}\nMédia = {media}");
    }

    static double Somar(double val1, double val2)
    {
        return val1 + val2;
    }

    static double Subtrair(double val1, double val2)
    {
        return val1 - val2;
    }

    static double Multiplicar(double val1, double val2)
    {
        return val1 * val2;
    }

    static double Dividir(double val1, double val2)
    {
        if (val2 == 0)
        {
            Console.WriteLine("Impossível dividir por zero.");
            return 0;
        }

        return val1 / val2;
    }

    static double Media(double val1, double val2)
    {
        return (val1 + val2) / 2.0;
    }
}