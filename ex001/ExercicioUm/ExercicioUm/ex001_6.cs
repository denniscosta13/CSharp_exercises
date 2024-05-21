namespace ExercicioUm;

class ex001_6
{
    public static void FormatarData()
    {


        Console.WriteLine(
        @"Escolha o formato da data: 
        1 - Formato Completo
        2 - Apenas a data (01/01/1901)
        3 - Hora (24h)
        4 - Data com mês por extenso
        0 - Sair");

        int opcao = Int32.Parse(Console.ReadLine());
        DateTime dataAtual = DateTime.Now;
        
        switch (opcao)
        {
            case 1:
                Console.WriteLine(dataAtual.ToString("dd/MM/yyyy H:mm:ss"));
                break;
            case 2:
                Console.WriteLine(dataAtual.ToString("dd/MM/yyyy"));
                break;
            case 3:
                Console.WriteLine(dataAtual.ToString("H:mm:ss"));
                break;
            case 4:
                Console.WriteLine(dataAtual.ToString("dd-MMMM-yyyy"));
                break;
            default:
                Console.WriteLine("Opção inválida.");
                break;
        }
    }   
}