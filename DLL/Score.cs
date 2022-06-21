namespace Project;
public class Calcute : IScoreCalculator
{
    List<Player> players = new();
    public Calcute(List<Player> players)
    {
        this.players = players;
    }
    public void Score()
    {
        List<double> score = new List<double>();
        for (int i = 0; i < players.Count; i++)
            for (int j = 0; j < players[i].Hand.Count; j++)
            {

                score.Add(players[i].Hand[j].left);
                score[i] += players[i].Hand[j].right;

            }
        for (int i = 0; i < players.Count; i++)
        {
            players[i].Score = score[i];
        }
    }
}