using System.Buffers;
using System.Reflection;
using System.Text;
using MediumAggregator.DataAccess.Entities;

namespace MediumAggregator.DataAccess;

internal class FileDataContext : IDataContext
{
    private readonly StringConvertor _stringConvertor = new();

    private readonly string _fileName = "DataBase.txt";
    private readonly string _filePath;

    private readonly HashSet<Article> _articles;

    public FileDataContext()
    {
        var projectDirectory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
        
        _filePath = Path.Combine(projectDirectory, _fileName);

        var savedArticles = Enumerable.Empty<Article>();
        
        if (File.Exists(_filePath))
        {
            var db = File.ReadAllText(_filePath);
            savedArticles = _stringConvertor.Deserialize(db);
        }
        
        _articles = new HashSet<Article>(savedArticles);
    }
    
    public async Task<int> Save(IEnumerable<Article> articles)
    {
        var counter = 0;
        
        foreach (var a in articles)
        {
            if (await Save(a))
                counter++;
        }

        return counter;
    }

    public async Task<bool> Save(Article article)
    {
        if (_articles.Any(x => x.Author == article.Author && x.Title == article.Title))
            return false;

        try
        {
            var entityString = _stringConvertor.Serialize(article);

            await File.AppendAllTextAsync(_filePath, entityString);
            _articles.Add(article);

            return true;
        }
        catch (IOException e)
        {
            return false;
        }
    }
}

internal class StringConvertor
{
    private readonly char _separator = ';';
    private readonly char _lineSeparator = Environment.NewLine[0]; // it's either \r for windows(\r\n) or \n for unix
    private readonly char _columnValueSeparator = ':';
    
    public string Serialize(Article a)
    {
        var sb = new StringBuilder();

        sb.AppendLine($"ID:{a.Id.ToString()}");
        sb.AppendLine($"Title:{a.Title.Replace(";", "")}");
        sb.AppendLine($"Author:{a.Author}");
        sb.AppendLine($"Post Date:{a.PostDate}");
        sb.AppendLine($"Read time:{a.ReadTime}");
        sb.AppendLine($"Url:{a.Url}");
        
        sb.AppendLine(_separator.ToString());

        return sb.ToString();
    }

    public IEnumerable<Article> Deserialize(string s)
    {
        if (string.IsNullOrEmpty(s))
            return Enumerable.Empty<Article>();

        var wholeSpan = s.AsSpan();
        var currentIndex = 0;
        var result = new List<Article>();

        for (var i = 0; i < wholeSpan.Length; i++)
        {
            if (wholeSpan[i] == _separator)
            {
                var articleSpan = wholeSpan.Slice(currentIndex, i - currentIndex);

                var a = ConvertToArticle(ref articleSpan);
                
                result.Add(a);
                currentIndex = ++i + Environment.NewLine.Length;
            }
        }

        return result;
    }

    private Article ConvertToArticle(ref ReadOnlySpan<char> articleSpan)
    {
        var lineCounter = 0;
        var currentIndex = 0;

        var arrayPool = ArrayPool<string>.Shared;
        var valuesArray = arrayPool.Rent(6);

        for (var i = 0; i < articleSpan.Length; i++)
        {
            if (articleSpan[i] == _lineSeparator)
            {
                var line = articleSpan.Slice(currentIndex, i - currentIndex);

                var v = ParseLine(ref line);

                valuesArray[lineCounter++] = v;

                currentIndex = i + 2;
            }
        }

        var article = new Article
        {
            Id = Guid.Parse(valuesArray[0]),
            Title = valuesArray[1],
            Author = valuesArray[2],
            PostDate = DateTime.Parse(valuesArray[3]),
            ReadTime = Convert.ToDouble(valuesArray[4]),
            Url = valuesArray[5]
        };

        return article;
    }

    private string ParseLine(ref ReadOnlySpan<char> line)
    {
        var indexOfSeparator = line.IndexOf(_columnValueSeparator);
        var value = line.Slice(indexOfSeparator + 1, line.Length - indexOfSeparator - 1);

        return value.ToString();
    }
}