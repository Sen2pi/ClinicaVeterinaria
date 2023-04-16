using System;


namespace ClinicaVeterinária.Modelo
{
    public class Animal
    {
        public string IdAuricular { get; set; }
        public Regulamentacao regAuricular { get; set; }
        public string NomeA { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime? DataObito { get; set; }
        public Pessoa ProprietarioAtual { get; set; }
        public Vacina[][] CadernetaVacinas { get; set; }
        public TipoAnimal Tipo { get; set; }
        public Animal(string idAuricular, Regulamentacao regulamentacao ,DateTime dataNascimento, TipoAnimal tipo, Pessoa titular, string nome)
        {

            IdAuricular = idAuricular;
            regAuricular = regulamentacao;
            DataNascimento = dataNascimento;
            CadernetaVacinas = new Vacina[6][];
            CadernetaVacinas[0] = new Vacina[20];
            CadernetaVacinas[1] = new Vacina[1];
            CadernetaVacinas[2] = new Vacina[20];
            CadernetaVacinas[3] = new Vacina[40];
            CadernetaVacinas[4] = new Vacina[40];
            CadernetaVacinas[5] = new Vacina[20];
            Tipo = tipo;
            ProprietarioAtual = titular;
            this.NomeA = nome;
            
        }
        public DateTime ObterUltimaVacina()
        {
            DateTime dataUltimaVacina = DateTime.MinValue;

            // percorre todas as páginas da caderneta de vacinas
            for (int i = 0; i < CadernetaVacinas.Length; i++)
            {
                if (CadernetaVacinas[i] != null)
                {
                    // percorre todas as vacinas da página atual
                    for (int j = 0; j < CadernetaVacinas[i].Length; j++)
                    {
                        if (CadernetaVacinas[i][j] != null && CadernetaVacinas[i][j].Data > dataUltimaVacina)
                        {
                            dataUltimaVacina = CadernetaVacinas[i][j].Data;
                        }
                    }
                }
            }

            return dataUltimaVacina;
        }
        public override string ToString()
        {
            string animalTipo = "";
            switch (Tipo)
            {
                case TipoAnimal.Bovino:
                    animalTipo = "Bovino";
                    break;
                case TipoAnimal.Caprino:
                    animalTipo = "Caprino";
                    break;
                case TipoAnimal.Ovino:
                    animalTipo = "Ovino";
                    break;
                case TipoAnimal.Suino:
                    animalTipo = "Suino";
                    break;
            }

            string cadernetaVacinas = "";
            string nomeVacina = "";
            string cadernetaVacinas1 = "";
            string nomeVacina1 = "";
            string cadernetaVacinas2 = "";
            string nomeVacina2 = "";
            string cadernetaVacinas3 = "";
            string nomeVacina3 = "";
            string cadernetaVacinas4 = "";
            string nomeVacina4 = "";
            string cadernetaVacinas5 = "";
            string nomeVacina5 = "";
            try
            {
                for (int i = 0; i < CadernetaVacinas.Length; i++)
                {
                    if (i == 0) nomeVacina  = "| I.Brotulismo     |";
                    if (i == 1) nomeVacina1 = "| II.Brucelose     |";
                    if (i == 2) nomeVacina2 = "| III.Clostridioses|";
                    if (i == 3) nomeVacina3 = "| IV.Febre Aftosa  |";
                    if (i == 4) nomeVacina4 = "| V.Leptospirose   |";
                    if (i == 5) nomeVacina5 = "| VI.Vermifugação  |";
                    for (int j = 0; j < CadernetaVacinas[i].Length; j++)
                    {
                        if (CadernetaVacinas[i][j] != null)
                        {
                            if (i == 0) cadernetaVacinas += $"{CadernetaVacinas[i][j].id} : {CadernetaVacinas[i][j].Data.ToShortDateString()}| ";
                            if (i == 1) cadernetaVacinas1 += $"{CadernetaVacinas[i][j].id} : {CadernetaVacinas[i][j].Data.ToShortDateString()}| ";
                            if (i == 2) cadernetaVacinas2 += $"{CadernetaVacinas[i][j].id} : {CadernetaVacinas[i][j].Data.ToShortDateString()}| ";
                            if (i == 3) cadernetaVacinas3 += $"{CadernetaVacinas[i][j].id} : {CadernetaVacinas[i][j].Data.ToShortDateString()}| ";
                            if (i == 4) cadernetaVacinas4 += $"{CadernetaVacinas[i][j].id} : {CadernetaVacinas[i][j].Data.ToShortDateString()}| ";
                            if (i == 5) cadernetaVacinas5 += $"{CadernetaVacinas[i][j].id} : {CadernetaVacinas[i][j].Data.ToShortDateString()}| ";
                        }
                    }
   
                }
            } catch (NullReferenceException){ }

            if (cadernetaVacinas.Length > 2)
            {
                cadernetaVacinas = cadernetaVacinas.Substring(0, cadernetaVacinas.Length - 2);
            }

            return $"\n-----------------------------------------------------------------" +
                $"\n|                        {NomeA}   Tipo: {animalTipo}                 | " +
                $"\n-----------------------------------------------------------------" +
                $"\nID auricular: {IdAuricular} Regulamentado sobre a lei {DescricaoRegulamentacao(regAuricular)} " +
                $"\nData de nascimento: {DataNascimento.ToShortDateString()}| Data de Obito: {DataObito}" +
                $"\nProprietário atual: {ProprietarioAtual.Nome} " +
                $"\n----------------------------------\n|      Caderneta de vacinas       | " +
                $"\n--------------------------------------------------------------------------------------------------------------" + 
                $"\n | Nome             |id : Data"+
                $"\n {nomeVacina} {cadernetaVacinas} " +
                $"\n {nomeVacina1} {cadernetaVacinas1} " +
                $"\n {nomeVacina2} {cadernetaVacinas2} " +
                $"\n {nomeVacina3} {cadernetaVacinas3} " +
                $"\n {nomeVacina4} {cadernetaVacinas4} " +
                $"\n {nomeVacina5} {cadernetaVacinas5} ";
        }
        
        public string DescricaoRegulamentacao(Regulamentacao regulamentacao)
        {
            switch (regulamentacao)
            {
                case Regulamentacao.N1:
                    return "Nº2 Artº4";
                case Regulamentacao.N2:
                    return "Nº3 Artº9";
                case Regulamentacao.N3:
                    return "Nº3 e 4 do anexo do regulamento (CE) Nº21/2004";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
    }
