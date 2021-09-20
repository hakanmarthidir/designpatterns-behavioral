using System;

namespace observer_pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            YoutubeChannel youtubeChannel = new YoutubeChannel() { Name = "Science 101" };


            YoutubeMember member1 = new YoutubeMember() { Name = "User A" };
            YoutubeMember member2 = new YoutubeMember() { Name = "User B" };
            YoutubeMember member3 = new YoutubeMember() { Name = "User C" };
            YoutubeMember member4 = new YoutubeMember() { Name = "User D" };

            youtubeChannel.Subscribe(member1);
            youtubeChannel.Subscribe(member2);
            youtubeChannel.Subscribe(member3);
            youtubeChannel.Subscribe(member4);

            youtubeChannel.PublishVideo();

        }
    }
}
