using ClinicaVeterinária.Repositório;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using ClinicaVeterinária.Modelo;
using System.Threading.Tasks;

namespace ClinicaVeterinária.Serviço
{
    public class Servico

    {

        public bool sentinela = true;
        Repositorio veterinario = new Repositorio();

        public void MostrarMenu()
        {

                Console.Clear();
                do
                {
                    
                    Console.WriteLine($"Logado com o Veterinario: Os Programadores");
                    Console.WriteLine("---------------------------------------------------------------- ");
                    Console.WriteLine("|                Sistema de Registo de Animais                 | ");
                    Console.WriteLine("---------------------------------------------------------------- ");
                    Console.WriteLine("| 1 - Listar Animais                                           |");
                    Console.WriteLine("| 2 - Listar Animais Sem Vacinas                               |");
                    Console.WriteLine("| 3 - Listar Animais Com Vacinas em Atraso                     |");
                    Console.WriteLine("| 4 - Registar Animal                                          |");
                    Console.WriteLine("| 5 - Registar Pessoa                                          |");
                    Console.WriteLine("| 6 - Registar Vacina                                          |");
                    Console.WriteLine("| 7 - Alterar Titular                                          |");
                    Console.WriteLine("| 8 - Listar Titulares                                         |");
                    Console.WriteLine("|______________________________________________________________|");
                //Escolha do item do menu
                    Console.WriteLine("Insira uma escolha: ");
                //Char para podermos corrigir a excepcao try catch 
                    char escolha = Console.ReadKey(true).KeyChar;                    
                    switch (escolha)
                    {
                        case '1':
                            ListarAnimais();
                            break;
                        case '2':
                            AnimaisSemVacinal();
                            break;
                        case '3':
                            AnimaisVacinasAtrasadas();
                            break;
                        case '4':
                            MenuRegistroAnimal();
                            break;
                        case '5':
                            AdicionarPessoa();
                            break;
                        case '6':
                            RegistarVacina();
                            break;
                        case '7':
                            AlterarTitular();
                            break;
                        case '8':
                            ListarTitulares();
                            break;
                        default:
                            Console.WriteLine("Erro escolha inválida: Insira um numeo de 1 a 6 consoante a opção desejada");
                            break;
                    }
                MenuNav();
                } while (sentinela);
            
        }
        public void MenuNav()
        {
            Console.WriteLine("Deseja sair da aplicação ou voltar ao menu inicial? ");
            Console.WriteLine("---------------------------------------------------------------- ");
            Console.WriteLine("|                      Menu de Navegação                       | ");
            Console.WriteLine("---------------------------------------------------------------- ");
            Console.WriteLine("| 1 - Menu Inicial                                             |");
            Console.WriteLine("| Prima qualquer tecla para sair da Aplicação                  |");
            Console.WriteLine("|______________________________________________________________|");
            char escolha = Console.ReadKey(true).KeyChar;
            switch (escolha)
            {
                case '1':
                    MostrarMenu();
                    break;
                default:
                    sentinela = false;
                    break;

            }
        }
        public void MenuRegistroAnimal()
        {
            Console.Clear();
            Console.WriteLine("---------------------------------------------------------------- ");
            Console.WriteLine("|                Menu de Registo de Animais                    | ");
            Console.WriteLine("---------------------------------------------------------------- ");
            Console.WriteLine("Insira um nome");
            string nome = Console.ReadLine();
            Console.WriteLine("Insira a data de nascimento do seu anima (AAAA/MM/DD");
            DateTime nascimento = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Insira um nome para o titular");
            string nomeP = Console.ReadLine();
            Console.WriteLine("Insira a morada do titular");
            string endereco = Console.ReadLine();
            Console.WriteLine("Insira um numero de telefone do titular");
            long telefone = long.Parse(Console.ReadLine());
            Console.WriteLine("Insira um email para o titular");
            string email = Console.ReadLine();
            Pessoa pessoa = new Pessoa(nomeP, endereco, telefone, email);
            veterinario.AdicionarProprietario(nomeP, endereco, telefone, email);
            Console.WriteLine("Insira o tipo de Animal \n1 - Bovino\n2 - Suino\n3 - Ovino \n4 - Caprino");
            int escolha = Convert.ToInt32(Console.ReadLine());
            TipoAnimal tipo = new TipoAnimal();
            do {
                switch (escolha)
                {
                    case 1:
                        tipo = TipoAnimal.Bovino;
                        sentinela = false;
                        break;
                    case 2:
                        tipo = TipoAnimal.Suino;
                        sentinela = false;
                        break;
                    case 3:
                        tipo = TipoAnimal.Ovino;
                        sentinela = false;
                        break;
                    case 4:
                        tipo = TipoAnimal.Caprino;
                        sentinela = false;
                        break;
                    default:
                        Console.WriteLine("Erro insira um tipo valido listado");
                        break;
                }
            } while (sentinela);

            Console.WriteLine("Insira o numero do auricular unico: ");
            string auricular = Console.ReadLine();
            Console.WriteLine("Insira a regulamentação qu ese rege o ID Auricular  \n1 - Nº2 do Artº4\n2 - Nº3 do Artº9\n3 - Nº3 e 4 do anexo do regulamento (CE) Nº21/2004");
            int escolha2 = Convert.ToInt32(Console.ReadLine());
            Regulamentacao regulamentacao = new Regulamentacao();
            do
            {
                switch (escolha2)
                {
                    case 1:
                        regulamentacao = Regulamentacao.N1;
                        sentinela = false;
                        break;
                    case 2:
                        regulamentacao = Regulamentacao.N2;
                        sentinela = false;
                        break;
                    case 3:
                        regulamentacao = Regulamentacao.N3;
                        sentinela = false;
                        break;
                    default:
                        Console.WriteLine("Erro insira uma escolha valida listada");
                        break;
                } 
            }while(sentinela);

            veterinario.AdicionarAnimal(auricular, regulamentacao, nascimento, tipo, pessoa, nome);
            sentinela = true;
            do
            {
                Console.WriteLine("Pretende Registrar uma Vacina ? Y/N");
                string escolha3 = Console.ReadLine();
                switch (escolha3)
                {
                    case "Y":
                        RegistarVacina();
                        sentinela = false;
                        break;
                    case "N":
                        sentinela = false;
                        break;
                    default:
                        Console.WriteLine("Erro insira um tipo valido listado");
                        break;
                }
            } while (sentinela);
               
        }
        public void RegistarVacina()
        {

            Console.WriteLine("---------------------------------------------------------------- ");
            Console.WriteLine("|                Menu de Registo de Vacina                     | ");
            Console.WriteLine("---------------------------------------------------------------- ");


            do
            {
                Console.WriteLine("Insira o ID Auricular do Animal que pretende adicionar a vacina");
                string idAuricular = Console.ReadLine();
                if (VerificarID(idAuricular) != null)
                {
                    Console.WriteLine("Insira o nome da Vacina: ");
                    Console.WriteLine("1 - Brucelose");
                    Console.WriteLine("2 - Botulismo");
                    Console.WriteLine("3 - Leptospirose");
                    Console.WriteLine("4 - Vermifugação");
                    Console.WriteLine("5 - FebreAftosa");
                    Console.WriteLine("6 - Clostridioses");

                    Nome nomeV = new Nome();
                    char escolha = Convert.ToChar(Console.ReadLine());
                    do
                    {
                        switch (escolha)
                        {
                            case '1':
                                nomeV = Nome.Brucelose;
                                sentinela = false;
                                break;
                            case '2':
                                nomeV = Nome.Botulismo;
                                sentinela = false;
                                break;
                            case '3':
                                nomeV = Nome.Leptospirose;
                                sentinela = false;
                                break;
                            case '4':
                                nomeV = Nome.Vermifugação;
                                sentinela = false;
                                break;
                            case '5':
                                nomeV = Nome.FebreAftosa;
                                sentinela = false;
                                break;
                            case '6':
                                nomeV = Nome.Clostridioses;
                                sentinela = false;
                                break;
                            default:
                                Console.WriteLine("Erro insira um tipo valido listado");
                                break;
                        }
                    } while (sentinela);

                    Console.WriteLine("Insira a data da vacina: ");
                    DateTime data = Convert.ToDateTime(Console.ReadLine());

                    Console.WriteLine("Insira o lote: ");
                    string lote = Console.ReadLine();

                    Console.WriteLine("Insira o nome do produtor: ");
                    string produtor = Console.ReadLine();

                    Console.WriteLine("Insira a dose em ml: ");
                    int quantidadeMl = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Insira o mês da vacina 6 se é semestral ou 12 se é anual ");
                    int id = 0;
                    for (int i = 0; i < veterinario.vacinas.Length; i++)
                    {
                        id+=2;
                    }
                    veterinario.AdicionarVacina(id, data, lote, produtor, quantidadeMl, nomeV);
                    veterinario.AdicionarNaCaderneta(idAuricular, veterinario.ProcurarVacina(id));
                    sentinela = false;
                }
                else
                {
                    Console.WriteLine("Insira um id do auricular do animal existente, consulte a lista de animais para mais informações");
                }
            } while (sentinela);

        }
        public Animal VerificarID(string idAuricular)
        {
            foreach (Animal animal in veterinario.animaisCadastrados)
            {
                int count = 0;
                if (animal.IdAuricular == idAuricular)
                {
                    Console.WriteLine($"Está a adicionar uma vacina ao {animal.NomeA}");
                    return animal;
                }
                else if (count == veterinario.animaisCadastrados.Length)
                {
                    Console.WriteLine($"Animal não encontrado com o id {idAuricular}, tente novamente");
                    return null;
                }
                else
                {
                    count++;

                }
            }
            return null;
        }
        public void AdicionarPessoa()
        {
            Console.Clear();
            Console.WriteLine("---------------------------------------------------------------- ");
            Console.WriteLine("|                Sistema de Adição de Titulares                | ");
            Console.WriteLine("---------------------------------------------------------------- ");
            Console.WriteLine("Insira um nome para o titular");
            string nomeP = Console.ReadLine();
            Console.WriteLine("Insira a morada do titular");
            string endereco = Console.ReadLine();
            Console.WriteLine("Insira um numero de telefone do titular");
            long telefone = long.Parse(Console.ReadLine());
            Console.WriteLine("Insira um email para o titular");
            string email = Console.ReadLine();
            veterinario.AdicionarProprietario(nomeP, endereco, telefone, email);
            Console.WriteLine($"O Proprietario {nomeP} foi adicionado com sucesso");
        }
        public void ListarAnimais()
        {
            Console.Clear();
            Console.WriteLine("---------------------------------------------------------------- ");
            Console.WriteLine("|                   Listagem  de Animais                       | ");
            Console.WriteLine("---------------------------------------------------------------- ");
            veterinario.ListarAnimais();
        }
        public void AnimaisSemVacinal()
        {
            Console.Clear();
            Console.WriteLine("---------------------------------------------------------------- ");
            Console.WriteLine("|            Listagem  de Animais sem Vacinas                  | ");
            Console.WriteLine("---------------------------------------------------------------- ");
            veterinario.ListarAnimaisSemVacinas();
        }
        public void AnimaisVacinasAtrasadas()
        {
            Console.Clear();
            Console.WriteLine("---------------------------------------------------------------- ");
            Console.WriteLine("|          Listagem  de Animais Com Vacinas em Atraso          | ");
            Console.WriteLine("---------------------------------------------------------------- ");
            veterinario.ListarAnimaisComVacinasAtraso();
        }

