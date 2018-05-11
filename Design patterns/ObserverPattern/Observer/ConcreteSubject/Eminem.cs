using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Observer.Observer;
using Observer.Subject;

namespace Observer.ConcreteSubject
{
    public class Eminem : ICelebrity
    {
        private List<IFan> _followers;

        public Eminem()
        {
            FullName = "Eminem";
            _followers = new List<IFan>();
        }

        public string FullName { get; }
        public string Tweet { get; set; }
        public void Notify(string tweet)
        {
            Tweet = tweet;
            foreach (var fan in _followers)
            {
                fan.Update(this);
            }
        }

        public void AddFollower(IFan follower)
        {
            _followers.Add(follower);
        }

        public void RemoveFollower(IFan follower)
        {
            _followers.Remove(follower);
        }
    }
}
