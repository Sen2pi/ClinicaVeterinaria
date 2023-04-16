using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicaVeterinária.Modelo;

namespace ClinicaVeterinária.Repositório
{
    internal interface IRepositorio
    {
        void AdicionarAnimal(string auricular, Regulamentacao regulamentacao, DateTime nascimento, TipoAnimal tipo, Pessoa pessoa, string nome);
        void AdicionarVacina(int id, DateTime data, string lote, string produtor, int quantidadeMl, Nome nomeV);
        int ObterIndiceDisponivel(Object[] array);
        void DeclararObito(int id );
        void ListarAnimais();
        void ListarPessoas();
        void ListarAnimaisComVacinasAtraso();
        Animal ProcurarAnimal(string idAuricular);
        Vacina ProcurarVacina(int id);
        Pessoa ProcurarPessoa(long telefone);
        void AdicionarProprietario(string nomeP, string endereco, long telefone, string email);
        void TrocarProprietario(string idAuricular, Pessoa novoProprietario, long telefone);
        void ListarAnimaisSemVacinas();
        void AdicionarNaCaderneta(string idAuricular, Vacina vacina);

        
    }
}
