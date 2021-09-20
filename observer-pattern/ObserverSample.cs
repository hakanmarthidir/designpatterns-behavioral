using System;
using System.Collections.Generic;

namespace observer_pattern
{

    //1
    public interface ISubscriber
    {
        string Name { get; set; }
        void UpdateData(string message);
    }

    public interface IPublisher
    {
        string Name { get; set; }
        void Subscribe(ISubscriber member);
        void UnSubscribe(ISubscriber member);
        void Notify(string message);
    }

    //2

    public class YoutubeChannel : IPublisher
    {
        public string Name { get; set; }
        Dictionary<string, ISubscriber> _subscribers;

        public YoutubeChannel()
        {
            this._subscribers = new Dictionary<string, ISubscriber>();
        }


        public void PublishVideo()
        {
            //publishing operations and after that send message to followers

            this.Notify($" {this.Name} channel was published a new video.");
        }

        public void Notify(string message)
        {
            foreach (var subscriber in this._subscribers.Values)
            {
                subscriber.UpdateData(message);
            }
        }

        public void Subscribe(ISubscriber member)
        {
            if (!this._subscribers.ContainsKey(member.Name))
            {
                this._subscribers.Add(member.Name, member);
            }
        }

        public void UnSubscribe(ISubscriber member)
        {
            if (this._subscribers.ContainsKey(member.Name))
            {
                this._subscribers.Remove(member.Name);
            }
        }
    }

    //3
    public class YoutubeMember : ISubscriber
    {
        public string Name { get; set; }

        public void UpdateData(string message)
        {
            Console.WriteLine(message);
        }
    }


}
