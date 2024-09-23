using System;


class Program
{
    static bool play = true;
    static Random random = new Random();

    //drop dos itens
    static bool[] eventosConcluidos = new bool[15];

    //Negocio pro inventario
    static string[] nomesItens = new string[10];
    static int[] quantidadesItens = new int[10];
    static int contadorItens = 0;
    //Equipamentos
    static string[] nomesEquipamentos = new string[10];
    static int contadorEquipamentos = 0;

    static string equipamentoAtual = "";
    //Atributos + Buffs e Debuffs
    static int vida = 100;
    static int defesa = 40;
    static int forcaBase = 50;
    static int velocidadeBase = 20;
    static int bonus = 0;
    static int penalidade = 0;
    static int forçaTotal = forcaBase + bonus;
    static int velocidadeTotal = velocidadeBase - penalidade;
    //Inimigos
    static int danoRaquel = 15;


    static void Main()
    {
        int menu;
        


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
                    SegundoAndar();

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
                        Console.ReadLine();
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
                        Console.ReadLine();
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
                        Console.ReadLine();
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
                    if (!eventosConcluidos[3])
                    {
                        System.Console.WriteLine("Você encontra um saco cheio de moedas preciosas..Talvez elas possam vir a úteis");
                        Console.ReadLine();
                        Inventory("Moedas", 5);
                        Console.ReadLine();
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
                    if (!eventosConcluidos[4])
                    {
                        System.Console.WriteLine("Você encontrou uma chave velha..");
                        Console.ReadLine();
                        Inventory("Chave Suspeita", 1);
                        Console.ReadLine();
                        eventosConcluidos[4] = true;
                    }
                    else
                    {
                        Console.Clear();
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
                            Console.ReadLine();
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
                        Console.ReadLine();
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

    static void SegundoAndar()
    {
        int escolha;
        bool progressao = true;
        while (progressao)
        {
            System.Console.WriteLine("Você sobe as escadas para o segundo andar \n" +
            "Uma cheia de fileiras de bancos aonde as pessoas provavelmente vinham para ouvir o padre \n" +
            "Há uma porta atrás do púlpito, o lugar aonde devia estar o padre e duas portas em cada lateral da sala \n");
            Console.ReadLine();
            System.Console.WriteLine("Escolha oque fazer \n" +
            "1-Entrada da esquerda \n" +
            "2-Entrada da direita \n" +
            "3-Porta do meio \n" +
            "4-Abrir Menu");
            int.TryParse(Console.ReadLine(), out escolha);
            switch (escolha)
            {
                case 1:
                    Sala4();
                    break;
                case 2:
                    Sala5();
                    break;
                case 3:
                    Sala6();
                    progressao = false;
                    break;
                case 4:
                    Menu();
                    break;
            }
        }

    }
    static void Sala4()
    {
        int escolha;
        bool progressao = true;
        while (progressao)
        {
            System.Console.WriteLine("Você se encontra numa parte escura da igreja aonde várias sacolas brancas amarradas em uma forca cada uma delas tem um alvo no meio \n" +
            "O que você fará agora? \n" +
            "1-Atirar em um do alvos \n" +
            "2-Investigar as forcas \n" +
            "3-Abrir Menu \n" +
            "4-Voltar");
            int.TryParse(Console.ReadLine(), out escolha);
            switch (escolha)
            {
                case 1:
                    if (!eventosConcluidos[7])
                    {
                        if (equipamentoAtual == "kunai" || equipamentoAtual == "pistola")
                        {
                            Console.Clear();
                            System.Console.WriteLine("Você atirou no alvo usando " + equipamentoAtual + "!");
                            Console.ReadLine();
                            System.Console.WriteLine("Você escuta um grito de dor profundo vindo da sacola na qual você atirou \n" +
                            "A sacola se debate por alguns segundos antes de parar e você escuta um susurro em seu ouvido \n" +
                            "Pegue sua recompensa");
                            Console.ReadLine();
                            Inventory("Moedas", 10);
                            Console.ReadLine();
                            eventosConcluidos[7] = true;
                        }
                        else
                        {
                            Console.Clear();
                            System.Console.WriteLine("Talvez você precise de uma arma de longa distancia..");
                            Console.ReadLine();
                        }
                    }
                    else
                    {
                        Console.Clear();
                        System.Console.WriteLine("Você vai ser assombrado por isso pelo resto de sua vida");
                        Console.ReadLine();
                    }
                    break;
                case 2:
                    if (!eventosConcluidos[8])
                    {
                        Console.Clear();
                        System.Console.WriteLine("Você vai até atrás das forcas em busca de algo interessante..");
                        Console.ReadLine();
                        System.Console.WriteLine("...");
                        Console.ReadLine();
                        System.Console.WriteLine("Você encontrou um machado sangrento atrás das forcas..é bom levar com você");
                        Equip("Machado");
                        Console.ReadLine();
                        eventosConcluidos[8] = true;
                    }
                    else
                    {
                        Console.Clear();
                        System.Console.WriteLine("Você nem quer imaginar para oque usaram isso..");
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
    static void Sala5()
    {
        int escolha;
        bool progressao = true;
        while (progressao)
        {
            System.Console.WriteLine("Você entra no que parece ser uma catina..tem pedaços de comida jogado para lá e para cá e lá \n" +
            "O que você fará agora? \n" +
                "1-Vasculhar o lixo \n" +
                "2-Procurar por suplimentos \n" +
                "3-Abrir Menu \n" +
                "4-Voltar");
            int.TryParse(Console.ReadLine(), out escolha);
            switch (escolha)

            {
                case 1:
                    if (!eventosConcluidos[9])
                    {
                        Console.Clear();
                        System.Console.WriteLine("Você vascula o lixo e entre um monte de esqueletos e lixo você encontra 5 moedas!");
                        Console.ReadLine();
                        Inventory("Moedas", 5);
                        Console.ReadLine();
                        eventosConcluidos[9] = true;
                    }
                    else
                    {
                        Console.Clear();
                        System.Console.WriteLine("Só sobrou lixo, que supresa!");
                        Console.ReadLine();
                    }
                    break;
                case 2:
                    if (!eventosConcluidos[10])
                    {
                        Console.Clear();
                        System.Console.WriteLine("Você encontra um kit medico jogado no chão..parece ta um pouco sujo mas vai servir");
                        Inventory("Kit Médico", 1);
                        Console.ReadLine();
                        eventosConcluidos[10] = true;

                    }
                    else
                    {
                        Console.Clear();
                        System.Console.WriteLine("Parece que o resto dos suplimentos estão usados ou estragados");
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
    static void Sala6()
    {
        int escolha;
        {
            System.Console.WriteLine("Você entra numa sala que parece levar para as escadas do proximo andar..mas você não tem certeza se deve entrar \n" +
        "Você escuta alguns barulhos vindo de lá, e se for algo perigoso? \n" +
        "O que você fará agora? \n" +
        "1-Seguir em frente \n" +
         "2-Voltar");
            int.TryParse(Console.ReadLine(), out escolha);
            switch (escolha)
            {
                case 1:
                    Raquel();
                    break;
                case 2:
                    SegundoAndar();
                    break;
            }
        }
    }

    //BossFight Raquel
    static void Raquel()
    {
        Console.Clear();
        System.Console.WriteLine("No momento em que você vai andando em direção a escada sons de tiros saem das sombras e acertam a sua frente \n" +
        "Uma criatura de pele podre, cabelos brancos sem cor e usando oque parece ser uma jaqueta de couro para seu caminho");
        Console.ReadLine();
        System.Console.WriteLine("Zumbi:Alto lá pivete, a chefia disse pra não deixar nenhum esquisitão passar daqui \n" +
        "Zumbi:E me foi pago um bom dinheiro pra guardar esse canto aqui..");
        Console.ReadLine();
        System.Console.WriteLine("A criatura puxa oque parece ser um revolver da jaqueta e aponta para você \n" +
        "Zumbi:Isso aqui é uma farinha magica que me foi entrega pelo feiticeiro maligno ok?!");
        Console.ReadLine();
        System.Console.WriteLine("Zumbi:MAAAAS se você tivesse um pouco de grana..eu posso considerar te deixar ir..");
        if (ItemChave("Moedas"))
        {
            int escolha;

            System.Console.WriteLine("Zumbi:Que que ce acha? \n" +
            "1-Pagar \n" +
            "2-Não entregar nada \n");
            int.TryParse(Console.ReadLine(), out escolha);
            switch (escolha)
            {
                case 1:
                    Roleta();
                    break;
                case 2:
                    System.Console.WriteLine("Zumbi:Escolha errada pivete!!!");
                    Console.ReadLine();
                    BossRaquel();
                    break;
            }

        }
        else
        {
            System.Console.WriteLine("Zumbi:Pena que você é um pobretão!!");
            Console.ReadLine();
            BossRaquel();
        }
    }
    static void BossRaquel()
    {
        testeVelocidade();
        System.Console.WriteLine("Ela deixou a pistola cair..parece que é uma Magnun 357..nada mal!");
        Console.ReadLine();
        Equip("pistola");
        Console.ReadLine();
    }
    static void BossRaquel2()
    {
        Console.Clear();
        System.Console.WriteLine("Zumbi:Seu dia de sorte...dá o fora daqui logo!");
        Console.ReadLine();
    }

    static void Roleta()
    {
        int espaçosVazios = 0;
        int espacosTotais = 6;
        int[] tambor = new int[espacosTotais];
        bool progressao = true;
        int escolha;
        while (progressao)
        {
            System.Console.WriteLine("Escolha o que fazer \n" +
            "1-Pagar 5 moedas \n" +
            "2-Pagar 10 moedas \n" +
            "3-Pagar 15 moedas \n" +
            "4-Abrir Menu");
            int.TryParse(Console.ReadLine(), out escolha);
            switch (escolha)
            {
                case 1:
                    Console.Clear();
                    System.Console.WriteLine("Zumbi:Poxa..Acho que você não dá tanto valor assim pra vida");
                    Console.ReadLine();
                    Inventory("Moedas", -5);
                    Console.ReadLine();
                    System.Console.WriteLine("Ela esvaziou um dos tambores");
                    espaçosVazios = 1;
                    Console.ReadLine();
                    progressao = false;
                    break;
                case 2:
                    Console.Clear();
                    System.Console.WriteLine("Zumbi:Vamos ver se a sorte tá do seu lado..");
                    Console.ReadLine();
                    Inventory("Moedas", -10);
                    Console.ReadLine();
                    System.Console.WriteLine("Ela esvaziou dois tambores");
                    espaçosVazios = 2;
                    Console.ReadLine();
                    progressao = false;
                    break;
                case 3:
                    Console.Clear();
                    System.Console.WriteLine("Zumbi:Boa escolha pivete!");
                    Console.ReadLine();
                    Inventory("Moedas", -15);
                    Console.ReadLine();
                    System.Console.WriteLine("Ela esvaziou 3 tambores..");
                    espaçosVazios = 3;
                    Console.ReadLine();
                    progressao = false;
                    break;
                case 4:
                    Menu();
                    break;


            }


        }
        System.Console.WriteLine("Número de tambores vazio é " + espaçosVazios);
        Console.ReadLine();
        for (int i = 0; i < espacosTotais - espaçosVazios; i++)
        {
            tambor[i] = 1;
        }
        tambor = tambor.OrderBy(x => random.Next()).ToArray();
        int resultado = random.Next(0, espacosTotais);

        if (tambor[resultado] == 0)
        {
            Console.Clear();
            System.Console.WriteLine("...");
            Console.ReadLine();
            Console.WriteLine("Click.");
            Console.ReadLine();
            System.Console.WriteLine("O tambor estava vazio!");
            Console.ReadLine();
            BossRaquel2();

        }
        else
        {
            Console.Clear();
            System.Console.WriteLine("...");
            Console.ReadLine();
            Console.WriteLine("BANG!!!!");
            Console.ReadLine();
            System.Console.WriteLine("Você levou um tiro!!! \n" +
            "-15 de vida");
            Console.ReadLine();
            BossRaquel();
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
                    string? equipamento = Console.ReadLine()?.ToLower();

                    if (!string.IsNullOrEmpty(equipamento))
                    {
                        EquiparItem(equipamento);
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

        Console.WriteLine("Seus status são \n" +
        "VIDA: " + vida + "\n" +
        "FORÇA: " + forçaTotal + "\n" +
        "DEFESA: " + defesa + "\n" +
        "VELOCIDADE: " + velocidadeTotal);

        Console.ReadLine();
    }
    static void Inventory(string nome, int quantidade)
    {
        bool itemExiste = false;
        for (int i = 0; i < contadorItens; i++)
        {
            if (nomesItens[i] == nome)
            {

                quantidadesItens[i] += quantidade;
                if (quantidadesItens[i] <= 0)
                {
                    RemoverItem(i);
                    Console.WriteLine($"{nome} foi removido do inventário.");
                }
                else
                {
                    Console.WriteLine($"{nome} agora tem (x{quantidadesItens[i]}) no inventário.");
                }

                itemExiste = true;
                break;
            }
        }

        if (!itemExiste)
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
    }
    static void RemoverItem(int index)
    {
        for (int i = index; i < contadorItens - 1; i++)
        {
            nomesItens[i] = nomesItens[i + 1];
            quantidadesItens[i] = quantidadesItens[i + 1];
        }
        nomesItens[contadorItens - 1] = "";
        quantidadesItens[contadorItens - 1] = 0;
        contadorItens--;

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
                case "pistola":
                    bonus = 40;
                    penalidade = 20;
                    equipamentoAtual = "pistola";
                    System.Console.WriteLine("Você equipou a Pistola. +40 de força e -20 de velocidade!");
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


    static void testeVelocidade()
    {
        int resultadosComuns = 0;
        bool vitoria = false;
        System.Console.WriteLine("Faça testes de velocidade e não seja atingido pelas balas! \n" +
        "Regras dos testes! \n" +
        "1-Tirar um resultado abaixo de 30 será considerado uma falha! \n" +
        "2-Tirar 20 natural no teste será considerado um sucesso critico e vencerá automaticamente! \n" +
        "3-Precisa tirar 4 resultados comuns para finalizar a luta");
        Console.ReadLine();
        while (!vitoria)
        {
            System.Console.WriteLine("Realizando teste..");
            Console.ReadLine();
            int resultadoDado = random.Next(1, 21);
            int resultadoFinal = resultadoDado;
            if (resultadoDado != 20)
            {
                resultadoFinal += velocidadeTotal;
            }

            System.Console.WriteLine("Você tirou... " + resultadoFinal + "!");
            Console.ReadLine();
            if (resultadoDado == 20)
            {
                Console.Clear();
                Console.WriteLine("Um sucesso critico!!");
                Console.ReadLine();
                if (equipamentoAtual == "espada" || equipamentoAtual == "machado")
                {
                    System.Console.WriteLine("Você corta a zumbi ao meio...!!! \n");
                    Console.ReadLine();
                    System.Console.WriteLine("O corpo dela se divide e ela não consegue formar mais nenhuma palavra \n" +
                    "Mas você consegue ver claramente que ela ainda consegue se mexer..então ainda esta viva");
                    Console.ReadLine();
                    System.Console.WriteLine("Ou quase isso");
                    Console.ReadLine();
                }
                else if (equipamentoAtual == "kunai")
                {
                    System.Console.WriteLine("Você esfaqueia a zumbi freneticamente até que você decepa a mão dela com um golpe final! \n" +
                    "Ela cai dura no chão sem conseguir se mexer mais");
                    Console.ReadLine();
                    System.Console.WriteLine("Zumbi:E..EI..ISSO NÃO É JUSTO! COMO VOCÊ FEZ ISSO?!");
                    Console.ReadLine();
                }
                else
                {
                    System.Console.WriteLine("Você avança na zumbi e acerta ela com um soco certeiro no rosto a noucateando na hora");
                    Console.ReadLine();
                }
                vitoria = true;
            }
            else if (resultadoFinal < 30)
            {
                if (resultadoFinal < 20)
                {
                    
                    resultadosComuns++;
                    Console.WriteLine($"Resultado comum. Você tem {resultadosComuns} resultados comuns.");

                    // Verifica se o jogador venceu com 4 resultados comuns
                    if (resultadosComuns == 4)
                    {
                        Console.Clear();
                        Console.WriteLine("Você alcançou 4 resultados comuns e venceu!");
                        if(equipamentoAtual == "espada" || equipamentoAtual == "machado")
                        {
                            System.Console.WriteLine("Você usa sua arma para cortar a cabeça da zumbi fora! \n" +
                            "A cabeça sai voando para o chão e o corpo dela começa a andar por aí tentando recuperar a cabeça");
                            Console.ReadLine();
                            System.Console.WriteLine("Zumbi:EI EI EI!! É AQUI SEU CORPO IDIOTA!!, VOCÊ VAI VER SÓ PIVETE!!");
                            Console.ReadLine();
                        }
                        else if(equipamentoAtual == "kunai")
                        {
                            System.Console.WriteLine("Você esfaqueia os dois olhos da zumbi que grita de dor e começa a dar socos no ar tentando te atingir");
                            Console.ReadLine();
                            System.Console.WriteLine("Zumbi:SEU DESGRAÇADO!!!! VOCÊ VAI VER SÓ QUANDO EU TE AAACHAR!!!");
                            Console.ReadLine();
                        }
                        else
                        {
                            System.Console.WriteLine("Você dá um soco forte o bastante para quebrar o nariz da Zumbi e mandar ela voando pra parede \n" +
                            "Ela parece muito desnorteada para continuar lutando..");
                            Console.ReadLine();
                        }

                        vitoria = true;
                    }
                }
                else
                {

                    System.Console.WriteLine("Você falhou!!");
                    System.Console.ReadLine();
                    System.Console.WriteLine("Você levou 15 de dano!!!");
                    Console.ReadLine();
                    vida-=15;
                    if(vida==0)
                    {
                        GameOver();
                    }

                }



            }

        }
    }
    static void GameOver()
    {
        System.Console.WriteLine("Você foi derrotado... você falhou..\n" +
        "Você foi incapaz de parar o caos causado pelo Feiticeiro..ele conseguiu completar seu plano e limpou o vilarejo em um instante.. \n" +
        "Será que você conseguria..se tivesse mais uma chance?");
        Console.ReadLine();
        play = false;
        
    }
}



