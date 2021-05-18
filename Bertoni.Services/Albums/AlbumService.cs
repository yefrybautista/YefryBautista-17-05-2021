using Bertoni.Contracts.Helpers;
using Bertoni.Contracts.Services;
using Bertoni.Entities.Configuration;
using Bertoni.Entities.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bertoni.Services.Albums
{
    public class AlbumService : IAlbumService
    {
        private IHttpclientBertoni _client;
        private readonly IOptions<ServicesConfiguration> _servicesConfiguration;
        public AlbumService(IHttpclientBertoni client, IOptions<ServicesConfiguration> servicesConfiguration)
        {
            _client = client;
            _servicesConfiguration = servicesConfiguration;
        }

        public async Task<List<Album>> GetAlbums()
        {
            List<Album> albums = null;
            var response = await _client.GetAsync(_servicesConfiguration.Value.AlbumBaseUrl + "/albums");
            if (!string.IsNullOrEmpty(response))
            {
               albums = JsonConvert.DeserializeObject<List<Album>>(response);
            }
            return albums;
        }
        public async Task<List<Photo>> GetPhotosByAlbum(int albumId)
        {
            List<Photo> photos = null;

            var response = await _client.GetAsync(_servicesConfiguration.Value.AlbumBaseUrl + "/photos");
            if (!string.IsNullOrEmpty(response))
            {
                photos = JsonConvert.DeserializeObject<List<Photo>>(response);
                photos = photos.Where(photo => photo.AlbumId == albumId).ToList();
            }
            return photos;
        }

        public async Task<List<Comment>> GetCommentsByPost(int postId)
        {
            List<Comment> comments = null;

            var response = await _client.GetAsync(_servicesConfiguration.Value.AlbumBaseUrl + "/comments");
            if (!string.IsNullOrEmpty(response))
            {
                comments = JsonConvert.DeserializeObject<List<Comment>>(response);
                comments = comments.Where(comment => comment.PostId == postId).ToList();
            }
            return comments;
        }
    }
}