        public void PreData()
        {
            // Criação de 5 objetos Pessoa
            veterinario.AdicionarProprietario("João", "Rua A, 123", 123456789, "joao@email.com");
            veterinario.AdicionarProprietario("Maria", "Rua B, 456", 987654321, "maria@email.com");
            veterinario.AdicionarProprietario("José", "Rua C, 789", 111222333, "jose@email.com");
            veterinario.AdicionarProprietario("Ana", "Rua D, 567", 444555666, "ana@email.com");
            veterinario.AdicionarProprietario("Pedro", "Rua E, 890", 777888999, "pedro@email.com");


            // Criação de 5 objetos Animal
            veterinario.AdicionarAnimal("123", Regulamentacao.N1, new DateTime(2019, 1, 1), TipoAnimal.Bovino, veterinario.ProcurarPessoa(123456789), "Mimosa");
            veterinario.AdicionarAnimal("456", Regulamentacao.N2, new DateTime(2018, 2, 1), TipoAnimal.Ovino, veterinario.ProcurarPessoa(987654321), "Dolly");
            veterinario.AdicionarAnimal("789", Regulamentacao.N2, new DateTime(2020, 3, 1), TipoAnimal.Caprino, veterinario.ProcurarPessoa(111222333), "Capitão");
            veterinario.AdicionarAnimal("012", Regulamentacao.N3, new DateTime(2017, 4, 1), TipoAnimal.Suino, veterinario.ProcurarPessoa(444555666), "Porquinho");
            veterinario.AdicionarAnimal("345", Regulamentacao.N3, new DateTime(2016, 5, 1), TipoAnimal.Bovino, veterinario.ProcurarPessoa(777888999), "Bolinha");

            //Criação de 5 vacinas
            veterinario.AdicionarVacina(1, new DateTime(2022, 01, 10), "Lote1", "Produtor1", 10, Nome.Botulismo);
            veterinario.AdicionarVacina(2, new DateTime(2022, 02, 20), "Lote2", "Produtor2", 5, Nome.Brucelose);
            veterinario.AdicionarVacina(3, new DateTime(2022, 03, 30), "Lote3", "Produtor3", 15, Nome.Vermifugação);
            veterinario.AdicionarVacina(4, new DateTime(2022, 04, 10), "Lote4", "Produtor4", 10, Nome.FebreAftosa);
            veterinario.AdicionarVacina(5, new DateTime(2022, 05, 20), "Lote5", "Produtor5", 5, Nome.Leptospirose);
            veterinario.AdicionarNaCaderneta("123", veterinario.ProcurarVacina(1));
            veterinario.AdicionarNaCaderneta("123", veterinario.ProcurarVacina(2));
            veterinario.AdicionarNaCaderneta("789", veterinario.ProcurarVacina(3));
            veterinario.AdicionarNaCaderneta("456", veterinario.ProcurarVacina(4));
            veterinario.AdicionarNaCaderneta("345", veterinario.ProcurarVacina(5));
        }

