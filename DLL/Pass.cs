namespace Project;
public class Pass : IPassToPass
{
    List<Player> players = new();
    int cursor = 0;
    public Pass(List<Player> players, Player player)
    {
        this.players = players;

        for (int i = 0; i < players.Count; i++)
        {
            if (players[i]== player)
            this.cursor = i;

        }
    }
    public Player Current
    {
        get
        {
            cursor++;
            MoveNext();
            return players[cursor];
        }
    }
    public void MoveNext()
    {
        if (cursor < 0)
        {
            int aux = players.Count + cursor;
            cursor = aux;
        }
        else if (cursor >= players.Count)
        {
            int aux = cursor - players.Count;
            cursor = aux;
        }
    }
}
public class PassOpcional : IPassToPass
{
    List<Player> players = new();
    int cursor = 0;
    Table table = new Table();
    public PassOpcional(List<Player> players, int cursor)
    {
        this.players = players;
        this.cursor = cursor;

    }

    public Player Current
    {
        get
        {
            if (players[cursor] == Table.Pass[Table.Pass.Count - 1])//si se pasa el jugadoer cambiar el ciclo
                players.Reverse();
            cursor++;
            MoveNext();
            return players[cursor];
        }
    }


    public void MoveNext()
    {
        if (cursor < 0)
        {
            int aux = players.Count + cursor;
            cursor = aux;
        }
        else if (cursor >= players.Count)
        {
            int aux = cursor - players.Count;
            cursor = aux;
        }
    }
}
