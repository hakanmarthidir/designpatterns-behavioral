using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace command_pattern
{
    //1 Command 

    //public abstract class Command
    //{     
    //}

    //or 
    public interface ICommand
    {
        public void Execute();
    }

    //2 Classes
    public class Spotify
    {
        public void OpenSpotify()
        {
            Console.WriteLine("Here Spptify..");
        }

        public void StopMusic()
        {
            Console.WriteLine("Spptify stopped..");
        }
    }

    public class DeskLight
    {
        public void TurnOnDeskLight()
        {
            Console.WriteLine("OK");
        }

        public void TurnOffDeskLight()
        {
            Console.WriteLine("OK");
        }
    }

    //3 Some Commands

    public class SpotifyPlayCommand : ICommand
    {
        private Spotify _spotify;
        public SpotifyPlayCommand(Spotify spotify)
        {
            this._spotify = spotify;
        }
        public void Execute()
        {
            this._spotify.OpenSpotify();
        }
    }

    public class DeskLightOpenCommand : ICommand
    {
        private DeskLight _deskLight;

        public DeskLightOpenCommand(DeskLight deskLight)
        {
            this._deskLight = deskLight;
        }

        public void Execute()
        {
            this._deskLight.TurnOnDeskLight();
        }
    }

    public class GoodNightCommand : ICommand
    {
        private DeskLight _deskLight;
        private Spotify _spotify;

        public GoodNightCommand(DeskLight deskLight, Spotify spotify)
        {
            this._deskLight = deskLight;
            this._spotify = spotify;
        }

        public void Execute()
        {
            this._deskLight.TurnOffDeskLight();
            this._spotify.StopMusic();
            Console.WriteLine("Good Night");
        }
    }

    //4 Invoker

    public class AlexaHome
    {
        ICommand _command;

        public void SetCommand(ICommand command)
        {
            this._command = command;
        }

        public void RunCommand()
        {
            this._command.Execute();
        }
    
    }

}
