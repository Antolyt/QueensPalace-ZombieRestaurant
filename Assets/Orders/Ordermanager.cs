using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ordermanager : MonoBehaviour {
    public Order page;
    private Order _newOrder = null;
    private List<Order> _orders;
    public float spawnsPerSecond;
    private int _amountSpawnedOrders;

	void Start () {
        _orders = new List<Order>();
    }
    public List<Order> GetOrders()
    {
        return _orders;
    }
	void Update () {
		if (Random.value < Time.deltaTime * spawnsPerSecond)
        {
            _newOrder = Instantiate(page, transform.GetChild(0).transform);
            int row = (int)(_orders.Count - 1) / 6;
            int col = (int)((_orders.Count - 1)) % 6;
            _newOrder.GetComponent<RectTransform>().anchoredPosition = new Vector2(40F + 160F * col, -80F * row);
            _newOrder.Init(_amountSpawnedOrders++);
            _orders.Add(_newOrder);
            _newOrder = null;
        }
	}
}
