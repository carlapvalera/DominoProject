namespace Project;
public class IntelligentRandom : IStrategy
{
    public IntelligentRandom()
    {

    }
    public Piece PieceToPlay(List<Piece> itIsOkPlayed, Player player, int cursor)
    {
        List<Piece> intelligentplays = new List<Piece>();
        IStrategy istrategy = new IntelligentBotagorda();
        intelligentplays = istrategy.PieceCanPlay(itIsOkPlayed, player, cursor);
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
