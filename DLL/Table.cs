class Table
{
    public List<Player> players{get;}
    IStart start{get;}
    public int[] stats{get;private set;}
    public List<Piece> piecesInGame{get;}
    public List<Piece> piecesTotal{get;}
    public Table(int n,IStart start,List<Player> players){
        piecesTotal=piecesGenerator(n);
        piecesInGame=new List<Piece>();
        this.start=start;
        this.players=players;
        stats=new int[n];
    }
    void ToLeft(Piece piece){
        piecesInGame.Add(piece);
    }
    void ToRight(Piece piece){
        piecesInGame.Insert(piecesInGame.Count,piece);
    }
    public void Eject(Piece piece){
        if(piece!=null)
        { 
            if(piecesInGame.Count==0||piece.right==left) ToLeft(piece);
            else if(piece.left == right) ToRight(piece);
            else{
                piece.Turn();
                Eject(piece);
            }
            stats[piece.left]++;
            stats[piece.right]++;
        }
    }
    public int left{get{return piecesInGame[0].left;}}
    public int right{get{return piecesInGame[piecesInGame.Count-1].right;}}
    static List<Piece> piecesGenerator(int n){
        List<Piece> total=new List<Piece>();
        for (int i = 0; i <= n; i++)
        {
            for (int j = i; j <= n; j++)
            {
                total.Add(new Piece(i,j));
            }
        }
        return total;
    }
    List<Piece> itIsAOkPlayed(List<Piece> hand,IAction<Piece> action){
        List<Piece> okPlayed=new List<Piece>();
        for (int i = 0; i < hand.Count; i++)
        {
            if(action.ToSub(hand[i])) continue;
            if(hand[i].left==left||hand[i].left==right||hand[i].right==left||hand[i].right==right||action.ToAdd(hand[i]))
                okPlayed.Add(hand[i]);
        }
        return okPlayed;  
    }
}