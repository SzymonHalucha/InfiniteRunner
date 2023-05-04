using System.Collections.Generic;
using UnityEngine;
using Game.Stats;

namespace Game.Player
{
    public class PlayerStats : PlayerBaseComponent
    {
        [SerializeField] private List<ConstStat> _constStats = new();
        [SerializeField] private List<DynamicStat> _dynamicStats = new();

        private Dictionary<StatType, ConstStat> _cahcedConstStats = new();
        private Dictionary<StatType, DynamicStat> _cachedDynamicStats = new();

        private void OnEnable()
        {
            _cahcedConstStats.Clear();
            _cachedDynamicStats.Clear();
        }

        private void OnDisable()
        {
            foreach (ConstStat stat in _constStats)
                stat.Reset();

            foreach (DynamicStat stat in _dynamicStats)
                stat.Reset();
        }

        public ConstStat GetConstStat(StatType type)
        {
            if (!_cahcedConstStats.ContainsKey(type))
                _cahcedConstStats.Add(type, _constStats.Find(stat => stat.Type == type));

            return _cahcedConstStats[type];
        }

        public DynamicStat GetDynamicStat(StatType type)
        {
            if (!_cachedDynamicStats.ContainsKey(type))
                _cachedDynamicStats.Add(type, _dynamicStats.Find(stat => stat.Type == type));

            return _cachedDynamicStats[type];
        }
    }
}