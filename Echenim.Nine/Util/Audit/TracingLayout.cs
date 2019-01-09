using System;
using System.IO;
using log4net.Core;
using log4net.Layout;

namespace Echenim.Nine.Util.Audit
{

    public class TracingLayout : ExceptionLayout
    {
        public override void Format(TextWriter textWriter, LoggingEvent loggingEvent)
        {
            base.Format(textWriter, loggingEvent);

            if (loggingEvent.ExceptionObject != null)
                textWriter.Write(Environment.StackTrace);
        }
    }
}