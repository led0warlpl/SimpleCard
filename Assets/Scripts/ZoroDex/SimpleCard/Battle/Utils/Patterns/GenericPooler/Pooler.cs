using System;
using System.Collections.Generic;

namespace ZoroDex.SimpleCard.Patterns
{
    /// <summary>
    ///     Create a Singleton class which allows to Pool/Release Objects of the type
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="T1"></typeparam>
    //TODO: ไปสร้าง singleton class pattern ก่อน
    public abstract class Pooler<T,T1> : Singleton<T1>
        where T : class,IPoolable,new()
        where T1: class,new()
    {
        // ------------------------------------------

        readonly List<T> busy = new List<T>();
        readonly List<T> free = new List<T>();

        // -------------------------------------------

        #region Constructor

        /// <summary>
        ///     Constructor, you must hvae to specify the starting size of the pool
        /// </summary>
        /// <param name="startingSize"></param>
        protected Pooler(int startingSize)
        {
            StartSize = startingSize;
            
            //pool start size
            for (var i = 0; i < StartSize; ++i)
            {
                var obj = new T();
                free.Add(obj);

            }

        }
        
        // ---------------------------------------------
        
        public int StartSize { get; }
        public int SizeFreeObjects => free.Count;
        
        public int SizeBusyObjects => busy.Count;

        public Type PoolType => typeof(T);

        #endregion
        
        // --------------------------------------------

        #region Exceptions

        public class PoolerArgumentException : ArgumentException
        {
            public PoolerArgumentException(string message) : base(message)
            {
            }
        }

        #endregion
        
        // --------------------------------------------

        #region Operations

        /// <summary>
        ///     Get an object of the type T
        /// </summary>
        /// <returns></returns>
        public T Get()
        {
            T pooled = null;

            if (SizeFreeObjects > 0)
            {
                //pool the last object
                pooled = free[SizeFreeObjects - 1];
                free.Remove(pooled);
            }
            else
            {
                //if can't pool create a new object
                pooled = new T();
            }
            
            //add to the busy list
            busy.Add(pooled);

            OnPool(pooled);
            return pooled;
        }

        /// <summary>
        ///     Release an object of the type T
        /// </summary>
        /// <param name="released"></param>
        /// <exception cref="PoolerArgumentException"></exception>
        public void Release(T released)
        {
            if (released == null)
                throw new PoolerArgumentException("Can't Release a null object");
            
            //reset object
            released.Restart();
            
            //add back to the freelist
            free.Add(released);
            
            //remove from busy list
            busy.Remove(released);

            OnRelease(released);

        }
        
        /// <summary>
        ///     Dispatched before pool an object.
        /// </summary>
        /// <param name="obj"></param>
        protected virtual void OnPool(T obj){}
        
        /// <summary>
        ///     Dispatched after release an object.
        /// </summary>
        /// <param name="obj"></param>
        protected virtual void OnRelease(T obj){}

        #endregion



    }
}