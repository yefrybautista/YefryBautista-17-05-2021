using Bertoni.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bertoni.Contracts.Managers
{
    public interface IAlbumManager
    {
        Task<List<Album>> GetAlbums();
        Task<List<Photo>> GetPhotosByAlbum(int albumId);
    }
}
