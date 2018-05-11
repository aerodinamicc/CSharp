using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Observer.Observer;

namespace Observer.Subject
{
    public interface ICelebrity
    {
        string FullName { get; }
        string Tweet { get; set; }
        void Notify(string tweet);
        void AddFollower(IFan follower);
        void RemoveFollower(IFan follower);
    }
}
