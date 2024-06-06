using SH.Model;
using System;
using UnityEngine;

namespace SH.Dto
{
    public abstract class ItemData : ScriptableObject {
        [Header("Item")]
        [SerializeField] protected string id = Guid.NewGuid().ToString();
        [SerializeField] protected Info info;
        [SerializeField] protected Sprite sprite;
        [SerializeField] protected int maxQuantity;
        [SerializeField] protected float weight;
        [SerializeField] protected int sellValue;

        public string Id => id;
        public Info Info => info;
        public Sprite Sprite => sprite;
        public int MaxQuantity => maxQuantity;
        public float Weight => weight;
        public int SellValue => sellValue;
    }
}