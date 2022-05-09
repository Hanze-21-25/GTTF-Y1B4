public class Player{
    private int defaultLives { get; set; }
    public int money { get; set; }
    private int lives;

    /**
     * Sets default values if none set.
     */
    public void Initialise() {
        defaultLives = 3;
        if (lives == 0) {
            lives = defaultLives;
        }
    }

    public void Damage() {
        lives--;
    }

    public bool IsAlive() {
        return lives > 0;
    }
}