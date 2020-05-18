using System.Collections.Generic;
using MediatR;
using SI.Common.Models;

namespace SI.Application.Translations {
    public class SaveAllLanguagesRequest : IRequest<Result> {
        public List<LanguageRequestModel> Languages { get; set; }
        public Dictionary<string, List<LanguageTextRequestModel>> Texts { get; set; }
    }

    public class LanguageRequestModel {
        public string Code { get; set; }
        public string Name { get; set; }
    }

    public class LanguageTextRequestModel {
        public string Value { get; set; }
        public string LanguageCode { get; set; }
    }
}