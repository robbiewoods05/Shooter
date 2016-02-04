using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shooter
{
    public class StateManager
    {
        private string _currentState, _lastState;
        
        public string CurrentState { get { return _currentState; } } 

        public StateManager(string state)
        {
            _currentState = state;
        }

        public virtual void Set(string state)
        {
          _currentState = state;
        }
        public virtual void Pop()
        {
            _currentState = _lastState;
            _lastState = null;
        }

        public virtual void Push(string state)
        {
            if (_currentState != string.Empty)
                _lastState = _currentState;

            _currentState = state;
        }
    }
}
