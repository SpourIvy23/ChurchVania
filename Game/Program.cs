using System;


class Program
{
    //drop dos itens
    static bool[] eventosConcluidos = new bool[7];

    //Negocio pro inventario
    static string[] nomesItens = new string[10];
    static int[] quantidadesItens = new int[10];
    static int contadorItens = 0;
    //Equipamentos
    static string[] nomesEquipamentos = new string[10];
    static int contadorEquipamentos = 0;

    static string equipamentoAtual = "";
    //Buffs e Debuffs
    static int forcaBase = 50;
    static int velocidadeBase = 50;
    static int bonus = 0;
    static int penalidade = 0;


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
                    Tutorial();
                    PrimeiroAndar();

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
                    if (!eventosConcluidos[0])
                    {
                        System.Console.WriteLine("Alice:Eu sou a padeira da cidade! \n" +
                    "Sou a padeira da cidade, mas infelizemente por causa dessas guerras eu perdi meus clientes.. \n" +
                    "O terivel monstro queimou todos eles!!");
                        System.Console.WriteLine("A padeira te entregou 3 pedaços de pão");
                        Console.ReadLine();
                        Inventory("Pão", 3);
                        eventosConcluidos[0] = true;
                    }
                    else
                    {   
                        Console.Clear();
                        System.Console.WriteLine("Alice:Era tudo que eu tinha..");
                        Console.ReadLine();
                    }
                    break;


                case 2:
                    Console.Clear();
                    if (!eventosConcluidos[1])
                    {
                        System.Console.WriteLine("Joanna:Oi, eu sou a artista famosa da cidade.\n" +
                     "Depois desse acontecimento eu estou sem dinheiro pra comprar tinta");
                        System.Console.WriteLine("Você conseguiu 1 tinta preta da artista");
                        Console.ReadLine();
                        Inventory("Tinta", 1);
                        eventosConcluidos[1] = true;
                    }
                    else
                    {
                        Console.Clear();
                        System.Console.WriteLine("Joanna:Só tinha isso de tinta");
                        Console.ReadLine();
                    }
                    break;

