using UnityEngine;
using UnityEngine.Events;

namespace VertexEscape.Core
{
    public class PuzzleManager : MonoBehaviour
    {
        public static PuzzleManager Main { get; private set; }

        [SerializeField] UnityEvent onPuzzleFinished;

        /// <summary>
        /// Called when the puzzle has been finished and the next scene is to be loaded
        /// </summary>
        public void FinishPuzzle()
        {
            onPuzzleFinished?.Invoke();
        }

        private void Awake()
        {
            if (Main == null)
            {
                Main = this;
            }
        }

        private void OnDestroy()
        {
            if (Main == this)
            {
                Main = null;
            }
        }
    }
}
