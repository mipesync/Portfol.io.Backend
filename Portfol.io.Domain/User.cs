using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Portfol.io.Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string ProfileImagePath { get; set; } = null!;
        public DateOnly DateOfBirth { get; set; }
        public DateTime DateOfCreation { get; set; }

        [RegularExpression(@"^(\s*)?(\+)?([- _():=+]?\d[- _():=+]?){10,14}(\s*)?$", ErrorMessage = "Неверный формат номера телефона!")]
        public string? Phone { get; set; }

        [RegularExpression(@"^(([^<>()[\]\\.,;:\s@]+(\.[^<>()[\]\\.,;:\s@]+)*)|(.+))@((\[[0-9]{1,3}\.[0-9]{1,3}\.
            [0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$",
            ErrorMessage = "Неверный формат E-Mail!")]
        public string Email { get; set; } = null!;
        public string? VerifyCode { get; set; } = null;
        public int? CredentialsId { get; set; }
        public int RoleId { get; set; }

        [JsonIgnore]
        public virtual Credential? Credential { get; set; }
        public virtual Role? Role{ get; set; }
        public virtual ICollection<Album>? UserAlbums { get; set; }
        public virtual ICollection<Album>? LikedAlbums { get; set; }
        public virtual ICollection<AlbumLike>? AlbumLikes { get; set; }
    }
}
