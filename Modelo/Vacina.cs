using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaVeterinária.Modelo
{
    public class Vacina
    {
        public int id;
        public DateTime Data { get; set; }
        public string Lote { get; set; }
        public string Produtor { get; set; }
        public int QuantidadeDose { get; set; }
        public Nome Nome { get; set; }

        public string Periodicidade { get; set; }

        public Vacina()
        {
            this.Nome = Nome;
        }
        public Vacina(int id, DateTime data, string lote, string produtor, int quantidadeDose, Nome nome, string periodicidade)
        {
            this.id = id;
            Data = data;
            Lote = lote;
            Produtor = produtor;
            QuantidadeDose = quantidadeDose;
            Nome = nome;
            Periodicidade= periodicidade;
        }
        public bool Validacao()
        {
            if (Periodicidade == "Anual") {
                if (DateTime.Now.Year - Data.Year  >= 1) return true;
            } else if (Periodicidade == "Semestral") {
                if (DateTime.Now.Year - Data.Year >=1 || DateTime.Now.Month - Data.Month <= 6) return true;
            }else if (Nome == Nome.Brucelose) {
                return false;
            }
            else if(Nome == Nome.Vermifugação) {
                if (DateTime.Now.Year - Data.Year >= 1 && DateTime.Now.Month >= 3) return true;             
            }
            return false;
        }
        public int ToIntPeriodicidade(string periodicidade)
        {
            int meses = 0;
            if(periodicidade == "semestral")
            {
                meses= 6;
            }
            else if(periodicidade == "Anual")
            {
                meses = 12;
            }
            else
            {
                meses = 1;
            }
            return meses;
        }
        public override string ToString()
        {
            string selecaoNome = "";
            switch (Nome)
            {
                case Nome.Botulismo:
                    selecaoNome = "Botulismo";
                    break;
                case Nome.Brucelose:
                    selecaoNome = "Brucelose";
                    break;
                case Nome.Clostridioses:
                    selecaoNome = "Clostridioses";
                    break;
                case Nome.Leptospirose:
                    selecaoNome = "Leptospirose";
                    break;
                case Nome.Vermifugação:
                    selecaoNome = "Vermifugação";
                    break;
                case Nome.FebreAftosa:
                    selecaoNome = "Febre Aftosa";
                    break;
            }
            return 
                $"ID: {id}" +
                $"\nData: {Data}" +
                $"\nLote: {Lote}" +
                $"\nProdutor: {Produtor}" +
                $"\nQuantidade de doses: {QuantidadeDose}" +
                $"\nNome: {selecaoNome}\nPeriodicidade: {Periodicidade}";
        }

    }
}
