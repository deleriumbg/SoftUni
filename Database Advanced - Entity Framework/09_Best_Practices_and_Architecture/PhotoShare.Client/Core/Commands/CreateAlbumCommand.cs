namespace PhotoShare.Client.Core.Commands
{
    using System;
    using System.Linq;

    using Contracts;
    using Services.Contracts;   
    using Dtos;
    using Utilities;
    using Models.Enums;

    public class CreateAlbumCommand : ICommand
    {
        private readonly IAlbumService albumService;
        private readonly IUserService userService;
        private readonly ITagService tagService;

        public CreateAlbumCommand(IAlbumService albumService, IUserService userService, ITagService tagService)
        {
            this.albumService = albumService;
            this.userService = userService;
            this.tagService = tagService;
        }

        // CreateAlbum <username> <albumTitle> <BgColor> <tag1> <tag2>...<tagN>
        public string Execute(string[] data)
        {
            string username = data[0];
            string albumTitle = data[1];
            string bgColor = data[2];
            string[] tags = data.Skip(3).ToArray();

            var userExists = this.userService.Exists(username);
            if (!userExists)
            {
                throw new ArgumentException($"User {username} not found!");
            }

            var albumExists = this.albumService.Exists(albumTitle);
            if (albumExists)
            {
                throw new ArgumentException($"Album {albumTitle} exists!");
            }

            var validColor = Enum.TryParse(bgColor, out Color result);
            if (!validColor)
            {
                throw new ArgumentException($"Color {bgColor} not found!");
            }

            foreach (var tag in tags)
            {
                var currentTagExists = this.tagService.Exists(tag.ValidateOrTransform());

                if (!currentTagExists)
                {
                    throw new ArgumentException($"Invalid tags!");
                }
            }

            var userId = this.userService.ByUsername<UserDto>(username).Id;
            this.albumService.Create(userId, albumTitle, bgColor, tags);
            return $"Album {albumTitle} successfully created!";
        }
    }
}
