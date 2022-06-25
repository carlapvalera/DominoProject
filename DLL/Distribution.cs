namespace Project;
public class Distribute : IDistribution
{
    List<Player> players = new();
    int distribute = 0;
    Table table;
    public Distribute(List<Player> players, int distribute, Table table)
    {
        this.table = table;
        this.players = players;
        this.distribute = distribute;
        Distribution();
    }
    public void Distribution()
    {
        Random random = new Random();
        List<Piece> total = new List<Piece>();
        total = Clone(table.piecesTotal);
        for (int j = 0; j < distribute; j++)
            for (int i = 0; i < players.Count; i++)
            {
                int a = random.Next(total.Count);
                players[i].Hand.Add(total[a]);
                total.RemoveAt(a);
            }
        table.piecesOutGame = total;
    }
    private List<Piece> Game(List<Player> players)
    {
        List<Piece> player_aux = new();
        foreach (var player in players)
            foreach (var item in player.Hand)
            {
                player_aux.Add(item);
            }
        return player_aux;
    }
    private List<Piece> Clone(List<Piece> val)
    {
        List<Piece> aux = new();
        foreach (Piece piece in val)
        {
            aux.Add(piece);
        }
        return aux;
    }
}
