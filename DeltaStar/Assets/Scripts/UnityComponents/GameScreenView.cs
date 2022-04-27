using UnityEngine;

namespace DeltaStar.UnityComponents
{
    public class GameScreenView : ScreenView
    {
        [SerializeField] private HealthBar barHealth;
        [SerializeField] private HealthBar barEnergy;
        [HideInInspector] public int selectedShipIndex = 0;
        
        public HealthBar GetEnergyBar()
        {
            return barEnergy;
        }

        public HealthBar GetHealthBar()
        {
            return barHealth;
        }
    }
}