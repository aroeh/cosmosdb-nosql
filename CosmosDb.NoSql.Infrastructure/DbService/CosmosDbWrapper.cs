using Microsoft.Azure.Cosmos;

namespace CosmosDb.NoSql.Infrastructure.DbService;

public class CosmosDbWrapper : ICosmosDbWrapper
{
    private readonly CosmosDbService cosmos = new();

    /// <summary>
    /// Query items in the container using a query
    /// </summary>
    /// <typeparam name="T">Generic type of the object to return</typeparam>
    /// <param name="query">CosmosDb query command</param>
    /// <returns>IEnumerable of T</returns>
    public Task<IEnumerable<T>> QueryItems<T>(string query) => cosmos.QueryItems<T>(query);

    /// <summary>
    /// Query for a single item in the container using a query
    /// </summary>
    /// <typeparam name="T">Generic type of the object to return</typeparam>
    /// <param name="query">CosmosDb query command</param>
    /// <returns>Object of T</returns>
    public Task<T?> QueryItem<T>(string query) => cosmos.QueryItem<T>(query);

    /// <summary>
    /// Create a new item in the cosmos db container
    /// </summary>
    /// <typeparam name="T">Generic type of the object to add</typeparam>
    /// <param name="item">Object to the add</param>
    /// <returns>ItemResponse of T</returns>
    public Task<ItemResponse<T>> CreateItem<T>(T item) => cosmos.CreateItem<T>(item);

    /// <summary>
    /// Create a new item in the cosmos db container
    /// </summary>
    /// <typeparam name="T">Generic type of the object to add</typeparam>
    /// <param name="items">Collection of objects to add</param>
    /// <returns>ItemResponse of T</returns>
    public Task<IEnumerable<ItemResponse<T>>> CreateItems<T>(IEnumerable<T> items) => cosmos.CreateItems<T>(items);

    /// <summary>
    /// Replaces an existing item with a newer version of the item
    /// </summary>
    /// <typeparam name="T">Generic type of the object to replace</typeparam>
    /// <param name="item">New version of the object</param>
    /// <param name="id">Unique identifier for the object</param>
    /// <returns>ItemResponse of T</returns>
    public Task<ItemResponse<T>> ReplaceItem<T>(T item, string id) => cosmos.ReplaceItem<T>(item, id);
}
