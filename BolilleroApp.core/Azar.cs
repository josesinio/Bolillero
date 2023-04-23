namespace BolilleroApp.core;

public class Azar : IAzar
{
        private Random _random { get; set; }
    public Azar()
        => _random = new Random(DateTime.Now.Millisecond);
    public int SacarIndice(List<int> Adentro)
    =>_random.Next(0,Adentro.Count);
}
