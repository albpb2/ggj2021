using UnityEngine;

public class GameObjectPool<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private T _prefab;
    [SerializeField] private int _numOfItems;

    private T[] _items;
    private int _currentItemIndex;

    private void Start()
    {
        _items = new T[_numOfItems];
        for (var i = 0; i < _numOfItems; i++)
        {
            _items[i] = Instantiate(_prefab).GetComponent<T>();
            _items[i].transform.SetParent(transform);
            _items[i].gameObject.SetActive(false);
        }
    }

    public T GetNextItem()
    {
        var nextItem= _items[_currentItemIndex];

        _currentItemIndex++;
        _currentItemIndex %= _numOfItems;

        return nextItem;
    } 
}