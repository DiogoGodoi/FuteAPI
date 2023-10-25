namespace FuteAPI.Model
{

    public class Posicao
    {
        public int posicao { get; set; }
        public int pontos { get; set; }
        public Clubes time { get; set; }
        public int jogos { get; set; }
        public int vitorias { get; set; }
        public int empates { get; set; }
        public int derrotas { get; set; }
        public int gols_pro { get; set; }
        public int gols_contra { get; set; }
        public int saldo_gols { get; set; }
        public double aproveitamento { get; set; }
        public int variacao_posicao { get; set; }
        public string[] ultimos_jogos { get; set; }
    }
}

