using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ClinicaVeterinária.Modelo;

namespace ClinicaVeterinária.Repositório
{
    public class Repositorio : IRepositorio
    {
        public Animal[] animaisCadastrados;
        public Pessoa[] pessoas;
        public Vacina[] vacinas;

        public Repositorio()
        {
            animaisCadastrados = new Animal[30];
            pessoas = new Pessoa[30];
            vacinas = new Vacina[30];
        }
        public void AdicionarAnimal(string auricular, Regulamentacao regulamentacao, DateTime nascimento, TipoAnimal tipo, Pessoa pessoa, string nome)
        {
            Animal animal = new Animal(auricular, regulamentacao, nascimento, tipo, pessoa, nome);
            int index = ObterIndiceDisponivel(animaisCadastrados);
            if (index >= 0)
            {
                animaisCadastrados[index] = animal;
                Console.WriteLine("Animal adicionado com sucesso!");
            }
            else
            {
                Console.WriteLine("Não foi possível adicionar o animal. Lista cheia!");
            }
        }

        public void AdicionarNaCaderneta(string idAuricular, Vacina vacina)
        {

            // busca o animal pelo id auricular
            Animal animal = ProcurarAnimal(idAuricular);

            if (animal == null)
            {
                Console.WriteLine("Animal não encontrado.");
                return;
            }
            else
            {
                try
                {
                    if (vacina.Nome == Nome.Botulismo)
                    {
                        for (int i = 0; i < animal.CadernetaVacinas.Length; i++)
                            if (animal.CadernetaVacinas[0][i] == null)
                            {
                                animal.CadernetaVacinas[0][i] = vacina;
                                break;
                            }
                    }
                    else if (vacina.Nome == Nome.Brucelose)
                    {
                        if (animal.CadernetaVacinas[1][0]!=null)
                        {
                        for (int i = 0; i < animal.CadernetaVacinas.Length; i++)
                            if (animal.CadernetaVacinas[1][i] == null)
                            {
                                animal.CadernetaVacinas[1][i] = vacina;
                                break;
                            }
                        }
                    }
                    else if (vacina.Nome == Nome.Clostridioses)
                    {
                        for (int i = 0; i < animal.CadernetaVacinas.Length; i++)
                            if (animal.CadernetaVacinas[2][i] == null)
                            {
                                animal.CadernetaVacinas[2][i] = vacina;
                                break;
                            }
                    }
                    else if (vacina.Nome == Nome.FebreAftosa)
                    {
                        for (int i = 0; i < animal.CadernetaVacinas.Length; i++)
                            if (animal.CadernetaVacinas[3][i] == null)
                            {
                                animal.CadernetaVacinas[3][i] = vacina;
                                break;
                            }
                    }
                    else if (vacina.Nome == Nome.Leptospirose)
                    {
                        for (int i = 0; i < animal.CadernetaVacinas.Length; i++)
                            if (animal.CadernetaVacinas[4][i] == null)
                            {
                                animal.CadernetaVacinas[4][i] = vacina;
                                break;
                            }
                    }
                    else if (vacina.Nome == Nome.Vermifugação)
                    {
                        for (int i = 0; i < animal.CadernetaVacinas.Length; i++)
                            if (animal.CadernetaVacinas[5][i] == null)
                            {
                                animal.CadernetaVacinas[5][i] = vacina;
                                break;
                            }
                    }
                }
                catch (NullReferenceException) { }
            }

        }

        public void AdicionarProprietario(string nomeP, string endereco, long telefone, string email)
        {
            Pessoa pessoa = new Pessoa(nomeP, endereco, telefone, email);
            int index = ObterIndiceDisponivel(pessoas);
            if (index >= 0)
            {
                pessoas[index] = pessoa;
                Console.WriteLine("Animal adicionado com sucesso!");
            }
            else
            {
                Console.WriteLine("Não foi possível adicionar a pessoa. Lista cheia!");
            }

        }

        public void AdicionarVacina(int id, DateTime data, string lote, string produtor, int quantidadeMl, Nome nomeV)
        {

            string periodicidade = "";
            if (nomeV == Nome.Botulismo)
            {
                periodicidade = "Anual";
            }
            else if (nomeV == Nome.Brucelose)
            {
                periodicidade = "Unica";
            }
            else if (nomeV == Nome.Vermifugação)
            {
                periodicidade = "Anual"; // em maio
            }
            else if (nomeV == Nome.Leptospirose)
            {
                periodicidade = "Semestral";
            }
            else if (nomeV == Nome.Clostridioses)
            {
                periodicidade = "Anual";
            }
            else if (nomeV == Nome.FebreAftosa)
            {
                periodicidade = "Anual";
            }
            
            Vacina vacina = new Vacina(id, data, lote, produtor, quantidadeMl, nomeV, periodicidade);
            int index = ObterIndiceDisponivel(vacinas);
            if (index >= 0)
            {
                vacinas[index] = vacina;
                Console.WriteLine("Vacina adicionada com sucesso!");
            }
            else
            {
                Console.WriteLine("Não foi possível adicionar a Vacina. Lista cheia!");
            }
        }

