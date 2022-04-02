using UnityEngine;

public class Axe : MonoBehaviour
{
    public Animator animator;

    GameObject _player;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("playerTag");
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Tree>(out Tree tree))
        {
            animator.SetBool("Cutting",true);
            tree.Cut(this);
        }
    }


}
