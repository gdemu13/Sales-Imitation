using System;
using MediatR;
using Microsoft.AspNetCore.Http;
using SI.Application.EventHandlers;
using SI.Domain.Abstractions.DomainEvents;
using SI.Domain.Entities;

namespace SI.Infrastructure.DomainEvents
{
    public static class DomainEventDispacherExtension
    {
        static public void DispatchDomainEvents(this BaseEntity entity)
        {
            IMediator mediator = ServiceLocator.Current.GetInstance<IMediator>();

            foreach (var item in entity.Events)
            {
                var type = typeof(DomainEvent<>).MakeGenericType(item.GetType());

                var instance = Activator.CreateInstance(type, item);
                mediator.Publish(instance);
            }
        }
    }
}