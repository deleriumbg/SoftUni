namespace PhotoShare.Client.Core.Commands
{
    using System;
    using System.Linq;
    using Dtos;
    using PhotoShare.Services.Contracts;
    using Contracts;

    public class AddFriendCommand : ICommand
    {
        private readonly IUserService userService;

        public AddFriendCommand(IUserService userService)
        {
            this.userService = userService;
        }

        // AddFriend <username1> <username2>
        public string Execute(string[] data)
        {
            string userName = data[0];
            string friendName = data[1];

            var userExists = this.userService.Exists(userName);
            var friendExists = this.userService.Exists(friendName);

            if (!userExists)
            {
                throw new ArgumentException($"{userName} not found!");
            }

            if (!friendExists)
            {
                throw new ArgumentException($"{friendName} not found!");
            }

            var user = this.userService.ByUsername<UserFriendsDto>(userName);
            var friend = this.userService.ByUsername<UserFriendsDto>(friendName);

            bool requestSendFromUser = user.Friends.Any(x => x.Username == friend.Username);
            bool requestSendFromFriend = friend.Friends.Any(x => x.Username == user.Username);

            if (requestSendFromUser && requestSendFromFriend)
            {
                throw new InvalidOperationException($"{friendName} is already a friend to {userName}");
            }
            else if (requestSendFromUser && !requestSendFromFriend)
            {
                throw new InvalidOperationException("Friend request is already send!");
            }
            else if (!requestSendFromUser && requestSendFromFriend)
            {
                throw new InvalidOperationException("Friend request is already send!");
            }

            this.userService.AddFriend(user.Id, friend.Id);
            return $"Friend {friendName} added to {userName}";
        }
    }
}
