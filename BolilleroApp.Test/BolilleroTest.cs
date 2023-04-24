using BolilleroApp.core;

namespace BolilleroApp.Test;

public class BolilleroTest
{
    public Bolillero Bolillero1 { get; set; }
    public BolilleroTest() => Bolillero1 = new Bolillero(10, new Azar());


    [Fact]
    public void SacarBolillaTest()
    {

        var numero = Bolillero1.SacarBolillas();
        var esperado = 0;
        var esperado1 = 9;
        var esperado2 = 1;

        Assert.Equal(numero, esperado);
        Assert.Equal(esperado1, Bolillero1.Adentro.Count);
        Assert.Equal(esperado2, Bolillero1.Afuera.Count);
    }

    [Fact]
    public void ReingresarBolillaTest()
    {
        Bolillero1.SacarBolillas();
        Bolillero1.ReingresarBolillas();
        var esperado = 10;
        var esperado1 = 0;

        Assert.Equal(esperado, Bolillero1.Adentro.Count);
        Assert.Equal(esperado1, Bolillero1.Afuera.Count);
    }
    [Fact]
    public void JugarGana()
    {
        var intentoGana = Bolillero1.Jugar(Jugada: new List<int>() { 0, 1, 2, 3 });
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
}