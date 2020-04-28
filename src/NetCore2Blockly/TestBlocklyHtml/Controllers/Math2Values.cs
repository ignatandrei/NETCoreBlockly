namespace TestBlocklyHtml
{
    public class Math2Values
    {
        public Math2Values()
        {

        }
        public Math2Values(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public int x { get; set; }
        public int y { get; set; }

        public static Math2Values operator +(Math2Values v, int nr) {
            return new Math2Values(v.x + nr, v.y + nr);
        }
        public static Math2Values operator -(Math2Values v, int nr)
        {
            return new Math2Values(v.x - nr, v.y - nr);
        }
        public static Math2Values operator *(Math2Values v, int nr)
        {
            return new Math2Values(v.x * nr, v.y * nr);
        }
        public static Math2Values operator /(Math2Values v, int nr)
        {
            return new Math2Values(v.x / nr, v.y / nr);
        }
    }
}
