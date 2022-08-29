using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cleverenceTask1
{
    public class Client
    {
        public async Task<int> Read()
        {
            var getCount = Task.Run(() =>
            {
                if (Server.writingInProgress)
                {
                    lock (Server.locker)
                    {
                        return Server.GetCount();
                    }
                }
                else
                {
                    return Server.GetCount();
                }
            });

            await getCount;

            return getCount.Result;
        }

        public void Write(int value)
        {
            Server.AddToCount(value);
        }
    }
}