                case 3:
                    if (!eventosConcluidos[2])
                    {
                        Console.Clear();
                        System.Console.WriteLine("Vasconzelos:Olá, me chamo Ag sou o mestre de artes marciais. \n" +
                    "Depois disso tudo, eu perdi alguns alunos que foram simbora da cidade...");
                        System.Console.WriteLine("Você conseguiu uma kunai do artista marcial");
                        Console.ReadLine();
                        Equip("Kunai");
                        eventosConcluidos[2] = true;
                    }
                    else
                    {
                        System.Console.WriteLine("Vasconzelos:Essa era minha ultima kunai..boa sorte!!");
                        Console.ReadLine();
                    }
                    break;
                case 4:
                    Console.Clear();
                    System.Console.WriteLine("Você vai em busca do culpado \n" +
                "Você consegue ver uma igreja gigantesca no centro da cidade..com nuvens negras voando em volta dela \n"
                + "É para lá que você deve ir");
                    Console.ReadLine();
                    progressao = false;
                    break;

            }

        }
        System.Console.WriteLine("Ao entrar na igreja você nota um pequeno goblin vindo em sua direção \n" +
        "AG:Boa tarde aventureiro!!! meu nome é AG mas porfavor não se assuste com minha aparencia..");
        Console.ReadLine();
        System.Console.WriteLine("Eu fui transformado nessa criatura terrivel por um feiticeiro maligno!");
        Console.ReadLine();
        System.Console.WriteLine("Eu estou aqui para guiar você durante essa terrivel e perigosa jornada...");

    }



    static void Tutorial()
    {
        Console.Clear();
        System.Console.WriteLine("AG:Irei ensinar você como o menu funciona! \n" +
        "Durante sua aventura você pode encontrar itens que podem vir a ser úteis na sua jornada para derrotar o grande feiticeiro maligno \n"
        + "Observe! ");
        Console.ReadLine();
        Menu();
        System.Console.WriteLine("AG:Esses itens podem vir a ser úteis para você no futuro..E você pode achar muito aqui dentro!");
        Console.ReadLine();
        System.Console.WriteLine("Dentro desta igreja há 3 andares contando com este..cada um tem 3 salas que você pode explorar!");
        Console.ReadLine();
        System.Console.WriteLine("Boa sorte aventureiro!!!!!!");
        Console.ReadLine();

    }

    static void PrimeiroAndar()
    {
        int escolha;
        bool progressao = true;
        Console.Clear();
        Console.WriteLine("Você se encontra em uma sala gigantesca, na esquerda e na direita  possuem portas chiques de madeira que levam a outros comodos e uma escada gigantesca no meio das portas");
        Console.ReadLine();
        while (progressao)
        {

            System.Console.WriteLine("Escolha oque fazer \n" +
            "1-Sala da esquerda \n" +
            "2-Sala da direita \n" +
            "3-Escadas \n" +
            "4-Abir Menu");
            int.TryParse(Console.ReadLine(), out escolha);
            switch (escolha)
            {
                case 1:
                    Sala1();
                    break;
                case 2:
                    Sala2();
                    break;
                case 3:
                    System.Console.WriteLine("Você encontra as escadas que levam para o segundo andar, elas estão bloqueadas por um portão");
                    Console.ReadLine();
                    if (ItemChave("Chave Amaldiçoada"))
                    {
                        System.Console.WriteLine("Felizmente você tem a chave certa para abrir esses portões! você a usa e sobe");
                        Console.ReadLine();
                        progressao = false;
                    }
                    else
                    {
                        System.Console.WriteLine("Parece que você vai precisar achar uma chave para abrir esse portão..");
                        Console.ReadLine();
                    }
                    break;
                case 4:
                    Menu();
                    break;
            }

        }
    }
    static void Sala1()
    {
        int escolha;
        bool progressao = true;

        Console.Clear();
        System.Console.WriteLine("Você entra na sala da esquerda e se dá de cara com um comodo antigo com um tapete vermelho no chão" +
        "Os materiais parecem ser de uma epoca antiga mas supreendentemente parecem ainda estar em bom estado..será isso obra do feiticeiro?");
        Console.ReadLine();
        while (progressao)
        {
            Console.WriteLine("O que vai fazer agora? \n" +
            "1-Explorar em baixo do tapete \n" +
            "2-Explorar os móveis antigos \n" +
            "3-Abir Menu \n" +
            "4-Voltar");
            int.TryParse(Console.ReadLine(), out escolha);
            switch (escolha)
            {
                case 1:
                if(!eventosConcluidos[3])
                {
                    System.Console.WriteLine("Você encontra um saco cheio de moedas preciosas..Talvez elas possam vir a úteis");
                    Console.ReadLine();
                    Inventory("Moedas", 5);
                    eventosConcluidos[3] = true;
                }
                else
                {
                    Console.Clear();
                    System.Console.WriteLine("Só sobrou poeira..");
                    Console.ReadLine();
                }
                    break;
                case 2:
                if(!eventosConcluidos[4])
                {
                    System.Console.WriteLine("Você encontrou uma chave velha..");
                    Console.ReadLine();
                    Inventory("Chave Suspeita", 1);
                    eventosConcluidos[4] = true;
                }
                else
                {   Console.Clear();
                    System.Console.WriteLine("Você só conseguiu achar teias de aranhas");
                    Console.ReadLine();
                }
                    break;
                case 3:
                    Menu();
                    break;
                case 4:
                    progressao = false;
                    break;
            }
        }
    }
    static void Sala2()
    {
        int escolha;
        bool stay = true;
        Console.Clear();
        System.Console.WriteLine("Você encontra uma sala esquisita, ela tem uma porta velha nos fundos e algumas prateleiras de madeira velha a sua esquerda ");
        while (stay)
        {
            System.Console.WriteLine("O que vai fazer agora? \n" +
            "1-Tentar abrir porta \n" +
            "2-Vasculhar pratileiras \n" +
            "3-Abrir Menu \n" +
            "4-Sair da sala");
            int.TryParse(Console.ReadLine(), out escolha);
            switch (escolha)
            {
                case 1:
                    if (!eventosConcluidos[5])
                    {
                    if (ItemChave("Chave Suspeita"))
                    {
                        System.Console.WriteLine("Você conseguiu abrir a porta!!");
                        Console.ReadLine();
                        System.Console.WriteLine("Você se encontra numa sala velha cheia de teias com um esqueleto segurando uma chave com um olho nela");
                        Console.ReadLine();
                        Inventory("Chave Amaldiçoada", 1);
                        eventosConcluidos[5] = true;
                    }
                    else
                    {
                        System.Console.WriteLine("A porta está trancada..parece que precisa de uma chave");
                        Console.ReadLine();
                    }
                    }
                    else
                    {
                        Console.Clear();
                        System.Console.WriteLine("O esqueleto parece ser recente.");
                        Console.ReadLine();
                    }
                    break;
                case 2:
                    if (!eventosConcluidos[6])
                    {
                    System.Console.WriteLine("Você encontra uma espada jogada perto da pratileira!");
                    Console.ReadLine();
                    Equip("Espada");
                    eventosConcluidos[6] = true;
                    }
                    else
                    {
                        Console.Clear();
                        System.Console.WriteLine("Você só consegue ver fotos antigas de pessoas que você não conhece na pratileira");
                        System.Console.ReadLine();
                    }
                    break;
                case 3:
                    Menu();
                    break;
                case 4:
                    stay = false;
                    break;

            }
        }
    }

    //Menu Ingame
    static void Menu()
    {
        int ingamemenu;
        bool stay = true;
        while (stay)
        {
            System.Console.WriteLine("1-Status \n" +
            "2-Inventario \n" +
            "3-Equipar item \n" +
            "4-Sair");

            int.TryParse(Console.ReadLine(), out ingamemenu);
            switch (ingamemenu)
            {
                case 1:
                    Console.Clear();
                    Status();
                    Console.ReadLine();
                    break;
                case 2:
                    Console.Clear();
                    ListarItens();
                    Console.ReadLine();
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("Digite o nome do item que deseja equipar:");
                    string? equipamento = Console.ReadLine()?.ToLower(); // Converter para minúsculas

                    if (!string.IsNullOrEmpty(equipamento))
                    {
                        EquiparItem(equipamento); // Tenta equipar o item
                    }
                    else
                    {
                        Console.WriteLine("Nenhum equipamento foi selecionado.");
                    }
                    break;

                case 4:
                    stay = false;
                    break;
            }
        }
    }
    static void Status()
    {
        int forçaTotal = forcaBase + bonus;
        int velocidadeTotal = velocidadeBase - penalidade;
        int vida = 100, defesa = 40;
        Console.WriteLine("Seus status são \n" +
        "VIDA: " + vida + "\n" +
        "FORÇA: " + forçaTotal + "\n" +
        "DEFESA: " + defesa + "\n" +
        "VELOCIDADE: " + velocidadeTotal);

        Console.ReadLine();
    }
    static void Inventory(string nome, int quantidade)
    {

        if (contadorItens < nomesItens.Length)
        {
            nomesItens[contadorItens] = nome;
            quantidadesItens[contadorItens] = quantidade;
            contadorItens++;
            Console.WriteLine($"{nome} (x{quantidade}) foi adicionado ao inventário.");
        }
        else
        {
            Console.WriteLine("Inventário cheio! Não é possível adicionar mais itens.");
        }
    }
    static bool ItemChave(string itemChave)
    {
        for (int i = 0; i < contadorItens; i++)
        {
            if (nomesItens[i] == itemChave)
            {
                return true;
            }

        }
        return false;





    }
    static void ListarItens()
    {
        Console.WriteLine("Itens no inventário:");
        for (int i = 0; i < contadorItens; i++)
        {
            Console.WriteLine($"{nomesItens[i]} (x{quantidadesItens[i]})");
        }
        System.Console.WriteLine("\nEquipamentos no inventário:");
        for (int i = 0; i < contadorEquipamentos; i++)
        {
            Console.WriteLine(nomesEquipamentos[i]);
        }
    }

    static void Equip(string nome)
    {
        nome = nome.ToLower(); // Converter o nome do equipamento para minúsculas
        if (contadorEquipamentos < nomesEquipamentos.Length)
        {
            nomesEquipamentos[contadorEquipamentos] = nome; // Armazena o nome em minúsculas
            contadorEquipamentos++;
            Console.WriteLine($"{nome} foi adicionado ao seu inventário de equipamentos.");
        }
        else
        {
            Console.WriteLine("Inventário de equipamentos cheio! Não foi possível adicionar o equipamento.");
        }
    }

    static void EquiparItem(string equipamento)
    {
        equipamento = equipamento.ToLower(); // Converter para minúsculas

        if (EquipChave(equipamento)) // Verifica se o equipamento existe no inventário
        {

            if (!string.IsNullOrEmpty(equipamentoAtual))
            {
                RemoverBonus(equipamentoAtual); // Remove bônus do equipamento atual
                Console.WriteLine($"{equipamentoAtual} desequipado.");
            }

            // Aplica o bônus e define o equipamento atual
            switch (equipamento)
            {
                case "espada":
                    bonus = 20;
                    penalidade = 0;
                    equipamentoAtual = "espada";
                    Console.WriteLine("Você equipou a Espada. +20 de força!");
                    break;

                case "machado":
                    bonus = 30;
                    penalidade = 10;
                    equipamentoAtual = "machado";
                    Console.WriteLine("Você equipou o Machado. +30 de força e -10 de velocidade!");
                    break;

                case "kunai":
                    bonus = 10;
                    penalidade = 0;
                    equipamentoAtual = "kunai";
                    Console.WriteLine("Você equipou a Kunai. +10 de força!");
                    break;

                default:
                    Console.WriteLine("Este item não pode ser equipado.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Você não tem este equipamento no inventário.");
        }
    }

    static void RemoverBonus(string equipamento)
    {
        switch (equipamento)
        {
            case "espada":
                bonus = 0;
                penalidade = 0;
                break;
            case "machado":
                bonus = 0;
                penalidade = 0;
                break;
            case "kunai":
                bonus = 0;
                penalidade = 0;
                break;

        }
    }
    static bool EquipChave(string equipamento)
    {
        equipamento = equipamento.ToLower();
        for (int i = 0; i < contadorEquipamentos; i++)
        {
            if (nomesEquipamentos[i].ToLower() == equipamento)
            {
                return true;
            }
        }
        return false;
    }


}



