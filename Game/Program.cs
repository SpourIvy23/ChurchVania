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
        bool progressão;
        Console.Clear();
        
        System.Console.WriteLine("Insira seu nome...");
        player = Console.ReadLine();
        Console.Clear();
        
        System.Console.WriteLine("Seu nome é " + player + " Você é um aventureiro que veio investigar suposta aparição de monstros em uma vila do inteiror \n" +
        "Quando você chega na vila você consegue observar o estado decaído da vila, as casas parecem ter sido recentemente queimadas e poucas pessoas parecem ter sobrevivido \n" +
        "Talvez você devesse conversar com eles.. \n" +
        "1-Alice A Padeira \n" +
        "2-Joanna A Artista \n" +
        "3-AG O Artista Marcial");
        int.TryParse(Console.ReadLine(), out dialogo);
        switch (dialogo)
        {
            case 1: System.Console.WriteLine("Alice:Eu sou a padeira da cidade!");
        }
        
    }
}