        public void DeclararObito(int id)
        {
            throw new NotImplementedException();
        }

        public void ListarAnimais()
        {
            try
            {
                foreach (Animal animal in animaisCadastrados)
                {
                    Console.WriteLine(animal.ToString());
                    Console.WriteLine("____________________________________________________________________________");
                }
            }
            catch (NullReferenceException)
            {

            }
        }

        public void ListarAnimaisComVacinasAtraso()
        {

            Console.WriteLine("Listagem de animais com vacinas em atraso:");
            Console.WriteLine("----------------------------------------");
            try
            {
                Vacina[] vacinasAtrasadas = new Vacina[20];
                foreach (Animal animal in animaisCadastrados)
                {

                    int i = 0;
                    if (animal != null)
                    {
                        bool vacinasEmAtraso = false;

                        foreach (Vacina vacina in animal.CadernetaVacinas[i])
                        {
                            i++;
                            if (vacina.Validacao())
                            {
                                vacinasEmAtraso = true;
                                vacinasAtrasadas.Append(vacina);
                                break;
                            }
                        }

                        if (vacinasEmAtraso)
                        {
                            Console.WriteLine($"Auricular: {animal.IdAuricular}");
                            Console.WriteLine($"Proprietário: {animal.ProprietarioAtual.Nome}");
                            Console.WriteLine($"Espécie: {animal.Tipo}");
                            Console.WriteLine($"Última vacina: {animal.ObterUltimaVacina()}");
                            Console.WriteLine();
                        }
                    }
                }


            }
            catch (NullReferenceException) { }
        }

        public void ListarAnimaisSemVacinas()
        {
            try
            {
                foreach (Animal animal in animaisCadastrados)
                {
                    if (animal.CadernetaVacinas[0] == null)
                    {
                        Console.WriteLine(animal.ToString());
                        Console.WriteLine("____________________________________________________________________________");
                    }
                }
            }
            catch (NullReferenceException)
            {

            }
        }

        public void ListarPessoas()
        {
            try
            {
                foreach (Pessoa pessoa in pessoas)
                {
                    Console.WriteLine(pessoa.ToString());
                    Console.WriteLine("____________________________________________________________________________");
                }
            }
            catch (NullReferenceException)
            {

            }
        }

        public int ObterIndiceDisponivel(Object[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == null)
                {
                    return i;
                }
            }
            return -1;
        }

        public Animal ProcurarAnimal(string idAuricular)
        {
            foreach (Animal animal in animaisCadastrados)
            {
                if (animal.IdAuricular == idAuricular)
                {
                    Console.WriteLine($"Animal encontrado: {animal}");
                    return animal;
                }

            }

            return null;
        }

        public Pessoa ProcurarPessoa(long telefone)
        {
            try
            {
                return Array.Find(pessoas, pessoa => pessoa.Telefone == telefone);
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("Ocorreu um erro ao buscar a pessoa: " + ex.Message);
                return null;
            }
        }

        public Vacina ProcurarVacina(int id)
        {
            try{ 
            
            foreach (Vacina vacina in vacinas)
            {
                if (vacina.id == id)
                {
                    return vacina;
                }
            }
            
            }catch (NullReferenceException) { }
            return null;
        }

        public void TrocarProprietario(string idAuricular, Pessoa novoProprietario, long telefone)
        {
            Animal animal = ProcurarAnimal(idAuricular);
            if (animal == null)
            {
                Console.WriteLine("Animal não encontrado.");
                return;
            }

            Pessoa proprietarioAtual = animal.ProprietarioAtual;

            if (proprietarioAtual == novoProprietario)
            {
                Console.WriteLine("O novo proprietário é o mesmo que o atual.");
                return;
            }

            if (ProcurarPessoa(telefone) == null)
            {
                Console.WriteLine("Pessoa não encontrada.");
                return;
            }

            animal.ProprietarioAtual = novoProprietario;
            Console.WriteLine($"Proprietário do animal {animal.NomeA} atualizado de {proprietarioAtual.Nome} para {novoProprietario.Nome}.");
        }
    }
}
