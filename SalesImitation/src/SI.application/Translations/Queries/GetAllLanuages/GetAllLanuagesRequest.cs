using System.Collections.Generic;
using MediatR;
using SI.Common.Models;

namespace SI.Application.Translations {
    public class GetAllLanuagesRequest : IRequest<TranslationModel> {
    }
}