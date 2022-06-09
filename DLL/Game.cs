class Game<T>
{
    Table table{get;set;}
    int cursor{get;set;}
    List<Player> players;
    GameRules<T> gameRules{get;}
    public Game(GameRules<T> gameRules, List<Player> players,int n){
        this.gameRules=gameRules;
        this.players=players;
        table=new Table(n,gameRules.start,players);
        cursor=-1;
    }
    //Reparticion();
    //while (true)
    //{
    //  if(!endGame())
    //  { 
    //      cursorAux=passToPass.jugadorSiguiente();
    //      table.Eject(jugador[cursor].Play(estrategia,table,table.JugadasValidas(),cursorAux));
    //      calculateScore();
    //      cursor=cursorAux;
    //  }
    //} 
    //a Play la talla es pasarle una copia d todo para que no se me modifique nada 
    //y ver como se hace pa no poder ver las fichas de los demas jugadores
}