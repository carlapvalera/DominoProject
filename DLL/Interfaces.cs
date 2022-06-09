interface IPassToPass<T>
{
    public T Current{get;}
    public bool MoveNext();
}
interface IGameOrder{
    public int Cursor{get;}
    public bool Condicion{get;}
}
interface IFinish
{
   public bool EndGame();
}
interface IStart{
    public void Reparticion();
}
interface IScoreCalculator{
    public List<double> Score();
}
interface IAction<T>{
    public bool ToAdd(T item);
    public bool ToSub(T item);

}
interface IStrategy<T>{
    public T PieceToPlay(Table table,List<T> itIsOkPlayed,Player player,int cursor);
}