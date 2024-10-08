﻿using System;


class Program
{
    static bool play = true;
    static Random random = new Random();

    //drop dos itens
    static bool[] eventosConcluidos = new bool[18];

    //Negocio pro inventario
    static string[] nomesItens = new string[10];
    static int[] quantidadesItens = new int[10];
    static int contadorItens = 0;
    //Equipamentos
    static string[] nomesEquipamentos = new string[10];
    static int contadorEquipamentos = 0;

    static string equipamentoAtual = "";
    //Atributos + Buffs e Debuffs
    static int vidabase = 100;
    static int vida = vidabase;
    static int defesa = 40;
    static int forcaBase = 50;
    static int velocidadeBase = 20;
    static int bonus = 0;
    static int bonusVida = 0;

    static int penalidade = 0;

    static int penalidadeForça = 0;
    static int forçaTotal = forcaBase + bonus;
    static int velocidadeTotal = velocidadeBase - penalidade;

    static void AtualizarStatus()
    {
        vida = vidabase + bonusVida;
        forçaTotal = forcaBase + bonus - penalidadeForça;
        velocidadeTotal = Math.Max(0, velocidadeBase - penalidade);
    }


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
                    TerceiroAndar();
                    Ashley();
                    Topo();
                    Creditos();

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
      "Talvez você devesse conversar com eles.");
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
                        Console.Clear();
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
            Console.Clear();

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
                    if (ItemChave("Chave Amaldiçoada", 1))
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
            Console.Clear();
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
            Console.Clear();
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
                        if (ItemChave("Chave Suspeita", 1))
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
            Console.Clear();
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
            Console.Clear();
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
            Console.Clear();
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
            Console.Clear();
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
                default:
                    Sala6();
                    break;
            }
        }
    }
    static void TerceiroAndar()
    {
        int escolha;
        bool progressao = true;

        System.Console.WriteLine("Ao subrir as escadas para o terceiro andar você se encontra com três salas \n" +
        "Uma na esquerda e outra na direita..e uma no meio..a que vai te levar até o topo da Igreja, se entrar nela não tem volta");
        Console.ReadLine();
        while (progressao)
        {
            Console.Clear();
            System.Console.WriteLine("O que você vai fazer? \n" +
            "1-Sala da esquerda \n" +
            "2-Sala da direita \n" +
            "3-Sala do meio \n" +
            "4-Abrir menu");
            int.TryParse(Console.ReadLine(), out escolha);
            switch (escolha)
            {
                case 1:
                    SalaSino();
                    break;
                case 2:
                    SalaCoracao();
                    break;
                case 3:
                    SalaFinal();
                    progressao = false;
                    break;

            }
        }
    }
    static void SalaSino()
    {
        int escolha;
        bool progressao = true;

        Console.Clear();
        System.Console.WriteLine("Você entra na sala do sino e se depara com uma estrutura antiga, ainda intacta apesar do tempo. O sino enferrujado pende no alto, e uma pintura de um homem de cabelos loiros, essa pintura parece esconder algo brilhante atrás dela.");
        Console.ReadLine();
        while (progressao)
        {
            Console.Clear();
            Console.WriteLine("O que vai fazer agora? \n" +
            "1- Pintura \n" +
            "2- Armário antigo \n" +
            "3- Abrir Menu \n" +
            "4- Voltar");
            int.TryParse(Console.ReadLine(), out escolha);
            switch (escolha)
            {
                case 1:
                    if (!eventosConcluidos[11])
                    {
                        System.Console.WriteLine("Você encontra um saco cheio de moedas preciosas e muito brilhantes... Talvez elas possam ser úteis.");
                        Console.ReadLine();
                        Inventory("Moedas", 5);
                        eventosConcluidos[11] = true;
                    }
                    else
                    {
                        Console.Clear();
                        System.Console.WriteLine("Só sobrou poeira... \n" +
                        "ATCHOOOO");
                        Console.ReadLine();
                    }
                    break;
                case 2:

                    if (!eventosConcluidos[12])
                    {
                        System.Console.WriteLine("Você encontra um papel escrito ''Plano para dominar o mundo'' \n" +
                        "Parece que foi escrito por uma criança de 5 anos");
                        Console.ReadLine();
                        Inventory("Plano idiota", 1);
                        Console.ReadLine();
                        eventosConcluidos[12] = true;
                    }

                    else
                    {
                        Console.Clear();
                        System.Console.WriteLine("Você devia vandalizar o papel.");
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
    static void SalaCoracao()
    {
        int escolha;
        bool stay = true;
        Console.Clear();
        System.Console.WriteLine("Você entra em uma sala grotesca. No centro, um coração ainda pulsando está suspenso por correntes. Há uma prateleira antiga cheia de objetos estranhos.");
        while (stay)
        {
            Console.Clear();
            System.Console.WriteLine("O que vai fazer agora? \n" +
            "1- Examinar o coração pulsante \n" +
            "2- Vasculhar a prateleira \n" +
            "3- Abrir Menu \n" +
            "4- Sair da sala");
            int.TryParse(Console.ReadLine(), out escolha);
            switch (escolha)
            {
                case 1:
                    if (!eventosConcluidos[13])
                    {
                        System.Console.WriteLine("Ao tocar o coração, você sente uma força esquisita drenando sua energia. Algo está errado aqui...");
                        vida -= 20;
                        Console.ReadLine();
                        if (vida == 0)
                        {
                            GameOver();
                        }
                        else
                        {
                            eventosConcluidos[13] = true;
                        }
                    }
                    else
                    {
                        Console.Clear();
                        System.Console.WriteLine("O coração parece menos ativo agora, mas continua pulsando lentamente.");
                        Console.ReadLine();
                    }
                    break;
                case 2:
                    if (eventosConcluidos[13] && !eventosConcluidos[14])
                    {
                        System.Console.WriteLine("Você encontra um amuleto coberto de seu proprio sangue Parece que ele possui algum tipo de poder.");
                        Console.ReadLine();
                        Equip("Amuleto");
                        Console.ReadLine();
                        eventosConcluidos[14] = true;
                    }
                    else if (!eventosConcluidos[13] && !eventosConcluidos[14])
                    {
                        Console.Clear();
                        System.Console.WriteLine("Você encontra um amuleto estranho...mas não parece fazer nada");
                        Console.ReadLine();
                    }
                    else if (eventosConcluidos[13] && eventosConcluidos[14])
                    {
                        Console.Clear();
                        System.Console.WriteLine("A pratileira está vazia");
                        Console.ReadLine();
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
    static void SalaFinal()
    {
        System.Console.WriteLine("Você se encontra na sala que talvez o leve para o final da igreja.. \n" +
        "Você vê um pequeno demoniozinho do lado com aparentemente uma loja de itens!");
        Console.ReadLine();
        System.Console.WriteLine("Mas parece ser tudo lixo inutil..é bom você seguir em frente");
        Console.ReadLine();

    }
    static void Topo()

    {
        System.Console.WriteLine("Você vê a demonia caída no chão após ter sido derrotada por você..acho que você está livre para seguir");
        Console.ReadLine();
        System.Console.WriteLine("Você lentamente anda os ultimos degraus de escada da igreja..até que você chega ao topo e se encontra com o feiticeiro.. \n");
        System.Console.WriteLine("Feiticeiro:Então você chegou ein? \n" +
        "Feiticeiro:Até que é impressionante você ter chegado aqui sem ter morrido no instante que pisou nesse lugar..como recompensa não vou te matar nesse exato segundo \n" +
        "Feiticeiro:Eu proponho um jogo simples de pedra papel e tesoura..se você perder eu farei com que você seja queimado vivo..se não aceitar irei te matar nesse instante \n");
        Console.ReadLine();
        System.Console.WriteLine("Feiticeiro:Então vamos logo com isso");
        Console.ReadLine();
        Console.ReadLine();
        Spades();

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
        if (ItemChave("Moedas", 5))
        {
            int escolha;
            bool progressao = true;
            while (progressao)
            {
                System.Console.WriteLine("Zumbi:Que que ce acha? \n" +
                "1-Pagar \n" +
                "2-Não entregar nada \n");
                int.TryParse(Console.ReadLine(), out escolha);
                switch (escolha)
                {
                    case 1:
                        Roleta();
                        progressao = false;
                        break;
                    case 2:
                        System.Console.WriteLine("Zumbi:Escolha errada pivete!!!");
                        Console.ReadLine();
                        BossRaquel();
                        progressao = false;
                        break;
                    default:
                        System.Console.WriteLine("Zumbi:VAI SE DECIDIR NÃO PIVETE?!?!");
                        break;
                }
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
                    if (ItemChave("Moedas", 5))
                    {
                        Console.Clear();
                        System.Console.WriteLine("Zumbi:Poxa..Acho que você não dá tanto valor assim pra vida");
                        Console.ReadLine();
                        Inventory("Moedas", -5);
                        Console.ReadLine();
                        System.Console.WriteLine("Ela esvaziou um dos tambores");
                        espaçosVazios = 1;
                        Console.ReadLine();
                        progressao = false;
                    }
                    else
                    {
                        System.Console.WriteLine("voce nao vai ver isso");
                    }
                    break;
                case 2:
                    if (ItemChave("Moedas", 10))
                    {
                        Console.Clear();
                        System.Console.WriteLine("Zumbi:Vamos ver se a sorte tá do seu lado..");
                        Console.ReadLine();
                        Inventory("Moedas", -10);
                        Console.ReadLine();
                        System.Console.WriteLine("Ela esvaziou dois tambores");
                        espaçosVazios = 2;
                        Console.ReadLine();
                        progressao = false;
                    }
                    else
                    {
                        Console.Clear();
                        System.Console.WriteLine("Zumbi:TA TENTANDO ME ENGANAR É?!?!?!?");
                        Console.ReadLine();
                    }
                    break;

                case 3:
                    if (ItemChave("Moedas", 15))
                    {
                        Console.Clear();
                        System.Console.WriteLine("Zumbi:Boa escolha pivete!");
                        Console.ReadLine();
                        Inventory("Moedas", -15);
                        Console.ReadLine();
                        System.Console.WriteLine("Ela esvaziou 3 tambores..");
                        espaçosVazios = 3;
                        Console.ReadLine();
                        progressao = false;
                    }
                    else
                    {
                        Console.Clear();
                        System.Console.WriteLine("Zumbi:TA TENTANDO ME ENGANAR É?!?!?!?");
                        Console.ReadLine();
                    }
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
            vida -= 15;
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
            Console.Clear();
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
        AtualizarStatus();
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
    static bool ItemChave(string itemChave, int quantidadePrecisa)
    {
        for (int i = 0; i < contadorItens; i++)
        {
            if (nomesItens[i] == itemChave)
            {
                if (quantidadesItens[i] >= quantidadePrecisa)
                {
                    return true;
                }
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
                Console.ReadLine();
            }

            // Aplica o bônus e define o equipamento atual
            switch (equipamento)
            {
                case "espada":
                    bonus += 20;
                    penalidade = 0;
                    equipamentoAtual = "espada";
                    Console.WriteLine("Você equipou a Espada. +20 de força!");
                    Console.ReadLine();
                    break;

                case "machado":
                    bonus += 30;
                    penalidade += 10;
                    equipamentoAtual = "machado";
                    Console.WriteLine("Você equipou o Machado. +30 de força e -10 de velocidade!");
                    Console.ReadLine();
                    break;

                case "kunai":
                    bonus += 10;
                    penalidade = 0;
                    equipamentoAtual = "kunai";
                    Console.WriteLine("Você equipou a Kunai. +10 de força!");
                    Console.ReadLine();
                    break;
                case "pistola":
                    bonus += 40;
                    penalidade += 20;
                    equipamentoAtual = "pistola";
                    System.Console.WriteLine("Você equipou a Pistola. +40 de força e -20 de velocidade!");
                    Console.ReadLine();
                    break;

                case "amuleto":
                    bonusVida += 50;
                    penalidadeForça += 20;
                    System.Console.WriteLine("Você equipou o Amuleto. +50 de vida e -20 de força!");
                    Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("Este item não pode ser equipado.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Você não tem este equipamento no inventário.");
            Console.ReadLine();
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
            Console.Clear();
            System.Console.WriteLine("Realizando teste..");
            Console.ReadLine();
            int resultadoDado = random.Next(1, 21);
            int resultadoFinal = resultadoDado;
            if (resultadoDado != 20)
            {
                resultadoFinal += velocidadeTotal;
            }
            Console.Clear();
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
                if (resultadoDado < 20)
                {

                    resultadosComuns++;
                    Console.WriteLine($"Resultado comum. Você tem {resultadosComuns} resultados comuns.");
                    Console.ReadLine();

                    // Verifica se o jogador venceu com 4 resultados comuns
                    if (resultadosComuns == 4)
                    {
                        Console.Clear();
                        Console.WriteLine("Você alcançou 4 resultados comuns e venceu!");
                        if (equipamentoAtual == "espada" || equipamentoAtual == "machado")
                        {
                            System.Console.WriteLine("Você usa sua arma para cortar a cabeça da zumbi fora! \n" +
                            "A cabeça sai voando para o chão e o corpo dela começa a andar por aí tentando recuperar a cabeça");
                            Console.ReadLine();
                            System.Console.WriteLine("Zumbi:EI EI EI!! É AQUI SEU CORPO IDIOTA!!, VOCÊ VAI VER SÓ PIVETE!!");
                            Console.ReadLine();
                        }
                        else if (equipamentoAtual == "kunai")
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
                    Console.Clear();

                    System.Console.WriteLine("Você falhou!!");
                    System.Console.ReadLine();
                    System.Console.WriteLine("Você levou 15 de dano!!!");
                    Console.ReadLine();
                    vida -= 15;
                    if (vida <= 0)
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
        Creditos();
        Console.ReadLine();
        Environment.Exit(0);
        play = false;

    }
    static void Ashley()
    {
        int nucleoCorreto = random.Next(1, 6);
        bool acertou = false;
        int palpite = 0;
        System.Console.WriteLine("Você encontra uma barreira bloqueando o seu caminho para o topo..atrás dela uma demonio conjurando uma magia para manter a barreira levantada..");
        System.Console.WriteLine("Ache o núcleo da barreira!!");
        Console.ReadLine();
        while (vida > 0 && !acertou)
        {

            Console.WriteLine("Digite um número entre 1 a 5:");

            if (int.TryParse(Console.ReadLine(), out palpite) && palpite >= 1 && palpite <= 5)
            {


            }

            if (palpite == nucleoCorreto)
            {
                Console.WriteLine("Você acertou o núcleo! A barreira foi destruída.");
                acertou = true;
            }
            else
            {
                vida -= 15;
                Console.WriteLine($"Errou! Você levou 15 de dano.");
            }
        }

        if (vida <= 0)
        {
            GameOver();
        }
    }


    static void Spades()
    {
        Random random = new Random();
        int jogadorVitorias = 0;
        int feiticeiroVitorias = 0;

        while (jogadorVitorias < 2 && feiticeiroVitorias < 2)
        {
            Console.Clear();
            Console.WriteLine($"Rodada {jogadorVitorias + feiticeiroVitorias + 1}:");
            Console.WriteLine("Escolha sua jogada:\n1 - Pedra\n2 - Papel\n3 - Tesoura");
            int escolhaJogador;
            int.TryParse(Console.ReadLine(), out escolhaJogador);

            while (escolhaJogador < 1 || escolhaJogador > 3)
            {
                Console.WriteLine("Escolha inválida! Escolha:\n1 - Pedra\n2 - Papel\n3 - Tesoura");
                int.TryParse(Console.ReadLine(), out escolhaJogador);
            }

            string[] opcoes = { "Pedra", "Papel", "Tesoura" };
            int escolhaFeiticeiro = random.Next(1, 4);

            Console.WriteLine($"Você escolheu: {opcoes[escolhaJogador - 1]}");
            Console.WriteLine($"Feiticeiro escolheu: {opcoes[escolhaFeiticeiro - 1]}");

            if (escolhaJogador == escolhaFeiticeiro)
            {
                Console.WriteLine("Empate!");
            }
            else if ((escolhaJogador == 1 && escolhaFeiticeiro == 3) ||
                     (escolhaJogador == 2 && escolhaFeiticeiro == 1) ||
                     (escolhaJogador == 3 && escolhaFeiticeiro == 2))
            {
                Console.WriteLine("Você venceu essa rodada!");
                jogadorVitorias++;
            }
            else
            {
                Console.WriteLine("Feiticeiro venceu essa rodada!");
                feiticeiroVitorias++;
            }

            Console.ReadLine();
        }

        if (jogadorVitorias > feiticeiroVitorias)
        {
            Console.WriteLine("Feiticeiro: Não! Não!!!! Eu não aceito isso! isso é Impossível! Como você conseguiu..");
            Console.WriteLine("Você venceu o feiticeiro e tem seu final feliz. HOORAYY");
        }
        else
        {
            Console.WriteLine("Feiticeiro: HAHAHA! SEU BURRO LERO LERO LEROOOOOO Eu disse que nunca perco!! \n" +
            "tá... agora se prepara para ser queimado vivo...");
            Console.ReadLine();
            GameOver();
        }

        Console.ReadLine();
    }
    static void Creditos()
    {
        System.Console.WriteLine("A papaleguas production \n" +
        "Murilo Pires-Programador,Roteirista, Design de personagem \n" +
        "Joanna Nobre-Programadora,Roteirista,Designer de personagem \n" +
        "Arthur Gabriel-Programador/Beta Tester \n" +
        "Alice-Supervisora \n" +
        "Hideo Kojima- Diretor do jogo \n");
    }
}


