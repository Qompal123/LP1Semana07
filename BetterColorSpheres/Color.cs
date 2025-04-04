namespace BetterColorSpheres
{
    public class Color
    {
        private readonly byte red;
        private readonly byte green;
        private readonly byte blue;
        private readonly byte alpha;


        public Color(byte red, byte green, byte blue, byte alpha)
        {
            this.red = red;
            this.green = green;
            this.blue = blue;
            this.alpha = alpha;
        }

        public Color(byte red, byte green, byte blue) : this(red, green, blue, 255) { }

        public int GetGrey()=> (byte) (red + green + blue) / 3;
        
        public int GetRed()=> red;

        public int GetGreen()=> green;

        public int GetBlue()=> blue;

        public int GetAlpha()=> alpha;
    }
}