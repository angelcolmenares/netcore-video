using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace videostreaming.net.Controllers
{
    public class VideoController : Controller
    {    
        private readonly OpcionesVideo _opcionesVideo;

        public VideoController(IOptions<OpcionesVideo> opcionesVideo)
        {
            _opcionesVideo= opcionesVideo.Value;

        }
      
        // GET api/video/reproducir/video.mp4   o api/video/reproducir?filename=video.mp4
        [HttpGet("/api/video/reproducir/{filename}")]
        //[Authorize]
        public IActionResult Get(string filename)
        {
            var extension = new  System.IO.FileInfo(filename).Extension;
            return PhysicalFile( $"{_opcionesVideo.DirectorioVideos}/{filename}",  $"video/{extension}");
        }

        // GET api/video/listar   
        [HttpGet("/api/video/listar")]
        //[Authorize]
        public IActionResult Get()
        {
            var dirInfo =  new System.IO.DirectoryInfo(_opcionesVideo.DirectorioVideos);
            var files = dirInfo.GetFiles("*.mp4").Select(q=> new { name= q.Name, length=q.Length  });
            return new ObjectResult( new { files = files } );
        }
        
    }
}