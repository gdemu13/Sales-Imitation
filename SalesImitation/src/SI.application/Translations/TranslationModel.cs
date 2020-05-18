using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using SI.Domain.Exceptions;

namespace SI.Application.Translations
{

    public class TranslationModel
    {
        public TranslationModel(Dictionary<string, string> neutralKeys)
        {
            Languages = new List<LanguageModel> { new LanguageModel { Code = "neutral", Name = "neutral" } };
            _translations = new Dictionary<string, List<TextModel>>();
            foreach (var nk in neutralKeys)
            {
                _translations.Add(nk.Key, new List<TextModel>{new TextModel{
                    LanguageCode = "neutral",
                    Value = nk.Value
                }});
            }
        }

        private List<LanguageModel> _language { get; set; }
        public List<LanguageModel> Languages { get {return _language;} set {
            // value.RemoveAt(value.FindIndex(r => r.Code == "neutral"));
            _language = value;
        }}
        public void AddText(string key, TextModel text)
        {
            if (text.LanguageCode == "neutral")
                return;
            var exists = _translations.TryGetValue(key, out var model);
            if (!exists)
            {
                throw new LocalizableException("key_doesnt_exists", "");
            }

            var t = model.Find(m => m.LanguageCode == text.LanguageCode);
            if (t != null)
                t.Value = text.Value;
            else
                model.Add(text);
        }

        public void AddTexts(string key, IEnumerable<TextModel> texts)
        {
            foreach (var t in texts)
            {
                AddText(key, t);
            }
        }

        private Dictionary<string, List<TextModel>> _translations { get; }
        public Dictionary<string, List<TextModel>> Translations
        {
            get
            {
                return _translations;
            }
        }


    }

    public class LanguageModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }

    public class TextModel
    {
        public string LanguageCode { get; set; }
        public string Value { get; set; }
    }
}