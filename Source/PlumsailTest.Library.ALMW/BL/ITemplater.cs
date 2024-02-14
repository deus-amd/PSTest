namespace PlumsailTest.Library.ALMW;

public interface ITemplater
{
    string CreateHtml(string template, string jsonData);
}