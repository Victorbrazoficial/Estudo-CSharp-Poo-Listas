using System;
namespace ByteBank.Modelos.DataTempo
{
    public class TestandoDateTime
    {
        public DateTime DataFimDopagamento { get; set; } = new DateTime(2022,8,15);
        
        public DateTime dataCorrente = DateTime.Now;

        public void Print()
        {
            Console.WriteLine(DataFimDopagamento);
        }

        public void PrintTimeNow()
        {
            Console.WriteLine(dataCorrente);
        }

        public TimeSpan DiasFaltantes()
        {
            TimeSpan diferenca = DataFimDopagamento - dataCorrente;
            Console.WriteLine(diferenca);
            return diferenca;
        }
    }
}