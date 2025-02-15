using UnityEngine;

namespace RainbowAssets.StateMachine
{
    /// <summary>
    /// Controls the execution of a StateMachine within a MonoBehaviour.
    /// Handles state switching and updates the StateMachine lifecycle.
    /// </summary>
    public class StateMachineController : MonoBehaviour
    {
        /// <summary>
        /// The StateMachine instance controlled by this component.
        /// </summary>
        [SerializeField] StateMachine stateMachine;

        /// <summary>
        /// Gets the current StateMachine instance.
        /// </summary>
        /// <returns>The controlled StateMachine.</returns>
        public StateMachine GetStateMachine()
        {
            return stateMachine;
        }

        /// <summary>
        /// Switches the active state in the StateMachine to the specified state.
        /// </summary>
        /// <param name="newStateID">The unique identifier of the new state.</param>
        public void SwitchState(string newStateID)
        {
            stateMachine.SwitchState(newStateID);
        }

        // LIFECYCLE METHODS

        void Awake()
        {
            stateMachine = stateMachine.Clone();
        }

        void Start()
        {
            stateMachine.Bind(this);
            stateMachine.Enter();
        }

        void Update()
        {
            stateMachine.Tick();
        }
    }
}
