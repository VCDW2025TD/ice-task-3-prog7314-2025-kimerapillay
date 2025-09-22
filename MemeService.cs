using Memes.Api.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Memes.Api.Services;

public class MongoSettings
{
    public string ConnectionString { get; set; } = default!;
    public string DatabaseName { get; set; } = default!;
}

public class MemeService
{
    private readonly IMongoCollection<Meme> _memes;

    public MemeService(IOptions<MongoSettings> options)
    {
        var client = new MongoClient(options.Value.ConnectionString);
        var database = client.GetDatabase(options.Value.DatabaseName);
        _memes = database.GetCollection<Meme>("memes");
    }

    public async Task<List<Meme>> GetAllAsync(string? userId = null)
    {
        var filter = string.IsNullOrWhiteSpace(userId)
            ? Builders<Meme>.Filter.Empty
            : Builders<Meme>.Filter.Eq(m => m.UserId, userId);

        return await _memes.Find(filter).SortByDescending(m => m.CreatedAt).ToListAsync();
    }

    public async Task<Meme> CreateAsync(Meme meme)
    {
        meme.CreatedAt = DateTime.UtcNow;
        await _memes.InsertOneAsync(meme);
        return meme;
    }

    public async Task<Meme?> GetByIdAsync(string id) =>
        await _memes.Find(m => m.Id == id).FirstOrDefaultAsync();
}
