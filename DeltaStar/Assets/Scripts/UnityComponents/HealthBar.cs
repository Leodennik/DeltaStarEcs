using UnityEngine;
using UnityEngine.UI;

namespace DeltaStar.UnityComponents
{
    [RequireComponent(typeof(Image))]
    public class HealthBar : MonoBehaviour
    {
        private float _fill = 1.0f;

        private Image _bar;

        // Start is called before the first frame update
        public void Init()
        {
            _bar = GetComponent<Image>();
        }

        public float Get()
        {
            return _fill;
        }
        
        public void Add(float value)
        {
            Set(Get()+value);
        }

        public void Set(float energyPercent)
        {
            _fill = energyPercent;
            _bar.fillAmount = _fill;
        }
    }
}
