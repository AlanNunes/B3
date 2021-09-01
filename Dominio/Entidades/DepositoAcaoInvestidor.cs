namespace Dominio.Entidades
{
    public class DepositoAcaoInvestidor
    {
        public int DepositoAcaoInvestidorId { get; set; }
        public int PapelId { get; set; }
        public Papel Papel { get; set; }
        public int InvestidorId { get; set; }
        public Investidor Investidor { get; set; }
    }
}
