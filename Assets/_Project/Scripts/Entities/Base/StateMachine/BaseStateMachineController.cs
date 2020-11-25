using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts
{
    public abstract class BaseStateMachineController<TOwner, TState> : TickComponent
    where TOwner : TickBehaviour
    where TState : struct, Enum
    {
        protected TOwner owner;

        protected readonly Dictionary<TState, IStateMachineNode<TState>> nodes =
            new Dictionary<TState, IStateMachineNode<TState>>();

        protected IStateMachineNode<TState> currentNode;
        protected TState currentState;

        public TOwner Owner => owner;

        public IStateMachineNode<TState> ActiveNode => currentNode;
        public TState ActiveState => currentState;

        public override void Init()
        {
            owner = GetComponent<TOwner>();
        }

        public override void Enable()
        {
            ResetState();
        }

        public override void Tick()
        {
            currentNode.Tick();
            UpdateState(currentNode.GetNextState());
        }

        protected virtual void ResetState()
        {
            currentNode = nodes[currentState];
            currentNode.Enter(currentState);
        }

        protected void UpdateState(TState nextState)
        {
            //Debug.Log($"STATE: {nextState}");
            if (StaticMethods.EnumEquals(currentState, nextState))
                return;

            var existsInNodes = nodes.TryGetValue(nextState, out var nextNode);
            if (!existsInNodes)
            {
                Debug.LogError($"Trying to transition to nonexistent state node: {nextState}");
                return;
            }

            currentNode.Exit(nextState);
            currentNode = nextNode;

            currentNode.Enter(currentState);
            currentState = nextState;
        }

        protected void CreateNode<TNode>(TState state) where TNode : BaseEntityNode<TOwner, TState>
        {
            var node = (TNode)Activator.CreateInstance(typeof(TNode), owner, state);
            nodes.Add(state, node);
        }
    }
}
