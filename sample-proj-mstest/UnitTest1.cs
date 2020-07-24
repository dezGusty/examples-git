using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace sample_proj_mstest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // SyncStartTime is in the PAST.
            // E.g. If Now is 13:00 and SyncStartTime is at 11:00. 24hrs standard sync freq.
            // => initial interval should be 24     +11 -13 => 22hrs
            // E.g. If Now is 13:00 and SyncStartTime is at 11:00. 6hrs standard repetition.
            // => initial interval should be 6      +11 -13 => 4hrs
            // E.g. If Now is 13:00 and SyncStartTime is at 11:00. 1.5hrs standard repetition.
            // => initial interval should be 1.5*2  +11 -13 => 1hrs

            DateTime appStartTime = new DateTime(2020, 01, 24, 13, 0, 0);
            DateTime desiredSyncTime = new DateTime(2020, 01, 24, 11, 0, 0);
            double syncFreq = 24 * 60 * 60 * 1000;
            double expectedMillisTillThen = 22 * 60 * 60 * 1000;

            Assert.AreEqual(
                expectedMillisTillThen,
                Sample.GetTimeToFirstScheduledRun(appStartTime, desiredSyncTime, syncFreq),
                1);
        }

        [TestMethod]
        public void TestMethod2()
        {
            // SyncStartTime is in the PAST.
            // E.g. If Now is 13:00 and SyncStartTime is at 11:00. 24hrs standard sync freq.
            // => initial interval should be 24     +11 -13 => 22hrs
            // E.g. If Now is 13:00 and SyncStartTime is at 11:00. 6hrs standard repetition.
            // => initial interval should be 6      +11 -13 => 4hrs
            // E.g. If Now is 13:00 and SyncStartTime is at 11:00. 1.5hrs standard repetition.
            // => initial interval should be 1.5*2  +11 -13 => 1hrs

            DateTime appStartTime = new DateTime(2020, 01, 24, 13, 0, 0);
            DateTime desiredSyncTime = new DateTime(2020, 01, 24, 11, 0, 0);
            double expectedMillisTillThen = 4 * 60 * 60 * 1000;
            double syncFreq = 6 * 60 * 60 * 1000;

            Assert.AreEqual(
                expectedMillisTillThen,
                Sample.GetTimeToFirstScheduledRun(appStartTime, desiredSyncTime, syncFreq),
                1);
        }

        [TestMethod]
        public void TestMethod3()
        {
            // SyncStartTime is in the PAST.
            // E.g. If Now is 13:00 and SyncStartTime is at 11:00. 24hrs standard sync freq.
            // => initial interval should be 24     +11 -13 => 22hrs
            // E.g. If Now is 13:00 and SyncStartTime is at 11:00. 6hrs standard repetition.
            // => initial interval should be 6      +11 -13 => 4hrs
            // E.g. If Now is 13:00 and SyncStartTime is at 11:00. 1.5hrs standard repetition.
            // => initial interval should be 1.5*2  +11 -13 => 1hrs

            DateTime appStartTime = new DateTime(2020, 01, 24, 13, 0, 0);
            DateTime desiredSyncTime = new DateTime(2020, 01, 24, 11, 0, 0);
            double expectedMillisTillThen = 0.5 * 60 * 60 * 1000;
            double syncFreq = 0.5 * 60 * 60 * 1000;

            Assert.AreEqual(
                expectedMillisTillThen,
                Sample.GetTimeToFirstScheduledRun(appStartTime, desiredSyncTime, syncFreq),
                1);
        }


        [TestMethod]
        public void TestMethod4()
        {
            // SyncStartTime is in the PAST.
            // E.g. If Now is 13:00 and SyncStartTime is at 11:00. 24hrs standard sync freq.
            // => initial interval should be 24     +11 -13 => 22hrs
            // E.g. If Now is 13:00 and SyncStartTime is at 11:00. 6hrs standard repetition.
            // => initial interval should be 6      +11 -13 => 4hrs
            // E.g. If Now is 13:00 and SyncStartTime is at 11:00. 1.5hrs standard repetition.
            // => initial interval should be 1.5*2  +11 -13 => 1hrs

            // 10 minute sync freq.
            // start app at 19:12
            // set sync time for 18:14
            // => should start in 2 minutes (at 19:14).
            DateTime appStartTime = new DateTime(2020, 01, 24, 19, 12, 0);
            DateTime desiredSyncTime = new DateTime(2020, 01, 24, 18, 14, 0);
            double expectedMillisTillThen = 2 * 60 * 1000;
            double syncFreq = 10 * 60 * 1000;

            Assert.AreEqual(
                expectedMillisTillThen,
                Sample.GetTimeToFirstScheduledRun(appStartTime, desiredSyncTime, syncFreq),
                1);
        }

        [TestMethod]
        public void TestMethod5()
        {
            // SyncStartTime is in the PAST.
            // E.g. If Now is 13:00 and SyncStartTime is at 11:00. 24hrs standard sync freq.
            // => initial interval should be 24     +11 -13 => 22hrs
            // E.g. If Now is 13:00 and SyncStartTime is at 11:00. 6hrs standard repetition.
            // => initial interval should be 6      +11 -13 => 4hrs
            // E.g. If Now is 13:00 and SyncStartTime is at 11:00. 1.5hrs standard repetition.
            // => initial interval should be 1.5*2  +11 -13 => 1hrs

            // 10 minute sync freq.
            // start app at 19:12
            // set sync time for 21:14
            // => should start in 122 minutes (at 21:14).
            DateTime appStartTime = new DateTime(2020, 01, 24, 19, 12, 0);
            DateTime desiredSyncTime = new DateTime(2020, 01, 24, 21, 14, 0);
            double expectedMillisTillThen = 122 * 60 * 1000;
            double syncFreq = 10 * 60 * 1000;

            Assert.AreEqual(
                expectedMillisTillThen,
                Sample.GetTimeToFirstScheduledRun(appStartTime, desiredSyncTime, syncFreq),
                1);
        }
    }
}
