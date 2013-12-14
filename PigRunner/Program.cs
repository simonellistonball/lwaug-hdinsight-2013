using Microsoft.Hadoop.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PigRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            var credentials = new BasicAuthCredential
                 {
                     UserName = "simonellistonball",
                     Password = "bD9/6+WoP0d:eI%25lT'",
                     Server = new Uri("https://simonellistonball.azurehdinsight.net")

                 };
            var submissionClient = JobSubmissionClientFactory.Connect(credentials);
            submissionClient.JobStatusEvent += (o, e) =>
           Console.WriteLine(e.JobDetails.StatusCode);
            var pigJobParams = new PigJobCreateParameters
            {
                StatusFolder =
                    "wasbs://cluster@sebhdinsight.blob.core.windows.net/status",
                File =
                    "wasbs://cluster@sebhdinsight.blob.core.windows.net/lovecleanstreets.pig"
            };
            var job = submissionClient.CreatePigJob(pigJobParams);
            bool complete = false;
            while (!complete)
            {
                var jobDetails = submissionClient.GetJob(job.JobId);
                Console.WriteLine(jobDetails.StatusCode);
                Console.WriteLine(jobDetails.ExitCode);
                if (jobDetails.StatusCode == JobStatusCode.Completed)
                    complete = true;
                Thread.Sleep(2000);
            }
            Console.ReadLine();
        }
    }
}