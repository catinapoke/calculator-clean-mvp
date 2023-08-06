using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using Data;
using UnityEngine;
using Zenject;

namespace Domain
{
    public class RestoreResultUseCase
    {
        [Inject] public IResultStorage _storage;

        public RestoreResultUseCase(IResultStorage storage)
        {
            _storage = storage;
        }
        
        public IEnumerable<string> Get()
        {
            return Replace(_storage.GetHistory(), result => result.Value) ;
        }
        
        [Pure]
        private static IEnumerable<TOut> Replace<TIn, TOut>(IEnumerable<TIn> source, Func<TIn, TOut> convertor)
        {
            if (source == null)
            {
                Debug.LogError(new ArgumentNullException(nameof(source)));
                yield break;
            }

            using (var enumerator = source.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    yield return convertor(enumerator.Current);
                }
            }
        }
    }
}