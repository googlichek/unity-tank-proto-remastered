using System;

namespace Game.Scripts
{
    public abstract class BaseEntityNode<TOwner, TState> : IStateMachineNode<TState>
        where TOwner : TickBehaviour
        where TState : struct, Enum
    {
        protected readonly TOwner Owner;
        protected readonly TState NodeState;

        protected TState EnterState;
        protected TState NextState;
        protected TState ExitState;

        protected BaseEntityNode(TOwner owner, TState state)
        {
            Owner = owner;
            NodeState = state;
        }

        public virtual void Enter(TState from)
        {
            EnterState = from;
            NextState = NodeState;
            UpdateNodeState();
        }

        public virtual void Tick()
        {
            UpdateNextState();
            if (StaticMethods.EnumEquals(NextState, NodeState))
                UpdateNodeState();
        }

        public virtual void Exit(TState to)
        {
            ExitState = to;
        }

        public virtual TState GetNextState()
        {
            return NextState;
        }

        protected abstract void UpdateNextState();

        protected abstract void UpdateNodeState();
    }
}
