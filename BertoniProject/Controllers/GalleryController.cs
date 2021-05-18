using Bertoni.Contracts.Managers;
using Bertoni.Entities.Models;
using BertoniProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BertoniProject.Controllers
{
    public class GalleryController : Controller
    {
        private readonly IAlbumManager _albumManager;
        public GalleryController(IAlbumManager albumManager)
        {
            _albumManager = albumManager;
        }
        public async Task<IActionResult> Index()
        {
            List<Album> albums = await _albumManager.GetAlbums();
            return View(albums);
        }

        public async Task<IActionResult> Photos(int id)
        {
            var photos = await _albumManager.GetPhotosByAlbum(id);

            return View(photos);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
