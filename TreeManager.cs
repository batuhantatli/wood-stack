using GamesMrkt.Core;
using System.Collections.Generic;
using UnityEngine;

public class TreeManager : Singleton<TreeManager>
{
    private List<Tree> list = new List<Tree>();
    public void Add(Tree arg)
    {
        if (list.Contains(arg))
            return;

        list.Add(arg);
    }
    public void Remove(Tree arg)
    {
        if (!list.Contains(arg))
            return;

        list.Remove(arg);
    }

    private List<Tree> stacking = new List<Tree>();
    public void Stack(Tree args)
    {
        if (stacking.Contains(args))
            return;

        stacking.Add(args);

        if (stacking.Count == list.Count) {
            LevelManager.OnLevelComplete?.Invoke(LevelManager.Level);
            Debug.Log("Level Complete");
        }
    }
}
