using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] protected string objName;

    public virtual void OnInteract() 
    {
        OnEndHover();
    }

    public virtual void OnHover() {  }

    public virtual void OnStartHover() {   }

    public virtual void OnEndHover() { }
    
    public virtual string GetMessage()
    {
        return "Использовать " + objName;
    }
}