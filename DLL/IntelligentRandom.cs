namespace Project;
public class IntelligentRandom : IStrategy
{
    List<Piece> itIsOkPlayed = new List<Piece>();
    Player player;
    int cursor = 0;
    Table table;
    public IntelligentRandom(List<Piece> itIsOkPlayed, Player player, int cursor,Table table)
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
        if (intelligentplays.Count != 0)
        {
            return OK(intelligentplays);
        }
        else if (itIsOkPlayed.Count != 0)// en el caso que no haya una jugada que pase al proximo jugador juega como un random usual
        {
            return OK(itIsOkPlayed);
        }
        else
        {
            return null;
        }
    }
    private Piece? OK(List<Piece> intelligent)
    {
        Random random = new Random();
        if(intelligent.Count !=0)
        {
            int item = random.Next(0, intelligent.Count);
            return intelligent[item];
        }
        else
        {
            return null;
        }
    }

}
