namespace videostreaming.net
{
    public class OpcionesVideo
    {
        public OpcionesVideo()
        {
            DirectorioVideos= System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyVideos);
        }

        public string DirectorioVideos {get;set;}
    }
}