        public void AlterarTitular()
        {
            Console.WriteLine("---------------------------------------------------------------- ");
            Console.WriteLine("|                     Alterar Titular                          | ");
            Console.WriteLine("---------------------------------------------------------------- ");
            Console.WriteLine("Insira o ID do Animal Para Alteração: ");
            string idAuricular = Console.ReadLine();
            Console.WriteLine("Insira o telefone do Novo Titular: ");
            long telefone = long.Parse(Console.ReadLine());
            veterinario.TrocarProprietario(idAuricular, veterinario.ProcurarPessoa(telefone), telefone);
        }
        public void ListarTitulares()
        {
            Console.Clear();
            Console.WriteLine("---------------------------------------------------------------- ");
            Console.WriteLine("|                   Listagem  de Titulares                     | ");
            Console.WriteLine("---------------------------------------------------------------- ");
            veterinario.ListarPessoas();
        }
        //public void LoginMenu()
        //{
        //    bool Sucesso = true;
        //    Console.Clear();

        //        do
        //        {
        //            Console.WriteLine("----------------------------------------------------------------------------");
        //            Console.WriteLine("|                               Login                                      |");
        //            Console.WriteLine("----------------------------------------------------------------------------");
        //            Console.Write("Login -----> ");
        //            string login = Console.ReadLine();
        //            Console.Write("Password -----> ");
        //            string password = Console.ReadLine();
        //            Console.WriteLine("____________________________________________________________________________");

        //            veterinario.Login(veterinario, login, password);
        //            if (veterinario.Login(veterinario, login, password) == true)
        //            {
        //                Sucesso = false;
        //            }
        //            else
        //            {
        //                Console.WriteLine("Password ou Login errado tente novamente");
        //            }
        //        } while (Sucesso);
         
            
        //}

    }
}
