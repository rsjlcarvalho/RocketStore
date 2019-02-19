using System;
using FluentValidator;
using RocketStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using RocketStore.Domain.StoreContext.Entities;
using RocketStore.Domain.StoreContext.ValueObjects;
using RocketStore.Shared.Commands;

namespace RocketStore.Domain.StoreContext.Handlers
{
    public class CustomerHandler : Notifiable, ICommandHandler<CreateCustomerCommand>, ICommandHandler<AddAddressCommand>
    {
        public CustomerHandler()
        {
        }

        public ICommandResult Handle(CreateCustomerCommand command)
        {
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);

            var customer = new Customer(name, document, email, command.Phone);

            AddNotifications(name.Notifications);
            AddNotifications(document.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(customer.Notifications);

            return new CreateCustomerCommandResult(Guid.NewGuid(), name.ToString(), email.Address);
        }

        public ICommandResult Handle(AddAddressCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}