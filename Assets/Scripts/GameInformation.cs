public class GameInformation
{
    public static bool isFullScreen = false;  //是否全屏幕
    public static bool isAudioPlayed = false;
    public static int masterVolume = 50;  //主音量
    public static int musicVolume = 50; //音乐音量
    public static bool isMute = false;
    public class GameResolution
    {
        public GameResolution(int _width, int _height)
        {
            width = _width;
            height = _height;
        }
        private int width;
        private int height;
        //Width属性
        public int Width
        {
            get
            {
                return width;
            }
            set
            {
                width = value;
            }
        }
        //Height属性
        public int Height
        {
            get
            {
                return height;
            }
            set
            {
                height = value;
            }
        }
    }
    public static GameResolution prefabResolution = new GameResolution(1920, 1080);
}
