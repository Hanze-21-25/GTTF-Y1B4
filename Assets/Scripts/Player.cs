public class Player {

    public int Money { get; private set; }
    public int Rounds { get; private set; }
    public int Lives { get; private set; }

    public Player() {
        Money = 300;
        Rounds = 0;
        Lives = 20;
    }
}