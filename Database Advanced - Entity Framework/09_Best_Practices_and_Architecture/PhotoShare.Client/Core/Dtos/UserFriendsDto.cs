namespace PhotoShare.Client.Core.Dtos
{
    using System.Collections.Generic;
    using Commands;

    public class UserFriendsDto
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public ICollection<FriendDto> Friends { get; set; }
    }
}
