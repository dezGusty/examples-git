using System;

namespace sample_proj_mstest
{
    /// Description for git pickaxe
    /// Sample class
    internal class Sample
    {
        /// Get the time in milliseconds up to the first occurrence of
        /// when a task is expected to run.
        /// Note: we're dealing with recurring tasks here.
        public static double GetTimeToFirstScheduledRun(
            DateTime appLaunchTime,
            DateTime desiredStartTime,
            double frequencyInMs)
        {
            // Set the first timer occurrence. Differs from the typical duration afterwards.
            // E.g. daily timer, for 11:00. If the application is started at 09:00, the first
            // time interval should be set for 2 hours. Subsequent intervals would be set to 24hrs.
            if (appLaunchTime.CompareTo(desiredStartTime) < 0)
            {
                // desiredStartTime is in the FUTURE from appLaunchTime.
                // E.g. If Now is 09:00 and SyncStartTime is at 11:00. 24hrs standard repetition.
                // => interval should be 11-9 => 2 hrs
                return desiredStartTime.Subtract(appLaunchTime).Milliseconds;
            }
            else
            {
                // desiredStartTime is in the PAST from appLaunchTime.
                // E.g. If Now is 13:00 and SyncStartTime is at 11:00. 24hrs standard sync freq.
                // => initial interval should be 24     +11 -13 => 22hrs
                // E.g. If Now is 13:00 and SyncStartTime is at 11:00. 6hrs standard repetition.
                // => initial interval should be 6      +11 -13 => 4hrs
                // E.g. If Now is 13:00 and SyncStartTime is at 11:00. 1.5hrs standard repetition.
                // => initial interval should be 1.5*2  +11 -13 => 1hrs7
                //             frequencyInMs + desiredStartTime - appLaunchTime
                // E.g. If Now is 13:00 and SyncStartTime is at 11:00. 0.5hrs standard repetition.
                // => initial interval should be 0.5*5  +11 -13 => 0.5 hrs (cannot be now)
                //             frequencyInMs + desiredStartTime - appLaunchTime
                int multiplier = (int)(appLaunchTime.Subtract(desiredStartTime).TotalMilliseconds / 1000)
                    / (int)(frequencyInMs / 1000);
                double result = frequencyInMs * (multiplier + 1)
                        + desiredStartTime.Subtract(appLaunchTime).TotalMilliseconds;

                return result;
            }
        }
    }
}