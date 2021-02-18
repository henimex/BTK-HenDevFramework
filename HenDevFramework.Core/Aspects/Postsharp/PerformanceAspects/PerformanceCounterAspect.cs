using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using HenDevFramework.Core.CrossCuttingConcerns.Logging.Log4Net;
using HenDevFramework.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using PostSharp.Aspects;

namespace HenDevFramework.Core.Aspects.Postsharp.PerformanceAspects
{
    [Serializable]
    public class PerformanceCounterAspect : OnMethodBoundaryAspect
    {
        private int _interval;
        [NonSerialized]
        private Stopwatch _stopwatch;
        private LoggerService _loggerService;

        public PerformanceCounterAspect(int interval = 5)
        {
            _interval = interval;
        }

        public override void RuntimeInitialize(MethodBase method)
        {
            _stopwatch = Activator.CreateInstance<Stopwatch>();
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            _stopwatch.Start();
            base.OnEntry(args);
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            _stopwatch.Stop();
            if (_stopwatch.Elapsed.TotalSeconds > _interval)
            {
                Debug.WriteLine("Performance : {0}.{1}->>{2}",args.Method.DeclaringType.FullName,args.Method.Name,_stopwatch.Elapsed.TotalSeconds);
                var warn = ($"{args.Method.DeclaringType.FullName}.{args.Method.Name}->>{_stopwatch.Elapsed.TotalSeconds}");
                _loggerService = (LoggerService)Activator.CreateInstance(typeof(DatabaseLogger));
                _loggerService.Warn(warn);
            }
            _stopwatch.Reset();
            base.OnExit(args);
        }
    }
}
