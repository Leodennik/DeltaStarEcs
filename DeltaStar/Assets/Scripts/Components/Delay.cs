namespace DeltaStar.Components
{
    public struct Delay
    {
        public float timer;
        public float delayInSeconds;

        public bool IsReady()
        {
            return timer >= delayInSeconds;
        }
        
        public void Restart()
        {
            timer = 0;
        }
    }
}