using DeltaStar.UnityComponents;

namespace DeltaStar.Systems
{
    public struct HealthUi
    {
        public HealthBar bar;

        public void Init(HealthBar energyBar, float initialValue)
        {
            bar = energyBar;
            bar.Init();
            bar.Set(initialValue);
        }
    }
}