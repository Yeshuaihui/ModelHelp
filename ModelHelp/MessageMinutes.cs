using System;
using System.Timers;

namespace ModelHelp
{

    public abstract class BaseMessage<T> : IDisposable
    {
        private object lockobj = new object();
        protected BaseMessage(TimeToDo<T> timeToDo, T message, DateTime dotime)
        {
            this.timer = new Timer();
            this.timeToDo = timeToDo;
            this.dotime = dotime;
            this.message = message;
            this.timer.Elapsed += Timer_Elapsed;
        }
        protected T message;
        protected DateTime dotime;
        protected TimeToDo<T> timeToDo;
        protected Timer timer;
        protected string dotimeString;
        protected bool isInvoke
        {
            get { return _isInvoke; }
            private set
            {
                _isInvoke = value;
                if (_isInvoke)
                {
                    timer.Stop();
                }
            }
        }
        protected bool _isInvoke = false;
        public abstract void Dispose();
        protected abstract bool CanDo();
        protected void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (CanDo())
            {
                lock (lockobj)
                {
                    if (!isInvoke)
                    {
                        timeToDo?.Invoke(this.message);
                        isInvoke = true;
                        Dispose();
                    }
                }
            }
        }
    }


    /// <summary>
    /// 自定义多久之后做某事一次
    /// 适用于精度为分钟级别
    /// 最起码多少分钟后执行操作
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class MessageMinutes<T> : BaseMessage<T>
    {
        public MessageMinutes(TimeToDo<T> timeToDo, T message, DateTime dotime, double Interval = 15000):base(timeToDo,message,dotime)
        {
            dotimeString = this.dotime.ToString("yyyyMMddHHmm");
            timer.Interval = Interval;
            timer.Start();
        }

        public override void Dispose()
        {
            timeToDo = null;
            message = default(T);
            timer.Dispose();
            timer = null;
            GC.SuppressFinalize(this);
            GC.Collect();
            GC.WaitForPendingFinalizers();

        }

        protected override bool CanDo()
        {
            return dotimeString == DateTime.Now.ToString("yyyyMMddHHmm");
        }

        ~MessageMinutes()
        {
            Console.WriteLine("析构执行了");
            Dispose();
        }
    }


    public sealed class MessageSeconds<T> : BaseMessage<T>
    {
        private object lockobj = new object();
        public MessageSeconds(TimeToDo<T> timeToDo, T message, DateTime dotime): base(timeToDo, message, dotime)
        {
            dotimeString = this.dotime.ToString("yyyyMMddHHmmss");
            timer.Interval = 800;
            timer.Start();
        }
        public override void Dispose()
        {
            timeToDo = null;
            message = default(T);
            timer.Dispose();
            timer = null;
            GC.SuppressFinalize(this);
            GC.Collect();
            GC.WaitForPendingFinalizers();

        }
        protected override bool CanDo()
        {
            return dotimeString == DateTime.Now.ToString("yyyyMMddHHmmss");
        }
        ~MessageSeconds()
        {
            Console.WriteLine("析构执行了");
            Dispose();
        }
    }

    public delegate void TimeToDo<T>(T message);
}
