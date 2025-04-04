namespace BetterColorSpheres{
    public class Sphere
    {
        private float radius;
        private Color color;

        private int timesThrown;

        public Sphere(Color color, int radius)
        {
            this.color = color;
            this.radius = radius;
            this.timesThrown = 0;
        }

        public void Pop()
        {
            this.radius = 0;
        }

        public void Throw()
        {
            if (this.radius > 0)
            {
            this.timesThrown++;
            }
        }

        public int GetTimesThrown() => timesThrown;
    }
}