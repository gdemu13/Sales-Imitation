using MediatR;
using System;
using SI.Common.Models;
using SI.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using SI.Domain.Abstractions.Repositories;

namespace SI.Application.Administrators {
    public class RegisterAdministratorRequestHandler : IRequestHandler<RegisterAdministratorRequest, Result> {

        private IUserRepository _userRepository;

        public RegisterAdministratorRequestHandler(IUserRepository userRepository){
            _userRepository = userRepository;
        }

        public async Task<Result> Handle(RegisterAdministratorRequest request, CancellationToken token){
           var user = new User(Guid.NewGuid(), request.UserName, request.Password, DateTime.Now);
           return await _userRepository.Insert(user);
        }
    }
}