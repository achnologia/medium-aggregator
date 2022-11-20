using System.Reflection;
using System.Text;
using MediumAggregator.DataAccess.Entities;

namespace MediumAggregator.DataAccess;

internal class FileDataContext : IDataContext
{
    private readonly StringConvertor _stringConvertor = new();

    private readonly string _fileName = "DataBase.txt";
    private readonly string _filePath;

    public FileDataContext()
    {
        var projectDirectory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
        
        _filePath = Path.Combine(projectDirectory, _fileName);
    }
    
    public async Task Save(IEnumerable<Article> articles)
    {
        foreach (var a in articles)
        {
            await Save(a);
        }
    }

    public async Task Save(Article article)
    {
        var entityString = _stringConvertor.Serialize(article);

        await File.AppendAllTextAsync(_filePath, entityString);
    }
}

internal class StringConvertor
{
    public string Serialize(Article a)
    {
        var sb = new StringBuilder();

        sb.AppendLine($"ID: {a.Id.ToString()}");
        sb.AppendLine($"Title: {a.Title}");
        sb.AppendLine($"Author: {a.Author}");
        sb.AppendLine($"Post Date: {a.PostDate}");
        sb.AppendLine($"Read time: {a.ReadTime}");
        sb.AppendLine($"Url: {a.Url}");
        
        sb.AppendLine(";");

        return sb.ToString();
    }

    public IEnumerable<Article> Deserialize(string s)
    {
        throw new NotImplementedException();
    }
}