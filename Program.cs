
using System.Net.WebSockets;
using Qdrant.Client;
using Qdrant.Client.Grpc;





const string collectionName = "testFromCode";
var client = new QdrantClient("localhost", 6334);

if (!await client.CollectionExistsAsync(collectionName))
{

    await client.CreateCollectionAsync(collectionName,
    new VectorParams
    {
        Size = 4,
        Distance = Distance.Cosine
    });

}
await client.UpsertAsync(collectionName, new[]
{
    new PointStruct
    {
        Id=1,
        Vectors = new float[] {0.090f, 0.10f, 0.00f, 0.00f},
        Payload =
        {
            ["chunk_id"] = "test-001",
            ["text"] = "This is an example for test with 001 i a, lestt than 002"

        }

    },
        new PointStruct
    {
        Id=2,
        Vectors = new float[] {0.080f, 0.20f, 0.00f, 0.00f},
        Payload =
        {
            ["chunk_id"] = "test-001",
            ["text"] = "This is an example for test with 002 greater than 001"

        }
    },
        new PointStruct
    {
        Id=3,
        Vectors = new float[] {0.070f, 0.3f, 0.00f, 0.00f},
        Payload =
        {
            ["chunk_id"] = "test-001",
            ["text"] = "This is an example for test with 003"

        }
    },
        new PointStruct
    {
        Id=4,
        Vectors = new float[] {0.060f, 0.40f, 0.00f, 0.00f},
        Payload =
        {
            ["chunk_id"] = "test-001",
            ["text"] = "This is an example for test with 004"

        }
    }

});


var hits = await client.QueryAsync(collectionName,
query: new float[] { 0.080f, 0.20f, 0.00f, 0.00f },
limit: 3);

foreach (var hit in hits)
{
    Console.WriteLine("ID = " + hit.Id + "score = " + hit.Score);

}

Console.ReadLine();