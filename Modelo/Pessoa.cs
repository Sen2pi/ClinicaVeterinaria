using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaVeterinária.Modelo
{
    public class Pessoa
    {
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public long Telefone { get; set; }
        public string Email { get; set; }

        public Pessoa(string nome, string endereco, long telefone , string email) {
            this.Nome = nome;   
            this.Endereco = endereco;   
            this.Telefone = telefone;
            this.Email = email;

        
        }
        public override string ToString()
        {
            return $"Nome: {Nome}\nEndereço: {Endereco}\nTelefone: {Telefone}\nEmail: {Email}";
        }
    }
    
}