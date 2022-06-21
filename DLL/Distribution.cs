﻿namespace Project;
public class Distribute : IDistribution
{
    List<Player> players = new();
    int distribute = 0;
    public Distribute(List<Player> players, int distribute)
    {
        this.players = players;
        this.distribute = distribute;
        Distribution();
    }
    public void Distribution()
    {
        Random random = new Random();
        List<Piece> total = new List<Piece>();
        total = Clone(Table.piecesTotal);
        for (int j = 0; j < distribute; j++)
            for (int i = 0; i < players.Count; i++)
            {
                int a = random.Next(total.Count);
                players[i].Hand.Add(total[a]);
                total.RemoveAt(a);
            }
        Table.piecesOutGame = total;
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
