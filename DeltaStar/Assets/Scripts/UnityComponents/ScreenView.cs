using UnityEngine;

namespace DeltaStar.UnityComponents
{
    public class ScreenView : MonoBehaviour
    {
        public void Show(bool value)
        {
            gameObject.SetActive(value);
        }
    }
}