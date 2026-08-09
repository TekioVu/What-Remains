using UnityEngine;

public class FadeScript : MonoBehaviour
{
   [SerializeField] private bool disappear = true;
   public void Hide()
   {
      if(disappear)
        this.gameObject.SetActive(false);
   }
}
