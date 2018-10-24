namespace PhotoShare.Client.Core.Commands
{
    using System;
    using System.Linq;

    using Contracts;
    using Dtos;
    using Services.Contracts;

    public class ModifyUserCommand : ICommand
    {
        private readonly IUserService userService;
        private readonly ITownService townService;

        public ModifyUserCommand(IUserService userService, ITownService townService)
        {
            this.userService = userService;
            this.townService = townService;
        }

        // ModifyUser <username> <property> <new value>
        // For example:
        // ModifyUser <username> Password <NewPassword>
        // ModifyUser <username> BornTown <newBornTownName>
        // ModifyUser <username> CurrentTown <newCurrentTownName>
        // !!! Cannot change username
        public string Execute(string[] data)
        {
            string username = data[0];
            string property = data[1];
            string value = data[2];

            var userExists = this.userService.Exists(username);

            if (!userExists)
            {
                throw new ArgumentException($"User {username} not found!");
            }

            var userId = this.userService.ByUsername<UserDto>(username).Id;
            switch (property)
            {
                case "Password":
                    SetPassword(userId, value);
                    break;
                case "BornTown":
                    SetBornTown(userId, value);
                    break;
                case "CurrentTown":
                    SetCurrentTown(userId, value);
                    break;
                default:
                    throw new ArgumentException($"Property {property} not supported!");
            }

            return $"User {username} {property} is {value}.";
        }

        private void SetCurrentTown(int userId, string name)
        {
            var townExists = this.townService.Exists(name);

            if (!townExists)
            {
                throw new ArgumentException($"Value {name} not valid.\nTown {name} not found!");
            }

            var townId = this.townService.ByName<TownDto>(name).Id;
            this.userService.SetCurrentTown(userId, townId);
        }

        private void SetBornTown(int userId, string name)
        {
            var townExists = this.townService.Exists(name);

            if (!townExists)
            {
                throw new ArgumentException($"Value {name} not valid.\nTown {name} not found!");
            }

            var townId = this.townService.ByName<TownDto>(name).Id;
            this.userService.SetBornTown(userId, townId);
        }

        private void SetPassword(int userId, string password)
        {
            var isLower = password.Any(char.IsLower);
            var isDigit = password.Any(char.IsDigit);

            if (!isLower || !isDigit)
            {
                throw new ArgumentException($"Value {password} not valid.\nInvalid Password");
            }

            this.userService.ChangePassword(userId, password);
        }
    }
}
