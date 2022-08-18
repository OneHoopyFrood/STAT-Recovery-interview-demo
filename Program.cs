using System;
using System.Threading.Tasks;

// To interact with Amazon S3.
using Amazon.S3;
using Amazon.S3.Model;
using DotNetEnv;

const STAT_BUCKET_NAME = "stat-coding-erhu6npkbg"

namespace S3CreateAndList
{
  class Program
  {
    // Main method
    static async Task Main(string[] args)
    {
      // Before running this app:
      // - Credentials must be specified in an AWS profile. If you use a profile other than
      //   the [default] profile, also set the AWS_PROFILE environment variable.
      // - An AWS Region must be specified either in the [default] profile
      //   or by setting the AWS_REGION environment variable.
      // - Use .env to set the environment variables appropriately
      DotNetEnv.Env.Load();

      // Create an S3 client object.
      var s3Client = new AmazonS3Client();

      // List the buckets owned by the user.
      // Call a class method that calls the API method.
      Console.WriteLine($"\nGetting a list of objects in bucket {STAT_BUCKET_NAME}...");
      var listResponse = await ListBucketContentsAsync(s3Client);
      Console.WriteLine($"Number of objects: {listResponse.Buckets.Count}");
      foreach(S3Object obj in listResponse.S3Objects)
      {
        Console.WriteLine(obj.Key);
      }
    }

    //
    // Async method to get a list of Amazon S3 buckets.
    private static async Task<ListObjectsResponse> ListBucketContentsAsync(IAmazonS3 s3Client)
    {
      return await s3Client.ListObjectsAsync(STAT_BUCKET_NAME);
    }

  }
}
