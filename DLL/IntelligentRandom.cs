namespace Project;
public class IntelligentRandom : IStrategy
{
    List<Piece> itIsOkPlayed = new List<Piece>();
    Player player = new Player();
    int cursor = 0;
    public IntelligentRandom()
    {
        this.itIsOkPlayed = itIsOkPlayed;
        this.player = player;
        this.cursor = cursor;
    }
    public Piece PieceToPlay(List<Piece> itIsOkPlayed, Player player, int cursor)
    {
        List<Piece> intelligentplays = new List<Piece>();
        IStrategy istrategy = new IntelligentBotagorda();
        intelligentplays = istrategy.PieceCanPlay(itIsOkPlayed, player, cursor);
        if (intelligentplays != null)
        {
            return OK(intelligentplays);
        }
        else if (itIsOkPlayed != null)// en el caso que no haya una jugada que pase al proximo jugador juega como un random usual
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
        Random random = new Random();

        int item = random.Next(0, intelligent.Count);
        return intelligent[item];
    }

}
