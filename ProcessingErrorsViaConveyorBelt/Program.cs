namespace ProcessingErrorsViaConveyorBelt
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
			Song song1 = new Song("song1", "singer1", "1999",
				"song1 text"), song2 = new Song("song2", "singer2", "2002",
				"song2 text"), song3 = new Song("song3", "singer3", "2005",
				"song3 text");//создание песен
			Song[] songs = { song1, song2, song3 };//массив песен
			// Add services to the container.
			builder.Services.AddControllersWithViews();

			var app = builder.Build();

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=ProcessingErrors}/{action=Processing}/{id?}");
			app.MapPost("/{name}/{singer}/{relYear}/" +
				"{text}", (string name, string singer, string relYear,
				string text) =>
			{
				Song song = new Song(name, singer, relYear,
					text);
				List<Song> songList = songs.ToList();//список песен
				songList.Add(song);
				songs = songList.ToArray();
			});
			app.MapDelete("/{name}", (string name) =>
			{
				Song? song = songs.FirstOrDefault(song => song.Name == name);
				List<Song> songList = songs.ToList();
				songList.Remove(song!);
				songs = songList.ToArray();
			});
			app.MapGet("/", async () =>
			{
				using (StreamWriter streamWriter = new StreamWriter("песни.txt", false)) foreach (Song singing in songs) await streamWriter.WriteLineAsync(singing.ToString());
				return songs;
			});
			app.Run();
		}
	}
}