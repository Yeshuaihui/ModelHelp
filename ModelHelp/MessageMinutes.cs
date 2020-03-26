using System;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace ModelHelp
{

    public class Delay
    {
        /// <summary>
        /// 设置一段时间后做一件事情
        /// </summary>
        /// <param name="timeToDo">需要做的事情</param>
        /// <param name="msg">事情需要的参数</param>
        /// <param name="time">多久后做单位秒</param>
        public static void DelayDo<T>(TimeToDo<T> timeToDo, T msg, int time)
        {
            Task.Run(() =>
            {
                Thread.Sleep(time * 1000);
                timeToDo(msg);
            });
        }
    }
    public delegate void TimeToDo<T>(T message);
}
