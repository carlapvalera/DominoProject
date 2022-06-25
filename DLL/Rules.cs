namespace Project;
public class Action : IAction// implemetacion de la interface
{
    Table table;
    public bool Add { get; set; }
    public Action(Table table)
    {
        this.table = table;
    }
    public List<Piece> ToAdd(List<Piece> hand)
    {
        List<Piece> aux = new();
        aux = Double(hand);
        if (aux.Count > 0) Add = true;
        foreach (Piece piece in aux)
            hand.Add(piece);
        return hand;
    }
    public List<Piece> ToSub(List<Piece> hand)
    {
        List<Piece> aux = new();
        bool change;
        int count = hand.Count;
        do
        {
            aux = Double(hand);
            if (aux.Count > 0)
                change = true;
            else
                change = false;

            while (change)
                Change(hand, aux, count);

        } while (Double(hand).Count > 0);
        return hand;
    }
    private List<Piece> Change(List<Piece> hand, List<Piece> aux, int n)//cambiar los dobles envontrados en la mano del jugador por nuevas fichas
    {
        List<Piece> list = new List<Piece>();
        for (int i = 0; i < aux.Count; i++)
            for (int j = 0; j < hand.Count; j++)
            {
                if (aux[i].Equals(hand[j]))
                {
                    hand.RemoveAt(j);
                }

            }
        list = NewDistribute(hand, n);
        foreach (Piece piece in aux)
        {
            table.piecesOutGame.Add(piece);
        }
        foreach (Piece piece in list)
        {
            hand.Add(piece);
        }
        return hand;
    }
    private List<Piece> NewDistribute(List<Piece> hand, int n)//volver a repartirle fichas al jugador hasta la cantidad deseada
    {
        Random random = new Random();
        int aux = 0;
        for (int i = 0; i < n; i++)
        {
            aux = random.Next(table.piecesOutGame.Count);
            hand.Add(table.piecesOutGame[aux]);
            table.piecesOutGame.RemoveAt(aux);
        }
        return hand;
    }
    private List<Piece> Double(List<Piece> hand)//todos los dobles presentes en la mano del jugador
    {
        List<Piece> aux = new();
        foreach (Piece piece in hand)
            if (piece.right == piece.left)
                aux.Add(piece);
        return aux;
    }
}
