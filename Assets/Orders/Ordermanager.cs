using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ordermanager : MonoBehaviour {
    public Order page;
    public float liveTime = 10F;
    public int maxOrders = 12;
    private Order _newOrder = null;
    private List<Order> _orders;
    public float spawnsPerSecond;
    private int _amountSpawnedOrders;

	void Start () {
        _orders = new List<Order>();
    }
    public bool AceptPlate(Food[] foods)
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
        {
            _orders.Remove(de);

        }

        return finish;
    }
    public void kaputt(Order obj)
    {
        bool found = false;
        foreach(Order o in _orders)
        {
            if (found)
            {
                o.transform.localPosition += new Vector3(-160F, 0F, 0F);
            }
            if (o == obj)
            {
                found = true;
            }
        }
        _orders.Remove(obj);
        Destroy(obj.gameObject);
    }
    public List<Order> GetOrders()
    {
        return _orders;
    }
	void Update ()
    {
        if (_orders.Count < maxOrders && Random.value < Time.deltaTime * spawnsPerSecond)
        {
            _newOrder = Instantiate(page, transform.GetChild(0).transform);
            int row = (int)(_orders.Count - 1) / 6;
            int col = (int)((_orders.Count - 1)) % 6;
            _newOrder.GetComponent<RectTransform>().anchoredPosition = new Vector2(40F + 160F * col, -80F * row);
            _newOrder.Init(_orders.Count, liveTime, this);
            _orders.Add(_newOrder);
        }
	}
}
