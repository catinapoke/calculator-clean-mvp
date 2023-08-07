using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Text;
using Data;
using Unity.Plastic.Newtonsoft.Json;
using UnityEngine;
using Zenject;

namespace Domain
{
    public class RestoreResultUseCase
    {
        [Inject] public IResultStorage _storage;
        
        private const string PrefsKey = "CalculatorResults";

        public RestoreResultUseCase(IResultStorage storage)
        {
            _storage = storage;
        }

        public void Save()
        {
            PlayerPrefs.SetString(PrefsKey, SerializeResults());
            PlayerPrefs.Save();
        }

        public void Restore()
        {
            var items = DeserializeResults();
            _storage.InitIfEmpty(items);
        }
        
        public IEnumerable<string> Get()
        {
            return Replace(_storage.GetHistory(), result => result.Value);
        }

        private string SerializeResults()
        {
            JsonSerializer serializer = JsonSerializer.CreateDefault();
            StringBuilder builder = new StringBuilder(64);
            TextWriter writer = new StringWriter(builder);
            serializer.Serialize(writer, _storage.GetHistory().ToArray());
            return builder.ToString();
        }

        private Result[] DeserializeResults()
        {
            string results = PlayerPrefs.GetString(PrefsKey, String.Empty);
            TextReader textReader = new StringReader(results);
            JsonReader reader = new JsonTextReader(textReader);

            JsonSerializer serializer = JsonSerializer.CreateDefault();
            Result[] items = serializer.Deserialize<Result[]>(reader);

            if (items == null)
            {
                items = new Result[] { };
            }
            
            return items;
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