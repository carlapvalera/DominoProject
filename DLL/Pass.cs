using System.Collections;

namespace Project;
public class Pass : IPassToPass
{
    List<Player> players = new();
    Player player;
    public Pass(List<Player> players, Player player)
    {
        this.players = players;

        for (int i = 0; i < players.Count; i++)
        {
            if (players[i]== player)
            this.player = player;
            Change();
        }
    }
    private void Change()
    {
        List<Player> player_aux = new();
        for (int i = 0; i < players.Count; i++)
        {
            if (players[i] == player)
            {
                for (int j = i; j < players.Count; j++)
                {
                    player_aux.Add(players[i]);
                }
                for (int k = 0; k < i; k++)
                {
                    player_aux.Insert(0, players[k]);
                }
            }

        }
        players = player_aux;
    }

    public Player Next (Player player)
    {
        int aux = Equals(player);
        if (aux == players.Count)
            return players[0];
        else
            return players[aux + 1];
    }
    private int Equals( Player player)
    {
        int aux =0;
        foreach (var item in players)
        {
            if (player == item)
                return aux;
            aux++;
        }
        return -1;
    }
}
//public class PassOpcional : IPassToPass
//{
//    List<Player> players = new();
//    int cursor = 0;
//    Table table = new Table();
//    public PassOpcional(List<Player> players, int cursor)
//    {
//        this.players = players;
//        this.cursor = cursor;

//    }

//    public Player Current
//    {
//        get
//        {
//            if (players[cursor] == Table.Pass[Table.Pass.Count - 1])//si se pasa el jugadoer cambiar el ciclo
//                players.Reverse();
//            cursor++;
//            MoveNext();
//            return players[cursor];
//        }
//    }


//    public void MoveNext()
//    {
//        if (cursor < 0)
//        {
//            int aux = players.Count + cursor;
//            cursor = aux;
//        }
//        else if (cursor >= players.Count)
//        {
//            int aux = cursor - players.Count;
//            cursor = aux;
//        }
//    }
//}
