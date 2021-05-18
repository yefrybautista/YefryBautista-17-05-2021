using Bertoni.Contracts.Managers;
using Bertoni.Contracts.Services;
using Bertoni.Entities.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bertoni.BL.Managers
{
    public class AlbumManager : IAlbumManager
    {
        private IAlbumService _albumService;
        public AlbumManager(IAlbumService albumService)
        {
            _albumService = albumService;
        }

        public async Task<List<Album>> GetAlbums()
        {
            List<Album> albums = null; 
            try
            {
                albums = await _albumService.GetAlbums();
            }
            catch (Exception)
            {

            }
            return albums;
        }

        public async Task<List<Photo>> GetPhotosByAlbum(int albumId)
        {
            var photos = new List<Photo>();
            try
            {
                var photosResponse = await _albumService.GetPhotosByAlbum(albumId);
                if (photosResponse != null && photosResponse.Count > 0)
                {
                    var commentsResponse = await _albumService.GetCommentsByPost(albumId);
                    if (commentsResponse != null && commentsResponse.Count > 0)
                    {
                        foreach (var photo in photosResponse)
                        {
                            photo.Comments = commentsResponse.Where(y => y.PostId == photo.Id).ToList();
                            photos.Add(photo);
                        };
                    }
                }
            }
            catch (Exception)
            {

            }
            return photos;
        }
    }

}
