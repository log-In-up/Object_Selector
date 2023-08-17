using UnityEngine;

namespace GameData
{
    public class ObjectData : ScriptableObject
    {
        [field: SerializeField] public GameObject Object { get; private set; }

        [field: TextArea(10, 7), SerializeField] public string Description { get; private set; }
    }
}