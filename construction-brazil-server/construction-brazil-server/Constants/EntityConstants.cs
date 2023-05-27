namespace EEPServer.Constants
{
    public static class EntityConstants
    {
        public static class ApplicationLoggingTypeConstants
        {
            public const string Information = "Information";
            public const string Critical = "Critical";
            public const string ElasticSearch = "Elastic Search";
        }

        public static class DddConstants
        {
            public static IEnumerable<int> NumeroDeDdds = new List<int>
            {
                11, 12, 13,14,15,16,17,18,19,21,22, 24, 27,28,31,32,33,34,35,37,
                38, 41, 42,43,44,45,46,47,48,49,51,53, 54, 55,61,62,63,64,65,66,
                67,68,69,71,73,74,75,77,79,81,82,83,84,85,86,87,88,89,91,92,93,
                94,95,96,97,98,99
            };
        }

        public static class SexoConstants
        {
            public static IEnumerable<string> Tipos = new List<string>
            {
                "Masculino",
                "Feminino",
                "Outro"
            };
        }

        public static class EstadoConstants
        {
            public static IEnumerable<(string Nome, string Uf)> Estados = new List<(string Nome, string Uf)>
            {
                 ("Acre", "AC"),
                 ("Alagoas", "AL"),
                 ("Amapá", "AP"),
                 ("Amazonas", "AM"),
                 ("Bahia", "BA"),
                 ("Ceará", "CE"),
                 ("Distrito Federal", "DF"),
                 ("Espírito Santo", "ES"),
                 ("Goiás", "GO"),
                 ("Maranhão", "MA"),
                 ("Mato Grosso", "MT"),
                 ("Mato Grosso do Sul", "MS"),
                 ("Minas Gerais", "MG"),
                 ("Pará", "PA"),
                 ("Paraíba", "PB"),
                 ("Paraná", "PR"),
                 ("Pernambuco", "PE"),
                 ("Piauí", "PI"),
                 ("Rio de Janeiro", "RJ"),
                 ("Rio Grande do Norte", "RN"),
                 ("Rio Grande do Sul", "RS"),
                 ("Rondônia", "RO"),
                 ("Roraima", "RR"),
                 ("Santa Catarina", "SC"),
                 ("São Paulo", "SP"),
                 ("Sergipe", "SE"),
                 ("Tocantins", "TO"),
            };
        }

        public static class ProfissionalTypeConstants
        {
            public static IEnumerable<string> Tipos = new List<string>
            {
                "Rodeio"
            };
        }
    }
}
