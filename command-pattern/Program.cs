using System;

namespace command_pattern
{
    class Program
    {
        static void Main(string[] args)
        {

            AlexaHome alexaHome = new AlexaHome();

            var desklight = new DeskLight();
            var spotify = new Spotify();

            alexaHome.SetCommand(new SpotifyPlayCommand(spotify));
            alexaHome.RunCommand();

            alexaHome.SetCommand(new DeskLightOpenCommand(desklight));
            alexaHome.RunCommand();

            alexaHome.SetCommand(new GoodNightCommand(desklight,spotify));
            alexaHome.RunCommand();

        }
    }

}
