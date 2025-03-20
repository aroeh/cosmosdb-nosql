using CosmosDb.NoSql.Infrastructure.Repos;
using CosmosDb.NoSql.Shared.Models;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Logging;
using System.Net;

namespace CosmosDb.NoSql.Core.Orchestrations;

public class RestuarantOrchestration(ILogger<RestuarantOrchestration> log, IRestuarantRepo repo) : IRestuarantOrchestration
{
    private readonly ILogger<RestuarantOrchestration> _logger = log;
    private readonly IRestuarantRepo _repo = repo;

    /// <summary>
    /// Retrieves all Restuarant from the database
    /// </summary>
    /// <returns>Array of Restuarant objects</returns>
    public async Task<Restuarant[]> GetAllRestuarants()
    {
        _logger.LogInformation("Initiating get all restuarants");
        Restuarant[] restuarants = await _repo.GetAllRestuarants();

        if (restuarants is null || restuarants.Length == 0)
        {
            return [];
        }

        return restuarants;
    }

    /// <summary>
    /// Retrieves all Restuarant from the database matching search criteria
    /// </summary>
    /// <param name="name">Search Parameter on the Restuarant Name</param>
    /// <param name="cuisine">Search Parameter on the Restuarant CuisineType</param>
    /// <returns>Array of Restuarant objects</returns>
    public async Task<Restuarant[]> FindRestuarants(string name, string cuisine)
    {
        _logger.LogInformation("Initiating find restuarants");
        Restuarant[] restuarants = await _repo.FindRestuarants(name, cuisine);

        if (restuarants is null || restuarants.Length == 0)
        {
            return [];
        }

        return restuarants;
    }

    /// <summary>
    /// Retrieves a Restuarant from the database by id
    /// </summary>
    /// <param name="id">Unique Identifier for a restuarant</param>
    /// <returns>Restuarant</returns>
    public async Task<Restuarant> GetRestuarant(string id)
    {
        _logger.LogInformation("Initiating get restuarant by id");
        Restuarant restuarant = await _repo.GetRestuarant(id);

        if (restuarant is null)
        {
            return new Restuarant();
        }

        return restuarant;
    }

    /// <summary>
    /// Inserts a new Restuarant record
    /// </summary>
    /// <param name="restuarant">Restuarant object to insert</param>
    /// <returns>Success status of the insert operation</returns>
    public async Task<bool> InsertRestuarant(Restuarant restuarant)
    {
        _logger.LogInformation("Adding new restuarant");
        ItemResponse<Restuarant> result = await _repo.InsertRestuarant(restuarant);

        _logger.LogInformation("Checking insert operation result");
        return result.StatusCode.Equals(HttpStatusCode.OK) || result.StatusCode.Equals(HttpStatusCode.Created);
    }

    /// <summary>
    /// Inserts a new Restuarant record
    /// </summary>
    /// <param name="restuarants">Restuarant array with many items to insert</param>
    /// <returns>Success status of the insert operation</returns>
    public async Task<bool> InsertRestuarants(Restuarant[] restuarants)
    {
        _logger.LogInformation("Adding new restuarant");
        ItemResponse<Restuarant>[] results = await _repo.InsertRestuarants(restuarants);

        _logger.LogInformation("Checking insert operation result");
        return results is not null
            && results.Length > 0
            && results.All(r => r.StatusCode.Equals(HttpStatusCode.OK) || r.StatusCode.Equals(HttpStatusCode.Created));
    }

    /// <summary>
    /// Updates a Restuarant record
    /// </summary>
    /// <param name="restuarant">Restuarant object to update</param>
    /// <returns>Success status of the update operation</returns>
    public async Task<bool> UpdateRestuarant(Restuarant restuarant)
    {
        _logger.LogInformation("Updating restuarant");
        ItemResponse<Restuarant> result = await _repo.UpdateRestuarant(restuarant);

        _logger.LogInformation("Checking update operation result");
        return result.StatusCode.Equals(HttpStatusCode.OK);
    }
}
