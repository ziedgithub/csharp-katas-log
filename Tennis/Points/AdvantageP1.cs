namespace Tennis.Points
{

    public class AdvantageP1 : IPoint
    {
        public string GetScore(string name)
        {
            return $"Advantage {name}";
        }

        public IPoint ScoreP1()
        {
            return new WinP1();
        }

        public IPoint ScoreP2()
        {
            return new Deuce();
        }
    }

}
