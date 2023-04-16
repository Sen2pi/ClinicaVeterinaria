using System;
using ClinicaVeterinária.Modelo;

namespace ClinicaVeterinária.Repositório
{
    internal interface IRepositorio
    {
        void AdicionarAnimal(string auricular, Regulamentacao regulamentacao, DateTime nascimento, TipoAnimal tipo, Pessoa pessoa, string nome);
        void AdicionarVacina(int id, DateTime data, string lote, string produtor, int quantidadeMl, Nome nomeV);
        int ObterIndiceDisponivel(Object[] array);
        void DeclararObito(string idAuricular, DateTime data);
        void ListarAnimais();
        void ListarPessoas();
        void ListarVacinas();
        Animal[] ListarAnimaisComVacinasAtraso();
        Animal ProcurarAnimal(string idAuricular);
        Vacina ProcurarVacina(int id);
        DateTime CalcularDataVencimento(Vacina vacina);
        Pessoa ProcurarPessoa(long telefone);
        void AdicionarProprietario(string nomeP, string endereco, long telefone, string email);
        void TrocarProprietario(string idAuricular, Pessoa novoProprietario, long telefone);
        Animal[] ListarAnimaisSemVacinas();
        void AdicionarNaCaderneta(string idAuricular, Vacina vacina);

        
    }
}
