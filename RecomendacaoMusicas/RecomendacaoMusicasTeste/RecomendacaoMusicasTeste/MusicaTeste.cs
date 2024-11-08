using RecomendacaoMusicas;

namespace RecomendacaoMusicasTeste
{
    public class MusicaTeste
    {
        [Fact]
        public void InicializarMusicaComNomeTeste()
        {
            var nomeMusica = "Musica Teste";

            Musica musica = new Musica(nomeMusica);

            Assert.Equal(nomeMusica, musica.Nome);
        }

        [Fact]
        public void AtribuindoIdNaMusicaTeste()
        {
            var nomeMusica = "Musica Teste";
            int id = 15;

            Musica musica = new Musica(nomeMusica) { Id = id};        

            Assert.Equal(id, musica.Id);
        }

        [Fact]
        public void ToStringTeste()
        {
            var nomeMusica = "Musica Teste";
            int id = 15;
            Musica musica = new Musica(nomeMusica) { Id = id };

            Assert.NotEmpty(musica.ToString());
            Assert.Contains(nomeMusica, musica.ToString());
            Assert.Contains(id.ToString(), musica.ToString());
        }
    }
}