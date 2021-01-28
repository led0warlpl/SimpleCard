using UnityEngine;

namespace ZoroDex.SimpleCard.Data
{
    public interface IBaseData
    {
        string Name { get; }
        string Description { get; }
        Sprite Artwork { get; }
        
    }
}