using YoutubeExplode;
var youtube = new YoutubeClient();
var list=new List<string>();
Console.WriteLine("input list url");

var playlisturl =Console.ReadLine();
Console.WriteLine("loading...");
Dictionary<string,int> result=new(); 
await foreach (var video in youtube.Playlists.GetVideosAsync(
    playlisturl
))
{
  list.Add(video.Title);
}
foreach(var sentence in list)
{
    var words=sentence.Split(' ');
    foreach(var word in words)
    {
        if (result.TryAdd(word, 1) == false)
            result[word] += 1;
    }
}
var sortedDict = from entry in result orderby entry.Value ascending select entry ;

foreach (KeyValuePair<string,int> kvp in sortedDict)
{
    Console.WriteLine("word = {0}, count = {1}", kvp.Key, kvp.Value);
}
Console.WriteLine("total videos = {0}, total words = {1}", list.Count,sortedDict.Count());
