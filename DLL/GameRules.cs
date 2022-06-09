class GameRules<T>
{
    public IPassToPass<T> passToPass{get;}
    public IGameOrder gameOrder{get;}
    public IFinish finish{get;}
    public IStart start{get;}
    public IScoreCalculator scoreCalculator{get;}
    public IAction<T> action{get;}

    public GameRules(IPassToPass<T> passToPass, IGameOrder gameOrder, IFinish finish, IStart start, IScoreCalculator scoreCalculator, IAction<T> action){
        this.passToPass = passToPass;
        this.gameOrder=gameOrder;
        this.finish=finish;
        this.start=start;
        this.scoreCalculator=scoreCalculator;
        this.action=action;
    } 

}
