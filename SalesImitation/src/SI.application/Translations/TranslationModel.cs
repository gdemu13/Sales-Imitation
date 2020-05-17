using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace SI.Application.Translations
{

    public class TranslationModel : IDictionary<string, TranslationLanguageModel>
    {
        public TranslationModel()
        {
            Languages = new Dictionary<string, TranslationLanguageModel>();
        }

        private Dictionary<string, TranslationLanguageModel> Languages { get; set; }

        public ICollection<string> Keys => Languages.Keys;

        public ICollection<TranslationLanguageModel> Values => Languages.Values;

        public int Count => Languages.Count;

        public bool IsReadOnly => false;

        public TranslationLanguageModel this[string key]
        {
            get
            {
                Languages.TryGetValue(key, out var value);
                return value;
            }
            set
            {
                System.Console.WriteLine(key);
                if (Languages.ContainsKey(key))
                    Languages[key] = value;
                else
                    Languages.Add(key, value);
            }
        }

        public void Add(string key, TranslationLanguageModel value)
        {
            this[key] = value;
        }

        public bool ContainsKey(string key)
        {
            return Languages.ContainsKey(key);
        }

        public bool Remove(string key)
        {
            return Languages.Remove(key);
        }

        public bool TryGetValue(string key, [MaybeNullWhen(false)] out TranslationLanguageModel value)
        {
            return Languages.TryGetValue(key, out value);
        }

        public void Add(KeyValuePair<string, TranslationLanguageModel> item)
        {
            this[item.Key] = item.Value;
        }

        public void Clear()
        {
            Languages.Clear();
        }

        public bool Contains(KeyValuePair<string, TranslationLanguageModel> item)
        {
            return Languages.ContainsKey(item.Key) && Languages.ContainsValue(item.Value);
        }

        public void CopyTo(KeyValuePair<string, TranslationLanguageModel>[] array, int arrayIndex)
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(KeyValuePair<string, TranslationLanguageModel> item)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerator<KeyValuePair<string, TranslationLanguageModel>> GetEnumerator()
        {
            return Languages.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Languages.GetEnumerator();
        }

        IEnumerator<KeyValuePair<string, TranslationLanguageModel>> IEnumerable<KeyValuePair<string, TranslationLanguageModel>>.GetEnumerator()
        {
            return Languages.GetEnumerator();
        }
    }

    public class TranslationLanguageModel : IDictionary<string, string>
    {
        public Guid ID { get; set; }
        public string LanguageCode { get; set; }
        public string LanguageName { get; set; }
        public TranslationLanguageModel()
        {
            texts = new Dictionary<string, string>();
        }
        private Dictionary<string, string> texts { get; set; }

        public ICollection<string> Keys => texts.Keys;

        public ICollection<string> Values => texts.Values;

        public int Count => texts.Count;

        public bool IsReadOnly => false;

        public string this[string key]
        {
            get
            {
                texts.TryGetValue(key, out var value);
                return value;
            }
            set
            {
                if (texts.ContainsKey(key))
                    texts[key] = value;
                else
                    texts.Add(key, value);
            }
        }

        public void Add(string key, string value)
        {
            this[key] = value;
        }

        public bool ContainsKey(string key)
        {
            return texts.ContainsKey(key);
        }

        public bool Remove(string key)
        {
            return texts.Remove(key);
        }

        public bool TryGetValue(string key, [MaybeNullWhen(false)] out string value)
        {
            return texts.TryGetValue(key, out value);
        }

        public void Add(KeyValuePair<string, string> item)
        {
            texts.Add(item.Key, item.Value);
        }

        public void Clear()
        {
            texts.Clear();
        }

        public bool Contains(KeyValuePair<string, string> item)
        {
            return ContainsKey(item.Key);
        }

        public void CopyTo(KeyValuePair<string, string>[] array, int arrayIndex)
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(KeyValuePair<string, string> item)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            return texts.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return texts.GetEnumerator();
        }
    }
}