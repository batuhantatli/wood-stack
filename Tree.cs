using UnityEngine;

public class Tree : MonoBehaviour
{
    private void Start()
    {
        TreeManager.Instance.Add(this);
    }

    public void Cut(Axe axe)
    {
        Destruct(axe.transform.position);
    }
    public bool isDestruct;
    private void Destruct(Vector3 pos)
    {
        if (isDestruct)
            return;

        isDestruct = true;

    }
}