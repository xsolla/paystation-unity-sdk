﻿using System.Collections.Generic;
using UnityEngine;

public class InventoryItemContainer : MonoBehaviour, IContainer
{
	[SerializeField] private GameObject itemPrefab;
	[SerializeField] private Transform itemParent;

	private List<GameObject> _items;
	private IStoreDemoImplementation _demoImplementation;

	private void Awake()
	{
		_items = new List<GameObject>();
		UserInventory.Instance.UpdateItemsEvent += RefreshInternal;
	}

	public void SetStoreImplementation(IStoreDemoImplementation demoImplementation)
	{
		_demoImplementation = demoImplementation;
	}

	public void Refresh()
	{
		RefreshInternal(UserInventory.Instance.Items);
	}

	private void RefreshInternal(List<InventoryItemModel> items)
	{
		ClearItems();
		items.ForEach(AddItem);
	}

	private void ClearItems()
	{
		_items.ForEach(Destroy);
		_items.Clear();
	}

	private void AddItem(InventoryItemModel itemInformation)
	{
		var newItem = Instantiate(itemPrefab, itemParent);
		newItem.GetComponent<InventoryItemUI>().Initialize(itemInformation, _demoImplementation);
		_items.Add(newItem);
	}
}