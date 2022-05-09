namespace Behaviour{
    /**
     * Provides behaviour interface for all living things
     * or "killable" things.
     */
    public interface ILiving{
        /// Damages this
        public void Damage(int damage);
    }
}