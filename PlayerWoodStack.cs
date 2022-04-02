using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWoodStack : MonoBehaviour
{
    [SerializeField] List<GameObject> _obstacleList = new List<GameObject>();

    public Animator _animator;
    public bool _collectable;
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("TreePartTag"))
        {
            if(_collectable == false)
            {
            Stack(other.gameObject.GetComponent<Tree>());
            }
        }
    }

    public void Stack(Tree tree)
    {
        if (!tree.isDestruct)
            return;

        TreeManager.Instance.Stack(tree);

        if (_obstacleList.Contains(tree.gameObject))
            return;
        _obstacleList.Add(tree.gameObject);

        tree.gameObject.transform.parent = transform;
        tree.gameObject.layer = gameObject.layer;
        tree.GetComponent<Rigidbody>().isKinematic = true;

        TreeRepos(tree.gameObject);

        _collectable = true;
    }

    public void AnimationStopper()
    {
        _animator.SetBool("Cutting", false);
        _collectable = false;
    }

    private void TreeRepos(GameObject tree)
    {
        tree.transform.localRotation = Quaternion.Euler(0, 0, 90);
        tree.transform.localScale = new Vector3(2f, 2f, 2f);

        if (_obstacleList.Count % 16 <= 5 )
        {
            tree.transform.localPosition = new Vector3(0, 1 + (_obstacleList.Count % 16) * .25f, -0.85f);
        }
        if (_obstacleList.Count % 16 > 5 && _obstacleList.Count % 16 <= 10)
        {
            tree.transform.localPosition = new Vector3(0, 1 + (_obstacleList.Count-5 % 16) * .25f, -1.15f);
        }
        if (_obstacleList.Count % 16 > 10 && _obstacleList.Count % 16 <= 15)
        {
            tree.transform.localPosition = new Vector3(0, 1 + (_obstacleList.Count-10 % 16 ) * .25f, -1.4f);
        }
    } 
}
