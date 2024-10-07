using JornadaMilhasV1.Modelos;

namespace JornadaMilhas.Testç
{
    public class OfertaViagemConstrutor
    {
        [Fact]
        public void RetornaOfertaValidaQuandoDadosValidos()
        {
            //Arrange
            Rota rota = new("Salvador", "Rio de Janeiro");
            Periodo periodo = new(DateTime.Now, DateTime.Now.AddDays(1));
            double preco = 100.0;
            var validacao = true;

            //Act
            OfertaViagem oferta = new(rota, periodo, preco);

            //Assert
            Assert.Equal(validacao, oferta.EhValido);
        }

        [Fact]
        public void RetornaMensagemDeErroDeRotaOuPeriodoInvalidosQuandoARotaForNula()
        {
            Rota rota = null;
            Periodo periodo = new(DateTime.Now, DateTime.Now.AddDays(1));
            double preco = 100.0;

            OfertaViagem oferta = new(rota, periodo, preco);

            Assert.Contains("A oferta de viagem não possui rota ou período válidos.", oferta.Erros.Sumario);

            Assert.False(oferta.EhValido);
        }

        [Fact]
        public void RetornaMensagemDeErroDePeriodoInvalidoQuandoADataDeIdaForMaiorQueADataDeVolta()
        {
            //Arrange
            Rota rota = new("Salvador", "Rio de Janeiro");
            DateTime dataInicial = DateTime.Now.AddDays(1);
            DateTime dataFinal = DateTime.Now;
            Periodo periodo = new(dataInicial, dataFinal);

            //Act
            OfertaViagem oferta = new(rota, periodo, 100.0);

            //Assert
            Assert.Contains("Erro: Data de ida não pode ser maior que a data de volta.", oferta.Erros.Sumario);

            Assert.False(oferta.EhValido);
        }

        [Fact]
        public void RetornaMensagemDeErroDePrecoInvalidoQuandoPrecoMenorQueZero()
        {
            //Arrange
            Rota rota = new("Salvador", "Rio de Janeiro");
            Periodo periodo = new(DateTime.Now, DateTime.Now.AddDays(1));
            double preco = -100.0;

            //Act
            OfertaViagem oferta = new(rota, periodo, preco);

            //Assert
            Assert.Contains("O preço da oferta de viagem deve ser maior que zero.", oferta.Erros.Sumario);

            Assert.False(oferta.EhValido);
        }
    }
}