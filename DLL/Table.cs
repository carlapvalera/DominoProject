namespace Project;
public class Table
{
    public List<Player> players { get; }

    public static IStart? start { get; set; }

    public static int[]? stats { get; set; }

    public static List<Piece>? piecesInGame { get; set; }

    public static List<Piece>? piecesOutGame { get; set; }

    public static List<Player>? Pass { get; set; }

    public static List<Piece>? piecesTotal { get; set; }

    public static int left
    {
        get
        {
            if (piecesInGame != null)
                return piecesInGame[0].left;
            else
                return -1;

        } 
    }


    public static int right 
    {
        get
        {
            if (piecesInGame != null)
                return piecesInGame[piecesInGame.Count - 1].right;
            else
                return -1;

        } 
    }

    public static void Eject(Piece piece)
    {
        if (piece != null)
        {
            if (piecesInGame== null || piece.right == left) ToLeft(piece);
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