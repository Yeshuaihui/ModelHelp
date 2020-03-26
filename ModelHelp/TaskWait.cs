using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelHelp
{
    /// <summary>
    /// 批量任务帮助
    /// </summary>
    public class TaskWait
    {
        public TaskWait()
        {
            AllTask = new List<Task>();
            OneTime = 10;
        }
        /// <summary>
        /// 所有的Task
        /// </summary>
        private List<Task> AllTask { get; set; }
        /// <summary>
        /// 一次同事执行几个task
        /// </summary>
        public int OneTime { get; set; }

        /// <summary>
        /// 开始执行
        /// </summary>
        public void Run()
        {
            AllTask.Take(OneTime).ToList().ForEach(t =>
            {
                t.Start();
            });
        }
        /// <summary>
        /// 添加任务
        /// </summary>
        /// <param name="task"></param>
        public void AddTask(Task task)
        {
            task.GetAwaiter().OnCompleted(() =>
            {
                var t = AllTask.FirstOrDefault(f => f.Status == TaskStatus.Created);
                if (t != null)
                {
                    t.Start();
                }
            });
            AllTask.Add(task);
        }

        public void Wait()
        {
            Task.WaitAll(AllTask.ToArray());
        }
    }

}
