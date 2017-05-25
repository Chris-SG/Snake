namespace Snake
{
    public class BonusFood : Item
    {
        private int _lifetime;

        public BonusFood(int x, int y, int aLifetime) : base(x, y)
        {
            _lifetime = aLifetime;
        }
    }
}