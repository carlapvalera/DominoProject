namespace Project; 
public class Final : IFinal
{
    public bool EndGame(List<Player> players)//revisar el metodo el ultimo false
    {
        List<Player> notplay = new List<Player>();
        List<Player> order = new List<Player>();
        List<Player> pass = new();
        if (Table.Pass != null || Table.Pass.Count !=0)
        {
            pass = Clone(Table.Pass);

            // debido al jugador en el que se inicializan los pases averiguar el ciclo necesario para que se termine el juego
            foreach (var item in players)
            {
                if (item.Hand.Count == 0)
                    return true;
                else
                {
                    foreach (var x in pass)
                    {
                        notplay.Add(x);// lista de jugadores pasados 

                        if (notplay.Count == 1)
                            order = Necesary(notplay[0], players);// crear el ciclo dado por el jugador actual
                    }

                    return TablePass(order,ref notplay);// comprobar si se cumplio el ciclo
                }
            }
        }
        return false;
    }
    private List<Player> Clone(List<Player> val)//hacer una copia de la lista
    {
        List<Player> aux = new();
        foreach (var piece in val)
        {
            aux.Add(piece);
        }
        return aux;
    }
    private List<Player> Necesary(Player player, List<Player> players)
    //orden de los jugadores en que se necesitan pasar para terminar el juego
    {
        List<Player> aux = new();
        Player many = new Player();
        int count = 0;
        int lol = 1;
        foreach (var item in players)
        {
            if (player == item)
            {
                aux.Add(item);
                many = item;
                continue;
            }
            count++;
        }
        for (int i = 1; ; i++)
        {
            if (lol == players.Count)
                return aux;
            else if (count + i >= players.Count)
                count = 0;

            aux.Add(players[count + 1]);
            count++;
            lol++;
        }
    }
    private bool TablePass(List<Player> order, ref List<Player> notplay)
    // comprobar si ya se paso tod a la mesa y se finalizo el juego por ende
    {
        if (order.Count == 0 || notplay.Count == 0)
            return false;
        int count = 0;
        foreach (var item in notplay)
        {
            if (notplay.Count >= order.Count)
            {
                if (notplay[count] != order[count])
                    notplay.Remove(item);
                TablePass(order, ref notplay);
            }
            else if (notplay.Count == order.Count)
                return true;
            else
                return false;
            count++;

        }
        return false;

    }
}
