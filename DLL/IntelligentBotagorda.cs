namespace Project;
public class IntelligentBotagorda : IStrategy//implementacion de la interface
{
    List<Piece> itIsOkPlayed = new List<Piece>();
    Player player;
    int cursor = 0;
    Table table;
    public IntelligentBotagorda(List<Piece> itIsOkPlayed, Player player, int cursor,Table table)
    {
        this.itIsOkPlayed = itIsOkPlayed;
        this.player = player;
        this.cursor = cursor;
        this.table = table; 
    }


    public Piece PieceToPlay(List<Piece> itIsOkPlayed, Player player, int cursor)
    {
        List<Piece> intelligentplays = new List<Piece>();
        IStrategy istrategy = new IntelligentBotagorda(itIsOkPlayed,player,cursor,table);
        intelligentplays = istrategy.PieceCanPlay(itIsOkPlayed, player, cursor,table);
        if (intelligentplays != null)
        {
            return OK(intelligentplays);
        }
        else if (itIsOkPlayed != null)// en el caso que no haya una jugada que pase al proximo jugador juega como un botagorda usual
        {
            return OK(itIsOkPlayed);
        }
        else
        {
            return null;
        }
    }


    private Piece OK(List<Piece> intelligent)
    {
        List<int> valores = new List<int>();
        int cant = 0;
        foreach (var item in intelligent)
        {
            valores.Add(item.right);
            valores[cant] += item.left;
            cant++;
        }
        return intelligent[valores.IndexOf(valores.Max())];

    }
}
