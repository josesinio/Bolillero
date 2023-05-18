using BolilleroApp.core;

namespace BolilleroApp.Test;

public class BolilleroTest
{
    public Bolillero Bolillero1 { get; set; }
    public BolilleroTest() => Bolillero1 = new Bolillero(10, new AzarPrimero());


    [Fact]
    public void SacarBolillaTest()
    {
        var numero = Bolillero1.SacarBolilla();
        var esperado = 0;
        var esperado1 = 9;
        var esperado2 = 1;

        Assert.Equal(esperado, numero);
        Assert.Equal(esperado1, Bolillero1.Adentro.Count);
        Assert.Equal(esperado2, Bolillero1.Afuera.Count);
    }

    [Fact]
    public void ReingresarBolillaTest()
    {
        Bolillero1.SacarBolilla();
        Bolillero1.ReingresarBolillas();
        var esperado = 10;
        var esperado1 = 0;

        Assert.Equal(esperado, Bolillero1.Adentro.Count);
        Assert.Equal(esperado1, Bolillero1.Afuera.Count);
    }
    [Fact]
    public void JugarGana()
    {
        var jugada = new List<int>() { 0, 1, 2, 3 };
        var intentoGana = Bolillero1.Jugar(jugada);

        Assert.True(intentoGana);
    }

    [Fact]
    public void JugarPierde()
    {
        var intentoPierde = Bolillero1.Jugar(Jugada: new List<int> { 4, 2, 1 });

        Assert.False(intentoPierde);
    }

    [Fact]
    public void JugarNVecesGana()
    {
        var jugada = Bolillero1.JugarNVeces(Jugada: new List<int> { 0, 1 }, 1);

        Assert.Equal(1, jugada);
    }

    [Fact]
    public void ClonarBolillero()
    {
        var BolilleroCopia = Bolillero1.Clonar();

        Assert.Equal(Bolillero1.Adentro, BolilleroCopia.Adentro);
        Assert.Equal(Bolillero1.Afuera, BolilleroCopia.Afuera);
    }
}