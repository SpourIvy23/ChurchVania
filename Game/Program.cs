using System;

class Program
{
    static void Main()
    {
        int menu;
        bool play = true;


        while (play)
        {
            System.Console.WriteLine("-MENU- \n" +
            "1-Iniciar \n" +
            "2-Sair \n" +
            "Escolha");
            int.TryParse(Console.ReadLine(), out menu);
            switch (menu)
            {
                case 1:
                    System.Console.WriteLine("Iniciando jogo!");
                    Introducao();

                    break;
                case 2:
                    System.Console.WriteLine("Fechando jogo...");
                    play = false;
                    break;
            }
        }

    }

    static void Introducao()
    {
        string? player;
        int dialogo;
        bool progressao = true;
        Console.Clear();
        
        System.Console.WriteLine("Insira seu nome...");
        player = Console.ReadLine();
        Console.Clear();
        
          System.Console.WriteLine("Seu nome é " + player + " Você é um aventureiro que veio investigar suposta aparição de monstros em uma vila do inteiror \n" +
        "Quando você chega na vila você consegue observar o estado decaído da vila, as casas parecem ter sido recentemente queimadas e poucas pessoas parecem ter sobrevivido \n" +
        "Talvez você devesse conversar com eles");
        while (progressao)
        {
            System.Console.WriteLine("Escolha oque fazer ou com quem conversar: \n" +
             "1-Alice A Padeira \n" +
            "2-Joanna A Artista \n" +
            "3-Vasconzelos O Artista Marcial \n" +
            "4-Ir atrás do culpado");

            int.TryParse(Console.ReadLine(), out dialogo);
            switch (dialogo)

            {
                case 1:
                    Console.Clear();
                    System.Console.WriteLine("Alice:Eu sou a padeira da cidade! \n" +
                "Sou a padeira da cidade, mas infelizemente por causa dessas guerras eu perdi meus clientes");
                    break;


                case 2:
                    Console.Clear();
                    System.Console.WriteLine("Joanna:Oi, eu sou a artista famosa da cidade.\n" +
                 "Depois desse acontecimento eu estou sem dinheiro pra comprar tinta");
                    break;

                case 3:
                    Console.Clear();
                    System.Console.WriteLine("Vasconzelos:Olá, me chamo Ag sou o mestre de artes marciais. \n" +
                "Depois disso tudo, eu perdi alguns alunos que foram simbora da cidade...");
                    break;
                case 4:
                    Console.Clear();
                    System.Console.WriteLine("Você vai em busca do culpado \n" +
                "Você consegue ver uma igreja gigantesca no centro da cidade..com nuvens negras voando em volta dela \n"
                + "É para lá que você deve ir");
                    progressao = false;
                    break;

            }

        }
            System.Console.WriteLine("Ao entrar na igreja você nota um pequeno goblin vindo em sua direção \n" +
            "AG:Boa tarde aventureiro!!! meu nome é AG mas porfavor não se assuste com minha aparencia..");
            Console.ReadLine();
            System.Console.WriteLine("Eu fui transformado nessa criatura terrivel por um feiticeiro maligno!");
            Console.ReadLine();
            System.Console.WriteLine("Eu estou aqui para guiar você durante essa terrivel e perigosa jornada..");
    }
}
