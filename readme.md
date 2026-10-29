// install qdrant locally using below prompt
docker run -p 6333:6333 -p 6334:6334 qdrant/qdrant

// access qdrant at
http://localhost:6333/dashboard

// add package 
dotnet add package Qdrant.Client
