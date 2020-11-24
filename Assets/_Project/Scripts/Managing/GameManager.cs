﻿using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts
{
    /// <summary>
    /// Sub-components of game objects should be inherited from this.
    /// </summary>
    public class GameManager : Singleton<GameManager>
    {
        [SerializeField] private GameObject _rewired = null;

        [SerializeField]

        private readonly List<ITick> _lowPriorityTicks = new List<ITick>();
        private readonly List<ITick> _normalPriorityTicks = new List<ITick>();
        private readonly List<ITick> _highPriorityTicks = new List<ITick>();

        private InputWrapper _inputWrapper;

        private int _instanceCounter;
        private int _tick;

        public InputWrapper inputWrapper => _inputWrapper;

        public int Tick => _tick;

        protected override void Setup()
        {
            base.Setup();

            _inputWrapper = GetComponent<InputWrapper>();
        }

        private void OnEnable()
        {
            Instantiate(_rewired, transform);
        }

        private void FixedUpdate()
        {
            for (var i = 0; i < _highPriorityTicks.Count; i++)
                _highPriorityTicks[i].PhysicsTick();

            for (var i = 0; i < _normalPriorityTicks.Count; i++)
                _normalPriorityTicks[i].PhysicsTick();

            for (var i = 0; i < _lowPriorityTicks.Count; i++)
                _lowPriorityTicks[i].PhysicsTick();
        }

        private void Update()
        {
            _tick++;

            for (var i = 0; i < _highPriorityTicks.Count; i++)
                _highPriorityTicks[i].Tick();

            for (var i = 0; i < _normalPriorityTicks.Count; i++)
                _normalPriorityTicks[i].Tick();

            for (var i = 0; i < _lowPriorityTicks.Count; i++)
                _lowPriorityTicks[i].Tick();
        }

        private void LateUpdate()
        {
            for (var i = 0; i < _highPriorityTicks.Count; i++)
                _highPriorityTicks[i].CameraTick();

            for (var i = 0; i < _normalPriorityTicks.Count; i++)
                _normalPriorityTicks[i].CameraTick();

            for (var i = 0; i < _lowPriorityTicks.Count; i++)
                _lowPriorityTicks[i].CameraTick();
        }

        public bool CheckIfAttached(ITick tick)
        {
            if (tick.Id == 0)
            {
                _instanceCounter++;
                tick.SetId(_instanceCounter);
            }

            switch (tick.Priority)
            {
                case TickPriority.High:
                    {
                        var containsInTickers = _highPriorityTicks.Contains(tick);
                        if (containsInTickers)
                            return false;

                        _highPriorityTicks.Add(tick);
                        break;
                    }

                case TickPriority.Normal:
                    {
                        var containsInTickers = _normalPriorityTicks.Contains(tick);
                        if (containsInTickers)
                            return false;

                        _normalPriorityTicks.Add(tick);
                        break;
                    }
                case TickPriority.Low:
                    {
                        var containsInTickers = _lowPriorityTicks.Contains(tick);
                        if (containsInTickers)
                            return false;

                        _lowPriorityTicks.Add(tick);
                        break;
                    }
            }

            return true;
        }

        public bool CheckIfDetached(ITick tick)
        {
            switch (tick.Priority)
            {
                case TickPriority.High:
                    {
                        var containsInTickers = _highPriorityTicks.Contains(tick);
                        if (!containsInTickers)
                            return false;

                        _highPriorityTicks.Remove(tick);
                        break;
                    }
                case TickPriority.Normal:
                    {
                        var containsInTickers = _normalPriorityTicks.Contains(tick);
                        if (!containsInTickers)
                            return false;

                        _normalPriorityTicks.Remove(tick);
                        break;
                    }
                case TickPriority.Low:
                    {
                        var containsInTickers = _lowPriorityTicks.Contains(tick);
                        if (!containsInTickers)
                            return false;

                        _lowPriorityTicks.Remove(tick);
                        break;
                    }
            }

            return true;
        }
    }
}
