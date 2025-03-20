namespace CosmosDb.NoSql.Infrastructure.Constants;

internal static class DataAccessConstants
{
    // endpoint of the CosmosDb service to connect to
    internal const string CosmosEndpointUri = "CosmosEndpointUri";

    // Primary Key of the CosmosDb instance
    internal const string CosmosPrimaryKey = "CosmosPrimaryKey";

    // CosmosDb Database Name to connect to
    internal const string DatabaseName = "samples";

    // Name of the container with items and data
    internal const string ContainerName = "restuarants";

    internal const string PartitionKey = "/CuisineType";
}
