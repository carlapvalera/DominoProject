namespace Project;
interface IPiece//interface que define a las piezas del juego 
{
    int left { get; set; }//cara izquierda de la pieza
    int right { get; set; }//cara derecha de la pieza
    void Turn();// metodo que gira la pieza es decir que cambia la cara izquierda por la derecha y viceversa
    string Paint();
}
interface IPlayer// interface que define a los jugadores que participan en el juego
{
    List<Piece> Hand { get; }//mano del jugador, lista de piezas con las que puede jugar
    SortedSet<int> IDoNotHaveProvedInGame { get; }// piezas probadas que mno tiene en juego
    int CountPieces { get { return Hand.Count; } }//cantidad de fichas en mano
    string Name { get; }//nombre de cada jugador
    double Score { get; set; }// puntuacion del mismo
    Piece? Play(int cursor);
    /* metodo que devuelve la pieza que el jugador decea jugar aplicando la estrategia decidida por el usuario de esta forma en la
     que este metodo recibe la estrategia permite a un jugador aplicar mas de una */
    //Piece FirstPlay();//metodo que define la primera pieza que el jugador debe jugar en caso de que sea el primero
}
public interface IStrategy// interface que define las estrategias de cada jugador
{
    Piece PieceToPlay(List<Piece> itIsOkPlayed, Player player, int cursor);
    //metodo que define la pieza a jugar por el jugador que utilice esta estrategia

    List<Piece> PieceCanPlay(List<Piece> itIsOkPlayed, Player player, int cursor, Table table)
    /*lista de piezas que que se a partir de la que la estrategia escoge una para que el jugador jugue vale acotar que esta
    lista de fichas son nada mas que las que contienen las caras que ya se sabe previamente (se ha probado enel jugo que el
    jugador no lleva)*/
    {

        List<int> aux = new List<int>();
        List<Piece> jugadasinteligentes = new List<Piece>();
        for (int i = 0; i < itIsOkPlayed.Count; i++)
        {
            if (table.left == itIsOkPlayed[i].left || table.right == itIsOkPlayed[i].left)
            {
                aux.Add(itIsOkPlayed[i].right);
            }
            else
            {
                aux.Add(itIsOkPlayed[i].left);
            }
        }
        List<int> list = new List<int>();
        foreach (var item in player.IDoNotHaveProvedInGame)
        {
            for (int j = 0; j < aux.Count; j++)
            {
                if (item == aux[j])
                    jugadasinteligentes.Add(itIsOkPlayed[j]);
            }
        }
        return jugadasinteligentes;
    }
}
interface IFinal
{
    bool EndGame(List<Player> players);
}
public interface IStart// define las distintas formas de empezar el juego
{
    Piece Start();// primera pieza que se pondra en el tablero
    Player First();// llama al primer jugador a jugar
}
interface IScoreCalculator
{
    void Score();
}
interface IDistribution
{
    void Distribution();
}
interface IMove
{
    List<Piece> itIsAOkPlayed(List<Piece> hand);
}
interface IAction
// modela la posibilidad de que existan determinadas piexzas que se puedan jugar en cualquien momento del juego o con las que no se pueda jugar
{
    bool Add { get; set; }
    List<Piece> ToAdd(List<Piece> hand);// en el caso que las fichas se puedan jugar en cualquier momento del juego
    List<Piece> ToSub(List<Piece> hand);// en el caso que las fichas no se puedan jugar en juego

}
interface IPassToPass : IEnumerable<Player>
{

}
#region
//interface IPassToPass<T>
//{
//    public T Current{get;}
//    public bool MoveNext();
//}
//interface IGameOrder{
//    public int Cursor{get;}
//    public bool Condicion{get;}
//}
//interface IFinish
//{
//   public bool EndGame();
//}
//interface IStart{
//    public void Reparticion();
//}
//interface IScoreCalculator{
//    public List<double> Score();
//}
//interface IAction<T>{
//    public bool ToAdd(T item);
//    public bool ToSub(T item);

//}
//interface IStrategy<T>{
//    public T PieceToPlay(Table table,List<T> itIsOkPlayed,Player player,int cursor);
//}
#endregion