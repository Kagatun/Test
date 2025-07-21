using UnityEngine;

namespace Scripts.Players
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Attacker _attacker;

        private void Update()
        {
            if(_attacker == null)
                return;
            
            if (Input.GetKeyDown(KeyCode.Return))
                _attacker.Shoot();
        }
    }
}