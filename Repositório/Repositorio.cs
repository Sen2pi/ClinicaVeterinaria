using System;
using ClinicaVeterinária.Modelo;

namespace ClinicaVeterinária.Repositório
{
    public class Repositorio : IRepositorio
    {
        public const int total = 142;
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

        public void ListarVacinas()
        {
            try
            {
                for (int i = 0; i < vacinas.Length; i++)
                {
                    Console.WriteLine(vacinas[i].ToString());
                    Console.WriteLine("____________________________________________________________________________");
                }
            }
            catch (NullReferenceException)
            {

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

        public DateTime CalcularDataVencimento(Vacina vacina)
        {
            DateTime dataVencimento = vacina.Data;

            if (vacina.Periodicidade == "Semestral")
            {
                dataVencimento = dataVencimento.AddMonths(6);
            }
            else if (vacina.Periodicidade == "Anual")
            {
                dataVencimento = dataVencimento.AddYears(1);
            }

            return dataVencimento;
        }

        public void DeclararObito(string idAuricular, DateTime data)
        {
            Animal animal = ProcurarAnimal(idAuricular);
            if (animal == null)
            {
                Console.WriteLine("Animal não encontrado.");
                return;
            }
            else
            {
                animal.DataObito = data;
            }
        }

        public void ListarAnimais()
        {
            try
            {
                for (int i=0; i<animaisCadastrados.Length;i++)
                {
                    Console.WriteLine(animaisCadastrados[i].ToString());
                    Console.WriteLine("____________________________________________________________________________");
                }
            }
            catch (NullReferenceException)
            {

            }
        }
        public int DataDias(DateTime data)
        {
            int dias = 0;
            dias += ((DateTime.Now.Year - data.Year) * 365);
            dias += ((DateTime.Now.Month - data.Month) * 30);
            dias += DateTime.Now.Day - data.Day;
            return dias;
        }
        public Animal[] ListarAnimaisComVacinasAtraso()
        {
                Animal[] animaisComVacinasEmAtraso = new Animal[0];
                int count = 0;
            try
            {
                // Percorrer a lista de animais cadastrados
                foreach (Animal animal in animaisCadastrados)
                {
                    // Percorrer a caderneta de vacinas do animal
                    for (int i = 0; i < animal.CadernetaVacinas.Length; i++)
                    {
                        if (animal.CadernetaVacinas[i] != null)
                        {
                            for (int j = 0; j < animal.CadernetaVacinas[i].Length; j++)
                            {
                                if (animal.CadernetaVacinas[i][j] != null)
                                {
                                    Vacina vacina = animal.CadernetaVacinas[i][j];

                                    // Verificar se a vacina está atrasada com mais de 180 dias após a data de toma
                                    DateTime dataLimite = vacina.Data.AddMonths(vacina.ToIntPeriodicidade(vacina.Periodicidade)).AddDays(180);
                                    if (DateTime.Now > dataLimite)
                                    {
                                        // Adicionar o animal ao array de animais com vacinas em atraso
                                        Array.Resize(ref animaisComVacinasEmAtraso, count + 1);
                                        animaisComVacinasEmAtraso[count] = animal;
                                        count++;
                                    }
                                }
                            }
                        }
                    }
                }
               
            }
            catch (NullReferenceException) { }
            for (int h = 0;h<count; h++)
            {
                Console.WriteLine(animaisComVacinasEmAtraso[h].ToString());
                Console.WriteLine("--------------------------------------------------------------------------------------------");
            }
            return animaisComVacinasEmAtraso ;
            
        }

        public Animal[] ListarAnimaisSemVacinas()
        {
            Animal[] animaisSemVacinas = new Animal[0];
            int count = 0;
            try
            {
                // Percorrer a lista de animais cadastrados
                foreach (Animal animal in animaisCadastrados)
                {
                    bool possuiVacina = false;

                    // Percorrer a caderneta de vacinas do animal
                    for (int i = 0; i < animal.CadernetaVacinas.Length; i++)
                    {
                        if (animal.CadernetaVacinas[i] != null)
                        {
                            for (int j = 0; j < animal.CadernetaVacinas[i].Length; j++)
                            {
                                if (animal.CadernetaVacinas[i][j] != null)
                                {
                                    possuiVacina = true;
                                    break;
                                }
                            }
                        }

                        if (possuiVacina)
                        {
                            break;
                        }
                    }

                    // Verificar se o animal não possui vacinas registradas
                    if (!possuiVacina)
                    {
                        Array.Resize(ref animaisSemVacinas, count + 1);
                        animaisSemVacinas[count] = animal;
                        count++;
                    }
                }
            }
            catch (NullReferenceException) { }
            for(int i = 0;i < animaisSemVacinas.Length; i++)
            {
                Console.WriteLine(animaisSemVacinas[i].ToString());
                Console.WriteLine("--------------------------------------------------------------------------------------------");
            }
            return animaisSemVacinas;
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
            
            for (int i =0; i<vacinas.Length; i++)
            {
                if (vacinas[i].id == id)
                {
                    Console.WriteLine(vacinas[i].ToString());
                    return vacinas[i];
                    }
                else
                {
                    Console.WriteLine($"Vacina com esse id {id} não encontrada");
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
