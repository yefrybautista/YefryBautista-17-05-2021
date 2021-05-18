using Bertoni.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bertoni.Contracts.Services
{
    public interface IAlbumService
    {
        Task<List<Album>> GetAlbums();
        Task<List<Comment>> GetCommentsByPost(int postId);
        Task<List<Photo>> GetPhotosByAlbum(int albumId);
    }
}
