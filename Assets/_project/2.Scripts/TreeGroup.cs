using System.Collections.Generic;
using UnityEngine;

public class TreeGroup : MonoBehaviour
{
    [SerializeField] private List<TreeObject> _trees;
    void Start()
    {
        _trees.ForEach(tree => tree.Init());
    }
}
