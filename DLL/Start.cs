namespace Project;
public class ClassicStart : IStart //implemetacion de la interface
{
    List<Player> players = new();
    Random random = new Random();
    List<Piece> pieceOutGame = new List<Piece>();
    public ClassicStart(List<Player> players, List<Piece> pieceOutGame)
    {
        this.players = players;
        this.pieceOutGame = pieceOutGame;
    }
    public Piece Start()
    {
        return pieceOutGame[random.Next(0, pieceOutGame.Count)];
    }

    public Player First()
    {
        return players[random.Next(0, players.Count)];
    }
}

public class PlayerStart : IStart
{
    List<Player> players = new();

    List<Piece> pieceOutGame = new();
    int aux = 0;
    Table table = new Table();
    public PlayerStart(List<Player> players, List<Piece> pieceOutGame)
    {
        Random random = new Random();
        aux = random.Next(0, players.Count);
        this.players = players;
        this.pieceOutGame = pieceOutGame;
    }

    public Player First()
    {
        return players[aux];
    }
    public Piece Start()
    {
        return players[aux].Play(aux);
    }
}
