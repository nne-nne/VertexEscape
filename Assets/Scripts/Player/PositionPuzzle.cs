using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VertexEscape.Core;

public class PositionPuzzle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Solution")
        {
            PuzzleManager.Main.FinishPuzzle();
        }
    }
}
