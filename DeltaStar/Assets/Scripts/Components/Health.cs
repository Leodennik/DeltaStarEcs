using System;
using UnityEngine;

namespace DeltaStar.Components
{
    public struct Health
    {
        private float _value;
        private float _maxValue;

        public void Init(float value)
        {
            _value = value;
            _maxValue = value;
        }

        public void AddValue(float value)
        {
            _value += value;
            _value = Mathf.Clamp(_value, 0.0f, _maxValue);
        }

        public float GetValue()
        {
            return _value;
        }
        
        public float GetValueNormalized()
        {
            return _value / _maxValue;
        }

        public bool IsZero()
        {
            return _value <= 0;
        }

        public bool IsMaxValue()
        {
            return _value >= _maxValue;
        }
    }
}