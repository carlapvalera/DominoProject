namespace Project;
public class Table
{
    public List<Player> players { get; }

    public IStart? start { get; set; }

    public int[] stats { get; set; }

    public List<Piece> piecesInGame { get; set; }

    public List<Piece> piecesOutGame { get; set; }

    public List<Player> Pass { get; set; }

    public List<Piece> piecesTotal { get; set; }

    public Table(int playersCount)
    {
        players = new();
        piecesInGame = new();
        piecesOutGame = new();
        Pass = new();
        piecesTotal = new();
        stats = new int[playersCount]; //no se q es stats, hice esto para q no saliera un error
    }

    public int left
    {
        get
        {
            if (piecesInGame != null)
                return piecesInGame[0].left;
            else
                return -1;

        }
    }


    public int right
    {
        get
        {
            if (piecesInGame != null)
                return piecesInGame[piecesInGame.Count - 1].right;
            else
                return -1;

        }
    }
    public void Eject(Piece piece)
    {
        if (piece != null)
        {
            if (piecesInGame == null || piece.right == left) ToLeft(piece);
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
    public void ToLeft(Piece piece)
    {
        if (piecesInGame == null)
        {
            List<Piece> pieces = new List<Piece>();
            pieces.Add(piece);
            piecesInGame = pieces;
        }
        else
            piecesInGame.Add(piece);
    }

    public void ToRight(Piece piece)
    {
        if (piecesInGame != null)
        {
            piecesInGame.Insert(piecesInGame.Count, piece);
        }
    }

}