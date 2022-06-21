namespace Project;
public class Table
{
    public List<Player> players { get; }

    public static IStart start { get; set; }

    public static int[] stats { get; set; }

    public static List<Piece> piecesInGame { get; set; }

    public static List<Piece> piecesOutGame { get; set; }

    public static List<Player> Pass { get; set; }

    public static List<Piece> piecesTotal { get; set; }

    public static int left { get { return piecesInGame[0].left; } }

    public static int right { get { return piecesInGame[piecesInGame.Count - 1].right; } }

    public static void Eject(Piece piece)
    {
        if (piece != null)
        {
            if (piecesInGame.Count == 0 || piece.right == left) ToLeft(piece);
            else if (piece.left == right) ToRight(piece);
            else
            {
                piece.Turn();
                Eject(piece);
            }
            stats[piece.left]++;
            stats[piece.right]++;
        }
    }
    public static void ToLeft(Piece piece)
    {
        piecesInGame.Add(piece);
    }

    public static void ToRight(Piece piece)
    {
        piecesInGame.Insert(piecesInGame.Count, piece);
    }

}