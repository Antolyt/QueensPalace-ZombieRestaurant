using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ordermanager : MonoBehaviour {
    public Order page;
    private const int maxOrders = 12;
    private Order _newOrder = null;
    private List<Order> _orders;
    public float spawnsPerSecond;
    private int _amountSpawnedOrders;
    private readonly float liveTime = 10F;

	void Start () {
        _orders = new List<Order>();
    }
    public void Destroy(int id) {
        _orders.RemoveAt(id);
        for (int i = id; i < _orders.Count; ++i)
        {
            _orders[i].transform.localPosition += new Vector3(-160F, 0F, 0F);
        }
    }
    public void AceptPlate(Food[] foods)
    {
        bool finish = false;
        Order de = null;
        foreach ( Order o in _orders)
        {
            if (finish)
                o.transform.localPosition += new Vector3(-160F, 0F, 0F);
            else if (o.IsValid(foods))
            {
                Destroy(o.gameObject);
                de = o;
                Debug.Log("Richtiges Esssen");
                finish = true;
            }
        }
        if (finish)
            _orders.Remove(de);
    }
    public List<Order> GetOrders()
    {
        return _orders;
    }
	void Update () {
		if (_orders.Count < maxOrders && Random.value < Time.deltaTime * spawnsPerSecond)
        {
            _newOrder = Instantiate(page, transform.GetChild(0).transform);
            int row = (int)(_orders.Count - 1) / 6;
            int col = (int)((_orders.Count - 1)) % 6;
            _newOrder.GetComponent<RectTransform>().anchoredPosition = new Vector2(40F + 160F * col, -80F * row);
            _newOrder.Init(_amountSpawnedOrders++, liveTime, this);
            _orders.Add(_newOrder);
            _newOrder = null;
        }
	}
}
